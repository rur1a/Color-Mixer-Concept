using System.Collections.Generic;
using Code.Data.Produce;
using UnityEngine;

namespace Code.Data.Game
{
    [CreateAssetMenu(fileName = "Levels Data", menuName = "Static Data/Levels Data")]
    public class GameData : ScriptableObject
    {
        [field: SerializeField] public int MaxDifference { get; private set; }
        [SerializeField] private LevelConfig[] _levelConfigs;
        public IReadOnlyCollection<LevelConfig> LevelConfigs => _levelConfigs;
    }
}