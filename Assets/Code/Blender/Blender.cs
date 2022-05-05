using System;
using System.Collections.Generic;
using Code.Logic;
using Code.Produces;
using Code.UI;
using UnityEngine;

namespace Code.Blender
{
    public class Blender : ICleanUp
    {
        public event Action<Produce> ItemAdded;
        public event Action<Produce> Mixed;
        
        private readonly List<Produce> _produces;
        public Blender(List<Produce> produces)
        {
            _produces = produces;
        }
        
        public void AddItem(Produce produce)
        {
            _produces.Add(produce);
            ItemAdded?.Invoke(produce);
        }

        public void MixItems()
        {
            var color = new Color(0,0,0,0);
            if (_produces.Count != 0)
            {
                foreach (Produce produce in _produces)
                {
                    color += produce.Color;
                }

                color /= _produces.Count;
            }
            var mixedProduce = new Produce(ProduceId.Mixed, color);
            Mixed?.Invoke(mixedProduce);
        }

        public void CleanUp() => 
            _produces.Clear();
    }
}