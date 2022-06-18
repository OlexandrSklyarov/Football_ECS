using System;
using System.Collections.Generic;
using System.Linq;
using Leopotam.Ecs;
using UnityEngine;

namespace FootballECS
{
    sealed class InitGameSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly GameData _gameData = null;


        public void Init()
        {
            Debug.Log("Init game!!!");

            var pitchEntity = _world.NewEntity();

            ref var pitch = ref pitchEntity.Get<FootballPitch>();

            pitch.RedTeamStartPositions = _gameData.WorldInfo.RedTeamStartPositions;
            pitch.BlueTeamStartPositions = _gameData.WorldInfo.BlueTeamStartPositions;

            var playersRoot = new GameObject("[Players]").transform;
                
            CreateTeam(TeamType.RED, pitch.RedTeamStartPositions.Select(tr => tr.position), 
                _gameData.Config.PlayerSettings.RedTeamColor, playersRoot);

            CreateTeam(TeamType.BLUE, pitch.BlueTeamStartPositions.Select(tr => tr.position), 
                _gameData.Config.PlayerSettings.BlueTeamColor, playersRoot);            
        }


        private void CreateTeam(TeamType type, IEnumerable<Vector3> positions, Color teamColor, Transform root)
        {
            ref var team = ref _world.NewEntity().Get<SoccerTeam>();

            team.Name = type.ToString();
            team.Type = type;
            team.Players = new List<EcsEntity>();

            foreach (var position in positions)
            {
                var playerEntity = _world.NewEntity();
                var playerGO = CreatePlayer(position, root);

                ref var location = ref playerEntity.Get<Location>();
                location.MyTransform = playerGO.transform;

                ref var view = ref playerEntity.Get<PlayerView>();
                view.BodyRenderers = playerGO.GetComponent<PlayerProvider>().BodyRenderers;
                Array.ForEach(view.BodyRenderers, r => r.material.color = teamColor);

                team.Players.Add(playerEntity);
            }
        }


        private GameObject CreatePlayer(Vector3 position, Transform root)
        {
            return UnityEngine.Object.Instantiate
            (
                _gameData.Config.PlayerSettings.Prefab,
                position,
                Quaternion.identity,
                root
            );
        }
    }
}