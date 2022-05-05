using System.Collections.Generic;
using Code.Data;
using Code.Data.Produce;

namespace Code.Produces.ProduceSpawn
{
    public class ProduceFactory
    {
        private ProduceData _data;

        public ProduceFactory(ProduceData data)
        {
            _data = data;
        }

        public Produce Create(ProduceId id)
        {
            ProduceConfig config = _data.GetProductConfig(id);
            var produce = new Produce(config);
            return produce;
        }

        public List<Produce> CreateAll()
        {
            var products = new List<Produce>();

            foreach (var config in _data.ProduceConfigs)
            {
                var product = new Produce(config);
                products.Add(product);
            }
            return products;

        }
    }
}