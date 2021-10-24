using Leopotam.Ecs;
using UnityEngine;

namespace Football.Ecs
{
    public class InitGameSystem : IEcsInitSystem
    {
        private EcsWorld _world = null;


        public void Init()
        {
            Debug.Log("Init game!!!");
        }
    }
}