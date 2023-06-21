using Windows.API;
using ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SettingsPanel : MonoBehaviour
    {
        [SerializeField] private Button settingsButton;

        private IWindowsService _windowsService;
        
        private void Start()
        {
            _windowsService = DIContainer.Resolve<IWindowsService>();
            settingsButton.onClick.AddListener(OpenSettingsPopup);
        }

        private void OnDestroy()
        {
            settingsButton.onClick.RemoveListener(OpenSettingsPopup);
        }

        private void OpenSettingsPopup()
        {
            _windowsService.ShowWindow(typeof(SettingsPopup));
        }
    }
}