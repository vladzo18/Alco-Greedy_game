using System;
using UnityEngine;

namespace Bottle {
    
    [Serializable]
    public class BottleTypeDescriptor {
        
        [SerializeField] private BottleType bottleType;
        [SerializeField] private string _bottleName;
        [SerializeField] private Sprite _bottleIcon;
        [SerializeField] private int _bottlePrice;
        [SerializeField, Range(0, 500f)] private int _bottleMass;
        
        public BottleType BottleType => bottleType;
        public string BottleName => _bottleName;
        public Sprite BottleIcon => _bottleIcon;
        public int BottleMass => _bottleMass;
        public int BottlePrice => _bottlePrice;
        
    }
    
}