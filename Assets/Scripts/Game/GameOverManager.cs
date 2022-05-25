using System;

namespace Game {

    public class GameOverManager {
        
        private static GameOverManager _instance;
        public static GameOverManager Instance => _instance ??= new GameOverManager();
        
        public event Action GameOver;
        public event Action GameRestart;

        public void SetGameOver() => GameOver?.Invoke();
        public void SetGameRestart() => GameRestart?.Invoke();

    }
    
}