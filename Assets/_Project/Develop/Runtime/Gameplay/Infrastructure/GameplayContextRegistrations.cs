using _Project.Develop.Runtime.Configs.Gameplay;
using _Project.Develop.Runtime.Gameplay.Logic;
using _Project.Develop.Runtime.Gameplay.Utilities;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayContextRegistrations
    {
        private static LevelConfig _currentLevelConfig;
        
        public static void Process(DIContainer container, GameplayInputArgs args)
        {
            Debug.Log("Процесс регистрации сервисов на сцене геймплея");
            
            ConfigsProviderService configsProviderService = container.Resolve<ConfigsProviderService>();
            
            LevelConfigs levelConfigs = configsProviderService.GetConfig<LevelConfigs>();
            _currentLevelConfig = levelConfigs.GetLevelConfigBy(args.GameMode);
            
            Debug.Log($"Символы для уровня: {_currentLevelConfig.Symbols}");
            
            container.RegisterAsSingle(CreateSymbolGeneratorService);
            container.RegisterAsSingle(CreateGameplayCycleService);
            
        }

        private static SymbolGeneratorService CreateSymbolGeneratorService(DIContainer c)
            => new SymbolGeneratorService(_currentLevelConfig.Symbols);

        private static GameplayCycleService CreateGameplayCycleService(DIContainer c)
            => new GameplayCycleService(c.Resolve<SymbolGeneratorService>(), _currentLevelConfig);
    }
}
