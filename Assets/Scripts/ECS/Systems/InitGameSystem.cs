using Leopotam.Ecs;
using UnityEngine;

namespace Football.ECS
{
    sealed class InitGameSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private EcsFilter<FootballPitchComponent> pitch = null;


        public void Init()
        {
            Debug.Log("Init game!!!");
        }
    }
}