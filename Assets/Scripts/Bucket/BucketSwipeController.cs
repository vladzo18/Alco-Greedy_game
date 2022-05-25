using Game;
using Other;
using UI.Game;
using UnityEngine;

namespace Bucket {
    
    public class BucketSwipeController : MonoBehaviour, IPauseHandler {

        [SerializeField] private BucketMover _bucketMover;
        [SerializeField] private SwipeDetector _swipeDetector;
        
        private bool _canControll;

        private void Start() {
            _canControll = true;
            
            _swipeDetector.RightSwipe += OnRightSwipe;
            _swipeDetector.LeftSwipe += OnLeftSwipe;
            GameOverManager.Instance.GameOver += OnGameOver;
            GameOverManager.Instance.GameRestart += OnGameRestart;
            PauseManager.Instance.Register(this);
        }

        private void OnDestroy() {
            _swipeDetector.RightSwipe -= OnRightSwipe;
            _swipeDetector.LeftSwipe -= OnLeftSwipe;
            GameOverManager.Instance.GameOver -= OnGameOver;
            GameOverManager.Instance.GameRestart -= OnGameRestart;
            PauseManager.Instance.UnRegister(this);
        }

        private void OnRightSwipe() {
            if (_canControll) {
                _bucketMover.MoveRight();
            }
        }

        private void OnLeftSwipe() {
            if (_canControll) {
                _bucketMover.MoveLeft();
            }
        }

        private void OnGameOver() {
            _canControll = false;
        }
        
        private void OnGameRestart() {
            _canControll = true;
        }

        public void SetPaused(bool isPaused) {
            _canControll = !isPaused;
        }
        
    }
    
}