using System;
using System.Collections.Generic;
using Code.Logic;
using Code.Produces;
using Code.Produces.ProduceSpawn;
using UnityEngine;

namespace Code.UI
{
    public class FridgeView : MonoBehaviour, ICleanUp
    {
        [SerializeField] private ProduceView _produceViewPrefab;
        [SerializeField] private Transform _root;

        private List<ProduceView> _produceViews;
        private Fridge _fridge;

        public void Init(IEnumerable<Produce> produce, Fridge fridge)
        {
            _fridge = fridge;
            _produceViews = new List<ProduceView>();
            foreach (Produce produceElement in produce)
            {
                ProduceView produceView = Instantiate(_produceViewPrefab, _root);
                produceView.Init(produceElement, _fridge);
                _produceViews.Add(produceView);
            }
        }

        public void CleanUp()
        {
            _fridge.CleanUp();
            foreach (ProduceView produceView in _produceViews)
            {
                produceView.CleanUp();
                Destroy(produceView.gameObject);
            }
        }
    }
}