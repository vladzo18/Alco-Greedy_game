using System;
using Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Game {
    
    public class PauseView : MonoBehaviour {
        
        [SerializeField] private Button _toMenuButton;
        [SerializeField] private Button _backToGameButton;
        [SerializeField] private Canvas _pauseCanvas;
        [SerializeField] private Animator _menuButtonAnimator;
        [SerializeField] private Animator _backToGameButtonAnimator;

        public event Action GoToMenu;
        public event Action BackToGame;

        public void ShowPauseView() => _pauseCanvas.enabled = true;
        public void HidePauseView() => _pauseCanvas.enabled = false;
        
        private void Start() {
            _toMenuButton.onClick.AddListener(OnGoToMenu);
            _backToGameButton.onClick.AddListener(OnBackToGame);
        }

        private void OnDestroy() {
            _toMenuButton.onClick.RemoveListener(OnGoToMenu);
            _backToGameButton.onClick.RemoveListener(OnBackToGame);
        }

        private void OnGoToMenu() {
            Invoke(nameof(InvokeGoToMenu), 0.35f);
            GameSound.Instance.PlayOnClickSound();
            _menuButtonAnimator.SetTrigger("Press");
        }

        private void OnBackToGame() {
            Invoke(nameof(InvokeBackToGame), 0.35f);
            GameSound.Instance.PlayOnClickSound();
            _backToGameButtonAnimator.SetTrigger("Press");
        }
        
        private void InvokeGoToMenu() => GoToMenu?.Invoke();
        private void InvokeBackToGame() => BackToGame?.Invoke();

    }
    
}