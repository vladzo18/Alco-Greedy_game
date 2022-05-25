using System;
using UnityEngine;

namespace ObjectPool {
    
    public interface IPoolable {
       
        Transform Transform { get; }
        event Action<GameObject> OnReturnToPool;
        void ReturnToPool();
        
    }
    
}