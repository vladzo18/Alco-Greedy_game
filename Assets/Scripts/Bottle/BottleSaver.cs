using System.Collections.Generic;
using Game;
using Other;
using Serialization;
using UI.Game;
using UnityEngine;

namespace Bottle {

    public class BottleSaver : MonoBehaviour, IPauseHandler {

        [SerializeField] private BottleCatcher bottleCatcher;
        
        private Dictionary<BottleType, int> _bottlesAmount;
        
        public void SetPaused(bool isPaused) {
            if (isPaused) {
                Save();
            }
        }
        
        private void Start() {
            _bottlesAmount = new Dictionary<BottleType, int>();
            
            bottleCatcher.OnBottleHit += OnBottleHitHandler;
            GameOverManager.Instance.GameOver += Save;
            PauseManager.Instance.Register(this);
        }

        private void OnDestroy() {
            bottleCatcher.OnBottleHit -= OnBottleHitHandler;
            GameOverManager.Instance.GameOver -= Save;
            PauseManager.Instance.UnRegister(this);
        }

        private void OnBottleHitHandler(BottleType bottleType) {
            if (_bottlesAmount.ContainsKey(bottleType)) {
                _bottlesAmount[bottleType] +=  1;
            } else {
                _bottlesAmount.Add(bottleType, 1);
            }
        }
        
        private void Save() {
            Dictionary<BottleType, int> bottlesAmount = Serializator.DeserializeData<Dictionary<BottleType, int>>(StringLiterals.SavePathToBottlesAmount);
            
            if (_bottlesAmount.Count > 0) {
                if (bottlesAmount != null) {
                    foreach (var item in bottlesAmount) {
                        if (_bottlesAmount.ContainsKey(item.Key)) {
                            _bottlesAmount[item.Key] += item.Value;
                        } else {
                            _bottlesAmount.Add(item.Key, item.Value);
                        }
                    }
                }
                
                Serializator.SerializeData(_bottlesAmount, StringLiterals.SavePathToBottlesAmount);
            }
        }
        
    }
    
}