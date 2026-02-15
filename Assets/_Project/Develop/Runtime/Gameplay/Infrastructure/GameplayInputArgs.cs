using _Project.Develop.Runtime.Configs.Gameplay;
using _Project.Develop.Runtime.Utilities.SceneManagement;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayInputArgs : IInputSceneArgs
    {
        public GameplayInputArgs(GameMode gameMode)
        {
            GameMode = gameMode;
        }

        public GameMode GameMode { get; }
    }
}
