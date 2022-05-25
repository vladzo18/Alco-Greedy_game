using System;
using Bottle;
using Game;
using Other;
using UnityEngine;

namespace UI.Game {
    
    public class HeadUpDisplayController : MonoBehaviour {

        [SerializeField] private HeadUpDisplayView _headUpDisplayView;
        [SerializeField] private PauseView _pauseView;
        [SerializeField] private BottleCatcher bottleCatcher;
        [SerializeField] private BarierHitter _barierHitter;

        private int _score;

        public event Action<int> ScoreChanged;
        
        private void Start() {
            _score = 0;
            
            bottleCatcher.OnBottleHit += OnBottleCatch;
            _barierHitter.BottleHit += BottleHit;
            _headUpDisplayView.Pause += OnPause;
            _headUpDisplayView.EmptyHealth += OnEmptyHealth;
            GameOverManager.Instance.GameRestart += OnGameRestrt;
        }
        
        private void OnDestroy() {
            bottleCatcher.OnBottleHit -= OnBottleCatch;
            _barierHitter.BottleHit -= BottleHit;
            _headUpDisplayView.Pause -= OnPause;
            _headUpDisplayView.EmptyHealth -= OnEmptyHealth;
            GameOverManager.Instance.GameRestart -= OnGameRestrt;
        }
        
        private void OnEmptyHealth() {
            GameOverManager.Instance.SetGameOver();
        }
        
        private void OnGameRestrt() {
            _score = 0;
            _headUpDisplayView.SetScore(_score);
            _headUpDisplayView.RestoreHealth();
        }
        
        private void OnPause() {
            _pauseView.ShowPauseView();
            PauseManager.Instance.SetPaused(true);
        }
        
        private void OnBottleCatch(BottleType bottleType) {
            _headUpDisplayView.SetScore(++_score);
            ScoreChanged?.Invoke(_score);
        }

        private void BottleHit() {
            _headUpDisplayView.DecreaseHealth();
        }
        
    }
    
}