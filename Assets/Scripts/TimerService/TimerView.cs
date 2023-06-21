using System;
using Models;
using ServiceLocator;
using TimerService.API;
using UnityEngine;

namespace TimerService
{
    public class TimerView : MonoBehaviour
    {
        private ATimer _timer;
        private GameplayModel _gameplayModel;
        
        private void Start()
        {
            _timer = DIContainer.Resolve<ATimer>();
            _gameplayModel = DIContainer.Resolve<GameplayModel>();

            _gameplayModel.OnGameStarted += GameStarted;
            _gameplayModel.OnGameFinished += GameFinished;
        }
        
        private void OnDestroy()
        {
            _gameplayModel.OnGameStarted -= GameStarted;
            _gameplayModel.OnGameFinished -= GameFinished;
        }

        private void Update()
        {
            _timer.Tick();
        }

        private void GameStarted()
        {
            _timer.Reset();
            _timer.Start();
        }
        
        private void GameFinished()
        {
            _timer.Stop();
        }
    }
}