using Code.Data;
using Code.Data.Produce;
using Code.Produces.ProduceSpawn;
using Code.UI;
using UnityEngine;

namespace Code.Produces
{
    public class Produce
    {
        public Produce(ProduceConfig config)
        {
            Id = config.Id;
            Color = config.Color;
        }

        public Produce(ProduceId id, Color color)
        {
            Id = id;
            Color = color;
        }

        public ProduceId Id { get; private set; }
        public Color Color { get; private set; }
    }
}