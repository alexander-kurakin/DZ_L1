using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Gameplay
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/LevelConfigs", fileName = "LevelConfigs")]
    public class LevelConfigs : ScriptableObject
    {
        [SerializeField] private List<Config> _levelConfigs;
        
        public LevelConfig GetLevelConfigBy(GameMode gameMode)
            => _levelConfigs.First(config => config.GameMode == gameMode).LevelConfig;
    }
}