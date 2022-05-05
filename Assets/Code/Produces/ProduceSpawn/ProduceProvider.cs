using System.Collections.Generic;
using System.Linq;

namespace Code.Produces.ProduceSpawn
{
    public class ProduceProvider
    {
        private readonly ProduceFactory _factory;
        private List<Produce> _produce;

        public ProduceProvider(ProduceFactory factory)
        {
            _factory = factory;
            _produce = _factory.CreateAll();
        }

        public Produce GetProduct(ProduceId id)
        {
            return _produce.FirstOrDefault(HaveSameId) 
                   ?? _factory.Create(id);
            
            bool HaveSameId(Produce currentProduce) => 
                currentProduce.Id == id;
        }

        public IEnumerable<Produce> All()
        {
            return _produce;
        }
    }
}