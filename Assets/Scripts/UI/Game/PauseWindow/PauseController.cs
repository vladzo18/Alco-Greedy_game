using Game;
using UnityEngine;

namespace UI.Game {
    
    public class PauseController : MonoBehaviour {

        [SerializeField] private PauseView _pauseView;

        private void Start() {
            _pauseView.GoToMenu += OnGoToMenu;
            _pauseView.BackToGame += OnBackToGame;
        }

        private void OnDestroy() {
            _pauseView.GoToMenu -= OnGoToMenu;
            _pauseView.BackToGame -= OnBackToGame;
        }

        private void OnBackToGame() {
            _pauseView.HidePauseView();
            PauseManager.Instance.SetPaused(false);
        }
        
        private void OnGoToMenu() {
            Invoke(nameof(loadMenuScene), 0.25f);
            PauseManager.Instance.SetPaused(false);
        }

        private void loadMenuScene() => SceneLoader.LoadPreventScene();
        
    }
    
}