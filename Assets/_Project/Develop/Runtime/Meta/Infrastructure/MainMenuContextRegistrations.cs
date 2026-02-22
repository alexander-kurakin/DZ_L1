using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Core;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            Debug.Log("Процесс регистрации сервисов на сцене меню");
            container.RegisterAsSingle(CreateGameModeChooseService);
        }
        
        private static GameModeChooseService CreateGameModeChooseService(DIContainer c)
            => new GameModeChooseService(
                c.Resolve<ICoroutinesPerformer>(),
                c.Resolve<SceneSwitcherService>());
    }
}
