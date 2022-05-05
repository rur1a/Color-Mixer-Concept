using Code.Data.Produce;
using UnityEngine;

namespace Code.Produces.ProduceSpawn
{
    public class ProducePrefabSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private ProducePrefabProvider _producePrefabProvider;

        public GameObject Spawn(ProduceId produceId) => 
            Instantiate(_producePrefabProvider.ProducePrefabs[produceId], _spawnPoint.position, Quaternion.identity);
    }
}