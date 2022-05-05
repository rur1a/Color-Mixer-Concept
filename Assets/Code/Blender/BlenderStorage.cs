using System.Collections.Generic;
using System.Linq;
using Code.Produces;
using UnityEngine;

namespace Code.Blender
{
    [RequireComponent(typeof(BoxCollider))]
    public class BlenderStorage : MonoBehaviour
    {
        private BoxCollider _boxCollider;
        private readonly List<ProducePrefabTag> _visualProduce = new List<ProducePrefabTag>();
        private readonly List<GameObject> _realProduce = new List<GameObject>();

        public void Clear()
        {
            foreach (GameObject producePrefab in _realProduce) 
                Destroy(producePrefab.gameObject);
            _visualProduce.Clear();
            _realProduce.Clear();
        }

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
            _boxCollider.isTrigger = true;
        }

        public void AddItem(GameObject item) => 
            _realProduce.Add(item);

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out ProducePrefabTag produce)) return;
            
            if(_visualProduce.Any(HasSameId))
                Destroy(produce.gameObject);
            else
                _visualProduce.Add(produce);
            
            bool HasSameId(ProducePrefabTag p) => 
                p.Id == produce.Id;
        }
    }
}