using System.Collections.Generic;
using System.Linq;
using Code.Blender;
using Code.Data;
using Code.Data.Game;
using Code.Data.Produce;
using Code.Logic;
using Code.Produces;
using Code.Produces.ProduceSpawn;
using Code.UI;
using UnityEngine;

namespace Code.Infrastructure
{
    public class Game
    {
        private int _currentLevelIndex = 0;
        private GameData _gameData;
        private GameFactory _gameFactory;
        private ColorAnalyzer _colorAnalyzer;
        private Score _score;
        private UIMediator _uiMediator;
        private Material _targetMaterial;
        private Blender.Blender _blender;
        private List<ICleanUp> _cleanUps;
        private LevelConfig LevelConfig => _gameData.LevelConfigs.ElementAt(_currentLevelIndex);

        public Game(GameData gameData, GameFactory gameFactory, Material targetMaterial)
        {
            CreateBaseElements(gameData, gameFactory);
            SetupTargetMaterial(targetMaterial);
            Subscribe();
        }

        private void InitNewLevel()
        {
            foreach (ICleanUp cleanUp in _cleanUps) 
                cleanUp.CleanUp();
            
            _targetMaterial.color = LevelConfig.TargetColor;
            var produceProvider = _gameFactory.CreateProduceProvide(LevelConfig);
            var fridge = _gameFactory.CreateFridge(LevelConfig, produceProvider, _blender);
            _uiMediator.UpdateFridge(fridge, produceProvider);
        }

        private void OnLevelEnded(Produce produce)
        {
            float difference = _colorAnalyzer.CalculateDifference(
                LevelConfig.TargetColor, produce.Color);
            
            _score.SetResult((int)(100-difference));
            _uiMediator.HideFridge();

            if (difference > _gameData.MaxDifference)
            {
                _uiMediator.ShowLooseScreen();
            }
            else
            {
                _uiMediator.ShowWinScreen();
                IncreaseIndex();
            }
        }

        private void IncreaseIndex()
        {
            _currentLevelIndex++;
            if (_currentLevelIndex == _gameData.LevelConfigs.Count)
                _currentLevelIndex = 0;
        }

        private void SetupTargetMaterial(Material targetMaterial)
        {
            _targetMaterial = targetMaterial;
            _targetMaterial.color = LevelConfig.TargetColor;
        }

        private void CreateBaseElements(GameData gameData, GameFactory gameFactory)
        {
            _gameData = gameData;
            _gameFactory = gameFactory;
            _colorAnalyzer = new ColorAnalyzer();
            _blender = new Blender.Blender(new List<Produce>());
            var blenderView = _gameFactory.CreateBlender(_blender);
            var produceProvider = _gameFactory.CreateProduceProvide(LevelConfig);
            var fridge = _gameFactory.CreateFridge(LevelConfig, produceProvider, _blender);
            _score = new Score();
            _uiMediator = _gameFactory.CreateUI(produceProvider, fridge, _score, LevelConfig.TargetColor);

            _cleanUps = new List<ICleanUp>()
            {
                blenderView, _uiMediator,
            };
        }

        private void Subscribe()
        {
            _blender.Mixed += OnLevelEnded;
            _uiMediator.WinScreen.Pressed += InitNewLevel;
            _uiMediator.LooseScreen.Pressed += InitNewLevel;
        }
    }
}