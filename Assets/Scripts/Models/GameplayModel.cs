using System;

namespace Models
{
    public class GameplayModel
    {
        public event Action OnGameStarted;
        public event Action OnGameFinished;
        public bool GameStarted => _gameplayData.GameStarted;
        
        private GameplayData _gameplayData = new GameplayData();

        public void StartGame()
        {
            _gameplayData.GameStarted = true;
            OnGameStarted?.Invoke();
        }

        public void FinishGame()
        {
            _gameplayData.GameStarted = false;
            OnGameFinished?.Invoke();
        }
    }

    public class GameplayData
    {
        public bool GameStarted;
    }
}