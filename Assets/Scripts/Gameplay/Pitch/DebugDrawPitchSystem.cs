using Leopotam.Ecs;
using UnityEngine;

namespace FootballECS
{
    public class DebugDrawPitchSystem : IEcsInitSystem
    {
        private readonly GameData _gameData = null;


        public void Init()
        {
            var drower = new GameObject("[PitchDrawer]")
                .AddComponent<DebugDrawPitch>();
                
            drower.Init(_gameData.Config.PitchSettings.Size);
        }
    }
}


