using System.Collections;
using _Project.Develop.Runtime.Configs.Gameplay;
using _Project.Develop.Runtime.Gameplay.Infrastructure;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Core;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameModeChooseService _gameModeChooseService;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistrations.Process(_container);
            _gameModeChooseService = _container.Resolve<GameModeChooseService>();
            
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("Инициализация сцены меню");

            yield break;
        }

        public override void Run()
        {
            Debug.Log("Старт сцены меню");
        }

        private void Update()
        {
            _gameModeChooseService?.Update(Time.deltaTime);
        }
    }
}
