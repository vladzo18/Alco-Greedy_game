using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ObjectPool {
    
    public class ObjectPool : MonoBehaviour {

        [SerializeField] private GameObject _prefab;

        private List<GameObject> _freeObjects;

        private void Awake() {
            _freeObjects = new List<GameObject>();
        }
        
        public GameObject GetFreeObject() {
            GameObject gameObject = null;
            
            if (_freeObjects.Count > 0) {
                gameObject = _freeObjects.Last();
                gameObject.SetActive(true);
                _freeObjects.Remove(gameObject);
            }
            
            gameObject ??= Instantiate(_prefab, transform);
            gameObject.GetComponent<IPoolable>().OnReturnToPool += returnToPool;

            return gameObject;
        }
        
        private void returnToPool(GameObject gameObject) {
            gameObject.SetActive(false);
            gameObject.GetComponent<IPoolable>().OnReturnToPool -= returnToPool;
            gameObject.GetComponent<IPoolable>().Transform.SetParent(transform);
            _freeObjects.Add(gameObject);
        }
        
    }
    
}