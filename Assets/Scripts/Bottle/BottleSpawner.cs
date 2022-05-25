using System.Collections;
using Game;
using UI.Game;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Bottle {
    
    public class BottleSpawner : MonoBehaviour {
        
        [SerializeField] private float _timeDelay;
        [SerializeField] private ObjectPool.ObjectPool _bottlePool;
        [SerializeField] private float _delayBeforeStartSpawning = 2f;

        private float _oldButtlePositionX;

        public float TimeDelay {
            get => _timeDelay;
            set => _timeDelay = value;
        }
        
        private void Start() {
            StartCoroutine(SpawnBottle());
            
            GameOverManager.Instance.GameOver += OnGameOverEvent;
        }

        private void OnDestroy() {
            GameOverManager.Instance.GameOver -= OnGameOverEvent;
        }

        private void OnGameOverEvent() {
            ClearBottles();
        }

        private Vector2 GetRamdomPosition() {
            float buttlePositionX = Random.Range(-1, 2) * 2;

            while (buttlePositionX == _oldButtlePositionX) {
                buttlePositionX = Random.Range(-1, 2) * 2;
            }

            _oldButtlePositionX = buttlePositionX;
            
            return new Vector2(transform.position.x + buttlePositionX, transform.position.y);
        }

        private void ClearBottles() {
            Bottle[] bottles = gameObject.GetComponentsInChildren<Bottle>();
            
            foreach (Bottle bottleOfVodka in bottles) {
                if (bottleOfVodka.GetState() != BottleState.Droped) {
                    bottleOfVodka.ReturnToPool();
                }
            }
        }
        
        private IEnumerator SpawnBottle() {
            yield return new WaitForSeconds(_delayBeforeStartSpawning);
            
            while (true) {
                /*if (PauseManager.Instance.IsPaused) {
                    while (PauseManager.Instance.IsPaused) {
                        yield return null;
                    }
                    
                    yield return new WaitForSeconds(_delayBeforeStartSpawning);
                }*/
                
                yield return new WaitUntil(() => !PauseManager.Instance.IsPaused);
                
                GameObject bottle = _bottlePool.GetFreeObject();
                bottle.transform.SetPositionAndRotation(GetRamdomPosition(), Quaternion.identity);
                bottle.transform.SetParent(transform);
                
                yield return new WaitForSeconds(_timeDelay);
            }
            
        }
        
    }
    
}