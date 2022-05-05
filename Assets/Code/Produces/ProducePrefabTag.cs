using UnityEngine;

namespace Code.Produces
{
    public class ProducePrefabTag : MonoBehaviour
    {
        [field: SerializeField] public ProduceId Id { get; private set; }
    }   
}