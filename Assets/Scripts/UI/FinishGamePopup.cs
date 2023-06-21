using Models;
using ServiceLocator;
using TimerService.API;
using TMPro;
using UI.API;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FinishGamePopup : AWindow
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private TMP_Text time;
        
        private GameplayModel _gameplayModel;
        private ATimer _timer;
        private bool _isInitialized;
        
        private void Start()
        {
            _gameplayModel = DIContainer.Resolve<GameplayModel>();
            _timer = DIContainer.Resolve<ATimer>();
            restartButton.onClick.AddListener(OnClickPlayButton);

            _isInitialized = true;
            SetPopup();
        }

        private void OnDestroy()
        {
            restartButton.onClick.RemoveListener(OnClickPlayButton);
        }

        private void OnEnable()
        {
            if (_isInitialized)
                SetPopup();
        }

        private void SetPopup()
        {
            time.text = $"Alive time: {(int)_timer.ElapsedTime} sec";
        }

        private void OnClickPlayButton()
        {
            _gameplayModel.StartGame();
            Hide();
        }
    }
}