using System;
using Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Game {
    
    public class HeadUpDisplayView : MonoBehaviour {

        [SerializeField] private Text _scoreText;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private HealthBar _healthBar;

        public event Action Pause;
        public event Action EmptyHealth;
        
        public void SetScore(int value) {
            _scoreText.text = value.ToString();
        }

        public void RestoreHealth() {
            _healthBar.RestoreHealth();
        }

        public void DecreaseHealth() {
            _healthBar.DecreaseHealth();
        }
        
        private void Start() {
            _pauseButton.onClick.AddListener(OnPause);
            _healthBar.EmptyHealth += OnEmptyHealth;
        }

        private void OnDestroy() {
            _pauseButton.onClick.RemoveListener(OnPause);
            _healthBar.EmptyHealth -= OnEmptyHealth;
        }

        private void OnPause() {
            GameSound.Instance.PlayOnClickSound();
            Pause?.Invoke();
        }

        private void OnEmptyHealth() {
            EmptyHealth?.Invoke();
        }
        
    }
    
}