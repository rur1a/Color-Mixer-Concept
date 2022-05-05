using System;
using Code.Data;
using Code.Data.Game;
using UnityEngine;

namespace Code.Infrastructure
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;
        [SerializeField] private GameFactory gameFactory;
        [SerializeField] private Material _targetMaterial;
         private void Awake()
        {
            var game = new Game(_gameData, gameFactory, _targetMaterial);
        }
    }
}