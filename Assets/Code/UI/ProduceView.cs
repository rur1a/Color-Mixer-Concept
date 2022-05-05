using Code.Data.Produce;
using Code.Logic;
using Code.Produces;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class ProduceView : MonoBehaviour
    {
        [SerializeField] private Button _takeButton;
        [SerializeField] private ProducePrefabProvider _producePrefabProvider;
        [SerializeField] private Transform _prefabRoot;

        private Fridge _fridge;
        private Produce _produce;

        public void Init(Produce produce, Fridge fridge)
        {
            _produce = produce;
            _fridge = fridge;
            Instantiate(_producePrefabProvider.ProducePrefabs[produce.Id], _prefabRoot);
            _takeButton.onClick.AddListener(OnPressed);
        }

        public void CleanUp() => 
            _takeButton.onClick.RemoveListener(OnPressed);

        private void OnPressed() => 
            _fridge.Take(_produce.Id);
    }
}