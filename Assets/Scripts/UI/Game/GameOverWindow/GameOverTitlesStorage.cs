using System.Collections.Generic;
using UnityEngine;

namespace UI.Game {
    [CreateAssetMenu(fileName = "GameOverTitles", menuName = "Storage/GameOverTitlesStorage")]
    public class GameOverTitlesStorage : ScriptableObject {
        
        [SerializeField, TextArea] private List<string> _gameOverLitles;

        public List<string> gameOverLitles => _gameOverLitles;
        
    }
}