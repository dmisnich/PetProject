using Windows.API;
using Models;
using ServiceLocator;
using TMPro;
using UI.API;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SettingsPopup : AWindow
    {
        [SerializeField] private Button exitButton;
        [Space]
        [SerializeField] private Slider enemySpeedSlider;
        [SerializeField] private TMP_Text enemySpeedValue;
        [Space]
        [SerializeField] private Slider enemySpawnTimeSlider;
        [SerializeField] private TMP_Text enemySpawnTimeValue;

        private EnemiesModel _enemiesModel;
        private GameplayModel _gameplayModel;
        private IWindowsService _windowsService;

        private void Start()
        {
            _enemiesModel = DIContainer.Resolve<EnemiesModel>();
            _gameplayModel = DIContainer.Resolve<GameplayModel>();
            _windowsService = DIContainer.Resolve<IWindowsService>();
            
            exitButton.onClick.AddListener(Hide);
            enemySpeedSlider.onValueChanged.AddListener(EnemySpeedChanged);
            enemySpawnTimeSlider.onValueChanged.AddListener(EnemySpawnTimeChanged);
            SetPopup();
        }

        private void OnDestroy()
        {
            exitButton.onClick.RemoveListener(Hide);
            enemySpeedSlider.onValueChanged.RemoveListener(EnemySpeedChanged);
            enemySpawnTimeSlider.onValueChanged.RemoveListener(EnemySpawnTimeChanged);
        }

        private void OnEnable()
        {
            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
            if (!_gameplayModel.GameStarted)
                _windowsService.ShowWindow(typeof(StartGamePopup));
        }

        private void SetPopup()
        {
            enemySpeedValue.text = enemySpeedSlider.value.ToString();
            enemySpawnTimeValue.text = enemySpawnTimeSlider.value.ToString();
            _enemiesModel.SetEnemiesSpeed(enemySpeedSlider.value);
            _enemiesModel.SetSpawnDuration((int)enemySpawnTimeSlider.value);
        }

        private void EnemySpeedChanged(float value)
        {
            enemySpeedValue.text = value.ToString();
            _enemiesModel.SetEnemiesSpeed(value);
        }
        
        private void EnemySpawnTimeChanged(float value)
        {
            enemySpawnTimeValue.text = value.ToString();
            _enemiesModel.SetSpawnDuration((int)value);
        }
    }
}