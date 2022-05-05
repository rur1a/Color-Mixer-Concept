using System;
using System.Collections.Generic;
using Code.Produces;
using Code.Produces.ProduceSpawn;
using Code.UI;

namespace Code.Logic
{
    public class Fridge : ICleanUp
    {
        public event Action<Produce> ProduceTaken;

        private readonly ProduceProvider _produceProvider;
        private readonly Blender.Blender _blender;
        private readonly List<ProduceId> _catalog;
        
        public Fridge(ProduceProvider produceProvider, Blender.Blender blender, List<ProduceId> catalog)
        {
            _produceProvider = produceProvider;
            _blender = blender;
            _catalog = catalog;
        }
        
        public void Take(ProduceId id)
        {
            Produce produce = _produceProvider.GetProduct(id);
            _blender.AddItem(produce);
            ProduceTaken?.Invoke(produce);
        }

        public void CleanUp() => 
            _catalog.Clear();
    }
}