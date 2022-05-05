using System;
using Code.Produces;
using UnityEngine;

namespace Code.Data.Produce
{
    [Serializable]
    public struct ProduceConfig
    {
        [HideInInspector] public string Name;
        [field: SerializeField] public ProduceId Id { get; private set; }
        [field: SerializeField] public Color Color { get; private set; }
    }
}