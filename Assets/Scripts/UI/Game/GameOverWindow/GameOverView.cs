using System;
using Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Game {
    
    public class GameOverView : MonoBehaviour {

        [SerializeField] private Text _text;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _backToMenuButton;
        [SerializeField] private Canvas _gameOverCanvas;
        [SerializeField] private Animator _restartButtonAnimator;
        [SerializeField] private Animator _backToMenuButtonAnimator;

        public event Action Restart;
        public event Action GoToMenu;

        private void Start() {
            _restartButton.onClick.AddListener(OnRestart);
            _backToMenuButton.onClick.AddListener(OnGoToMenu);
        }
        
        private void OnDestroy() {
            _restartButton.onClick.RemoveListener(OnRestart);
            _backToMenuButton.onClick.RemoveListener(OnGoToMenu);
        }

        public void SetGameOverMessage(string text) {
            _text.text = text;
        }

        public void ShowGameOverView() => _gameOverCanvas.enabled = true;
        public void HideGameOverView() => _gameOverCanvas.enabled = false;
        
        private void OnRestart() {
            Invoke(nameof(InvokeRestart), 0.35f);
            GameSound.Instance.PlayOnClickSound();
            _restartButtonAnimator.SetTrigger("Press");
        }
        
        private void OnGoToMenu() {
            Invoke(nameof(InvokeGoToMenu), 0.35f);
            GameSound.Instance.PlayOnClickSound();
            _backToMenuButtonAnimator.SetTrigger("Press");
        }
        
        private void InvokeRestart() => Restart?.Invoke();
        private void InvokeGoToMenu() => GoToMenu?.Invoke();
        
    }
    
}


