using Leopotam.Ecs;
using UnityEngine;

namespace Football.ECS
{
    public class StartGame : MonoBehaviour
    {

        private EcsWorld _world;
        private EcsSystems _updateSystem;


        private void Start()
        {
            _world = new EcsWorld();
            _updateSystem = new EcsSystems(_world);

            RegisterSystems();
            RegisterOnFrameEvents();
            InjectServices();
            InitSystems();
        }


        private void RegisterSystems()
        {
            _updateSystem
                .Add(new InitGameSystem());
        }


        private void RegisterOnFrameEvents()
        {
            // _updateSystem
            //     .OneFrame<>();
        }


        private void InjectServices()
        {
            // _updateSystem
            //     .Inject();
        }


        private void InitSystems()
        {
            _updateSystem.Init();
        }


        private void Update()
        {
            _updateSystem.Run();
        }


        private void OnDestroy()
        {
            _updateSystem.Destroy();
            _updateSystem = null;

            _world.Destroy();
            _world = null;            
        }
    }
}