using Game;
using UnityEngine;

namespace UI.Game {
    
    public class ScoreComplexityChanger : MonoBehaviour {

        [SerializeField] private GameComplexity _gameComplexity;
        [SerializeField] private HeadUpDisplayController _headUpDisplayController;

        private int _step;
        private int _counter;

        private void Start() {
            _step = 5;
            _headUpDisplayController.ScoreChanged += OnScoreChanged;
        }
        
        private void OnDestroy() {
            _headUpDisplayController.ScoreChanged -= OnScoreChanged;
        }

        private void DecreaseStep(int valuue) {
            if (_counter >= valuue) {
                _step--;
                _counter = 0;
            }
        }
        
        private void OnScoreChanged(int score) {
            if (score % _step == 0) {
                _gameComplexity.MoveInComplexity();
                
                DecreaseStep(7);
                DecreaseStep(15);
                DecreaseStep(25);
                
                _counter++;
            }
        }
        
    }

}