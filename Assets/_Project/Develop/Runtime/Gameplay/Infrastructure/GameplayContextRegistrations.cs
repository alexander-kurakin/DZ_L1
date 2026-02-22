using _Project.Develop.Runtime.Configs.Gameplay;
using _Project.Develop.Runtime.Gameplay.Logic;
using _Project.Develop.Runtime.Gameplay.Utilities;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayContextRegistrations
    {
        private static LevelConfig _currentLevelConfig;
        private static GameplayInputArgs _inputArgs;
        
        public static void Process(DIContainer container, GameplayInputArgs args)
        {
            Debug.Log("Процесс регистрации сервисов на сцене геймплея");
            _inputArgs = args;
            ConfigsProviderService configsProviderService = container.Resolve<ConfigsProviderService>();
            
            LevelConfigs levelConfigs = configsProviderService.GetConfig<LevelConfigs>();
            _currentLevelConfig = levelConfigs.GetLevelConfigBy(_inputArgs.GameMode);
            
            Debug.Log($"Символы для уровня: {_currentLevelConfig.Symbols}");
            
            container.RegisterAsSingle(CreateSymbolGeneratorService);
            container.RegisterAsSingle(CreateGameplayCycleService);
            
        }

        private static SymbolGeneratorService CreateSymbolGeneratorService(DIContainer c)
            => new SymbolGeneratorService(_currentLevelConfig.Symbols);

        private static GameplayCycleService CreateGameplayCycleService(DIContainer c)
            => new GameplayCycleService(
                c.Resolve<SymbolGeneratorService>(), 
                _currentLevelConfig, 
                c.Resolve<SceneSwitcherService>(),
                c.Resolve<ICoroutinesPerformer>(),
                _inputArgs);
    }
}
