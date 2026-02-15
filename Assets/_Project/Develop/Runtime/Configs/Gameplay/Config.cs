using System;
using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Gameplay
{
    [Serializable]
    public class Config
    {
        [field: SerializeField] public GameMode GameMode { get; private set; }
        [field: SerializeField] public LevelConfig LevelConfig { get; private set; }
    }
}