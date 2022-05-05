using Code.Logic;
using Code.Produces;
using Code.Produces.ProduceSpawn;
using Code.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Blender
{
    public class BlenderView : MonoBehaviour, ICleanUp
    {
        [SerializeField] private Button _mixButton;
        [SerializeField] private Canvas _buttonCanvas;
        [Space]
        [SerializeField] private BlenderAnimator _blenderAnimator;
        [SerializeField] private BlenderStorage _blenderStorage;
        [SerializeField] private ProducePrefabSpawner _producePrefabAnimator;

        private Blender _blender;

        public void Init(Blender blender)
        {
            _blender = blender;
            _blender.ItemAdded += OnItemAdded;
            _blender.Mixed += OnMixed;
            _mixButton.onClick.AddListener(OnPressed);
            _buttonCanvas.worldCamera = Camera.main;
        }

        public void CleanUp()
        {
            _blender.CleanUp();
            _blenderAnimator.CleanUp();
            _buttonCanvas.enabled = true;
        }

        private void OnPressed() => 
            _blender.MixItems();

        private void OnMixed(Produce produce)
        {
            _blenderStorage.Clear();
            _blenderAnimator.Fill(produce.Color);
            _buttonCanvas.enabled = false;
        }

        private void OnItemAdded(Produce produce)
        {
            _blenderAnimator.PlayAddItem();
            _blenderStorage.AddItem(_producePrefabAnimator.Spawn(produce.Id));
        }
    }
}