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
                
            CreateTeam("Red", pitch.RedTeamStartPositions.Select(tr => tr.position), 
                _gameData.Config.PlayerSettings.RedTeamColor);

            CreateTeam("Blue", pitch.BlueTeamStartPositions.Select(tr => tr.position), 
                _gameData.Config.PlayerSettings.BlueTeamColor);
            
        }


        private void CreateTeam(string teamName, IEnumerable<Vector3> positions, Color teamColor)
        {
            var teamEntity = _world.NewEntity();

            ref var team = ref teamEntity.Get<SoccerTeam>();
            team.Name = teamName;

            foreach (var position in positions)
            {
                var playerEntity = _world.NewEntity();

                var playerGO = CreatePlayer(position);

                ref var location = ref playerEntity.Get<Location>();
                location.MyTransform = playerGO.transform;

                ref var view = ref playerEntity.Get<PlayerView>();
                view.BodyRenderers = playerGO.GetComponent<PlayerProvider>().BodyRenderers;
                Array.ForEach(view.BodyRenderers, r => r.material.color = teamColor);
            }
        }


        private GameObject CreatePlayer(Vector3 position)
        {
            return UnityEngine.Object.Instantiate
            (
                _gameData.Config.PlayerSettings.Prefab,
                position,
                Quaternion.identity
            );
        }
    }
}