using System;
using UnityEngine;

namespace Bucket {
    
    [Serializable]
    public class BucketTypeDescriptor {

        [SerializeField] private BucketType _type;
        [SerializeField] private Sprite _image;
        [SerializeField] private string _name;
        [SerializeField] private int _price;
        
        public BucketType Type => _type;
        public Sprite Image => _image;
        public string Name => _name;
        public int Price => _price;
        
    }
    
}