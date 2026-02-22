using _Project.Develop.Runtime.Configs.Gameplay;
using _Project.Develop.Runtime.Gameplay.Infrastructure;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Core
{
    public class GameModeChooseService
    {
        private ICoroutinesPerformer _coroutinesPerformer;
        private SceneSwitcherService _sceneSwitcherService;

        public GameModeChooseService(ICoroutinesPerformer coroutinesPerformer,
            SceneSwitcherService sceneSwitcherService)
        {
            _coroutinesPerformer = coroutinesPerformer;
            _sceneSwitcherService = sceneSwitcherService;
        }
        
        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _coroutinesPerformer.StartPerform(
                    _sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, 
                        new GameplayInputArgs(GameMode.Digits)));
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay,
                    new GameplayInputArgs(GameMode.Letters)));
            }
        }
    }
}