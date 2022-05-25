using Game;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UI.Game {
    
    public class GameOverController : MonoBehaviour {
        
        [SerializeField] private GameOverView _gameOverView;
        [SerializeField] private GameOverTitlesStorage _storage;
        [SerializeField] private float _timeDelayBeforeShowing;

        private int _lastTitleTextElementIndex = 0;

        private void Start() {
            _gameOverView.Restart += OnRestart;
            _gameOverView.GoToMenu += OnGoToMenu;
            GameOverManager.Instance.GameOver += OnGameOver;
        }
        
        private void OnDestroy() {
            _gameOverView.Restart -= OnRestart;
            _gameOverView.GoToMenu -= OnGoToMenu;
            GameOverManager.Instance.GameOver -= OnGameOver;
        }
        
        private void OnGameOver() {
            RefreshTile();
            PauseManager.Instance.SetPaused(true);
            Invoke(nameof(InvokeShowGameOverView), _timeDelayBeforeShowing);
        }

        private void InvokeShowGameOverView() => _gameOverView.ShowGameOverView();
        
        private void OnRestart() {
            _gameOverView.HideGameOverView();
            PauseManager.Instance.SetPaused(false);
            GameOverManager.Instance.SetGameRestart();
        }

        private void OnGoToMenu() {
            PauseManager.Instance.SetPaused(false);
            SceneLoader.LoadPreventScene();
        }
        
        private void RefreshTile() {
            int elementIndex = 0;
            
            while (elementIndex == _lastTitleTextElementIndex) {
                elementIndex = Random.Range(0, _storage.gameOverLitles.Count);
            }
            
            _gameOverView.SetGameOverMessage(_storage.gameOverLitles[elementIndex]);
            _lastTitleTextElementIndex = elementIndex;
        }
        
    }
    
}