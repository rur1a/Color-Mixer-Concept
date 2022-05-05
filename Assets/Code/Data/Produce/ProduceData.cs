using System.Collections.Generic;
using System.Linq;
using Code.Produces;
using UnityEngine;

namespace Code.Data.Produce
{
    [CreateAssetMenu(fileName = "Produce Data", menuName = "Static Data/Produce Data")]
    public class ProduceData : ScriptableObject
    {
        [SerializeField] private ProduceConfig[] _produceConfigs;
        public IReadOnlyList<ProduceConfig> ProduceConfigs => _produceConfigs;

        public ProduceConfig GetProductConfig(ProduceId id)
        {
            return _produceConfigs.Single(HaveSameId);

            bool HaveSameId(ProduceConfig config)
            {
                return config.Id == id;
            }
        }

        private void OnValidate()
        {
            for (var i = 0; i < _produceConfigs.Length; i++)
            {
                _produceConfigs[i].Name = _produceConfigs[i].Id.ToString();
            }
        }
        
        
    }
}