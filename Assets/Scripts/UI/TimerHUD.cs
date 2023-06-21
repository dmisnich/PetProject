using Models;
using ServiceLocator;
using TimerService.API;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TimerHUD : MonoBehaviour
    {
        [SerializeField] private TMP_Text timer;

        private ATimer _timer;
        private GameplayModel _gameplayModel;

        private const int StartValue = 0;
        
        private void Start()
        {
            _timer = DIContainer.Resolve<ATimer>();
            _gameplayModel = DIContainer.Resolve<GameplayModel>();
            _timer.OnTimerTick += TimerTicked;
            _gameplayModel.OnGameStarted += GameStarted;
            TimerTicked(StartValue);
        }

        private void OnDestroy()
        {
            _timer.OnTimerTick -= TimerTicked;
            _gameplayModel.OnGameStarted -= GameStarted;
        }

        private void TimerTicked(int time)
        {
            timer.text = $"Time: {time} sec";
        }
        
        private void GameStarted()
        {
            TimerTicked(StartValue);
        }
    }
}