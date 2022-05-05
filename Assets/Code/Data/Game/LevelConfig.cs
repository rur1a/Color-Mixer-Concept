using System;
using Code.Data.Produce;
using UnityEngine;

namespace Code.Data.Game
{
    [Serializable]
    public class LevelConfig 
    {
        [field: SerializeField] public Color TargetColor { get; private set; }
        [field: SerializeField] public ProduceData ProduceData { get; private set; }
        
    #if UNITY_EDITOR
        public void SetTargetColor(Color color)
        {
            TargetColor = color;
        }
    #endif
    }
}