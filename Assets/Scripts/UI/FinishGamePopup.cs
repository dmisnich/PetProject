using Models;
using ServiceLocator;
using UI.API;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FinishGamePopup : AWindow
    {
        [SerializeField] private Button restartButton;
        
        private GameplayModel _gameplayModel;
        
        private void Start()
        {
            _gameplayModel = DIContainer.Resolve<GameplayModel>();
            restartButton.onClick.AddListener(OnClickPlayButton);
        }

        private void OnDestroy()
        {
            restartButton.onClick.RemoveListener(OnClickPlayButton);
        }

        private void OnClickPlayButton()
        {
            _gameplayModel.StartGame();
            Hide();
        }
    }
}