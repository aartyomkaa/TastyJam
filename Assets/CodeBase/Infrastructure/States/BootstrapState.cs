using CodeBase.Infrastructure.AssetManagment;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StaticData;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Level1 = "Level1";

        private GameStateMachine _stateMachine;
        private AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, AllServices allServices)
        {
            _stateMachine = stateMachine;
            _services = allServices;
            
            RegisterServices();
        }

        public void Enter()
        {
            _stateMachine.Enter<LoadLevelState, string>(Level1);
        }

        public void Exit()
        {
            
        }
        
        private void RegisterServices()
        {
            //RegisterStaticData();
            
            _services.RegisterSingle<IAssets>(new AssetsProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>(), _services.Single<IStaticDataService>()));
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.LoadMonsters();
            _services.RegisterSingle<IStaticDataService>(staticData);
        }
    }
}