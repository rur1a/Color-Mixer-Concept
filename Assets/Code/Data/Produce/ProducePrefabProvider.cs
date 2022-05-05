using System;
using System.Collections.Generic;
using System.Linq;
using Code.Produces;
using UnityEngine;

namespace Code.Data.Produce
{
    [CreateAssetMenu(fileName = "Produce Prefab Provider", menuName = "Static Data/Produce Prefab Provider")]
    public class ProducePrefabProvider : ScriptableObject
    {
        [SerializeField] private List<ProducePrefabPair> _producePrefabs;
        public IReadOnlyDictionary<ProduceId, GameObject> ProducePrefabs { get; private set; }
        private void OnValidate() => ProducePrefabs = _producePrefabs.ToDictionary(key => key.Id, value => value.Prefab);
    }

    [Serializable]
    public class ProducePrefabPair
    {
        [field: SerializeField] public ProduceId Id { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}