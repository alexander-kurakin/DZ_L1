using System;
using System.Collections;
using _Project.Develop.Runtime.Gameplay.Logic;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;
        private GameplayCycleService _gameplayCycleService;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
                throw new ArgumentException($"{nameof(sceneArgs)} is not match with {typeof(GameplayInputArgs)} type");

            _inputArgs = gameplayInputArgs;

            GameplayContextRegistrations.Process(_container, _inputArgs);
            _gameplayCycleService = _container.Resolve<GameplayCycleService>();
        }

        public override IEnumerator Initialize()
        {
            Debug.Log($"Игровой режим {_inputArgs.GameMode}");
            
            Debug.Log("Инициализация геймплейной сцены");
            
            _gameplayCycleService.Prepare();

            yield break;
        }

        public override void Run()
        {
            Debug.Log("Старт геймплейной сцены");
            _gameplayCycleService.Launch();
        }

        private void Update()
        {
            _gameplayCycleService?.Update(Time.deltaTime);
        }
    }
}
