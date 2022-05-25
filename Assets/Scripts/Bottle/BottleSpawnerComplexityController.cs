using Game;
using UnityEngine;

namespace Bottle {
    public class BottleSpawnerComplexityController : MonoBehaviour, IComplexityHandler {
        
        [SerializeField] private GameComplexity _gameComplexity;
        [SerializeField] private BottleSpawner _bottleSpawner;

        private void Start() {
            _gameComplexity.Register(this);
        }

        private void OnDestroy() {
            _gameComplexity.UnRegister(this);
        }

        public void SetComplexity(float complexity) {
            _bottleSpawner.TimeDelay -= complexity;
        }
        
    }
}