using System;
using System.Collections.Generic;
using Code.Blender;
using Code.Data.Game;
using Code.Data.Produce;
using Code.Logic;
using Code.Produces;
using Code.Produces.ProduceSpawn;
using Code.UI;
using UnityEngine;

namespace Code.Infrastructure
{
    public class GameFactory : MonoBehaviour
    {
        [SerializeField] private Canvas _canvasPrefab;
        [SerializeField] private FridgeView _fridgeViewPrefab;
        [SerializeField] private ScoreView _scoreViewPrefab;
        [SerializeField] private EndLevelMessage _winScreenPrefab;
        [SerializeField] private EndLevelMessage _looseScreenPrefab;
        
        [Space, SerializeField] private Transform _blenderPosition;
        [SerializeField] private BlenderView blenderViewPrefab;

        public UI.UIMediator CreateUI(ProduceProvider produceProvider, Fridge fridge, Score score, Color targetColor)
        {
            Canvas canvas = Instantiate(_canvasPrefab);
            FridgeView fridgeView = CreateFridgeView(produceProvider, fridge, canvas.transform);
            ScoreView scoreView = CreateScoreView(score, canvas.transform);
            EndLevelMessage winScreen = Instantiate(_winScreenPrefab, canvas.transform);
            EndLevelMessage looseScreen = Instantiate(_looseScreenPrefab, canvas.transform);
            var ui = new UI.UIMediator(fridgeView, scoreView, winScreen, looseScreen);
            return ui;
        }

        public BlenderView CreateBlender(Blender.Blender blender)
        {
            BlenderView blenderView = Instantiate(blenderViewPrefab, _blenderPosition.position, blenderViewPrefab.transform.rotation);
            blenderView.Init(blender);
            return blenderView;
        }
        
        private ScoreView CreateScoreView(Score score, Transform root)
        {
            ScoreView scoreView = Instantiate(_scoreViewPrefab, root);
            scoreView.Init(score);
            return scoreView;
        }

        public Fridge CreateFridge(LevelConfig levelConfig, ProduceProvider produceProvider, Blender.Blender blender)
        {
            
            var catalog = new List<ProduceId>();
            foreach (ProduceConfig produceConfig in levelConfig.ProduceData.ProduceConfigs)
            {
                catalog.Add(produceConfig.Id);
            }
            return new Fridge(produceProvider, blender, catalog);
        }
        
        private FridgeView CreateFridgeView(ProduceProvider produceProvider, Fridge fridge, Transform root)
        {
            FridgeView fridgeView = Instantiate(_fridgeViewPrefab, root);
            fridgeView.Init(produceProvider.All(), fridge);
            return fridgeView;
        }

        public ProduceProvider CreateProduceProvide(LevelConfig levelConfig)
        {
            var produceFactory = new ProduceFactory(levelConfig.ProduceData);
            var produceProvider = new ProduceProvider(produceFactory);
            return produceProvider;
        }
    }
}