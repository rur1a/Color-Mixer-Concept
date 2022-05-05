using System;
using Code.Data;
using Code.Data.Game;
using Code.Data.Produce;
using Code.Produces.ProduceSpawn;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Editor
{
    [CustomEditor(typeof(GameData))]
    public class LevelDataEditor : UnityEditor.Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var levelsData = (GameData)target;
            if (GUILayout.Button("Auto Mix Colors"))
            {
                foreach (LevelConfig levelConfig in levelsData.LevelConfigs)
                {
                    var mixedColor = new Color(0,0,0,0);
                    foreach (ProduceConfig produceConfig in levelConfig.ProduceData.ProduceConfigs)
                    {
                        mixedColor += produceConfig.Color;
                    }
                    mixedColor /= levelConfig.ProduceData.ProduceConfigs.Count;
                    levelConfig.SetTargetColor(mixedColor);
                }
            }
            EditorUtility.SetDirty(target);
        }
    }
}
