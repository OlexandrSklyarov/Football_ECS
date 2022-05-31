using Leopotam.Ecs;
using UnityEngine;

namespace FootballECS
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField] private GameConfig ConfigSO;
        [SerializeField] private WorldInfo _worldInfo;

        private EcsWorld _world;
        private EcsSystems _updateSystem;
        private GameData _gameData;


        private void Start()
        {
            _world = new EcsWorld();
            _updateSystem = new EcsSystems(_world);

            _gameData = new GameData()
            {
                Config = ConfigSO,
                WorldInfo = _worldInfo
            };

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
            _updateSystem
                .Inject(_gameData);
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