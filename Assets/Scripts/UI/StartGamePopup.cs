using Enums;
using Models;
using ServiceLocator;
using UI.API;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StartGamePopup : AWindow
    {
        public override eWindowType WindowType => eWindowType.StartGamePanel;
        
        [SerializeField] private Button _playButton;
        
        private GameplayModel _gameplayModel;
        
        private void Start()
        {
            _gameplayModel = DIContainer.Resolve<GameplayModel>();
            _playButton.onClick.AddListener(OnClickPlayButton);
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveListener(OnClickPlayButton);
        }

        private void OnClickPlayButton()
        {
            _gameplayModel.StartGame();
            Hide();
        }
    }
}