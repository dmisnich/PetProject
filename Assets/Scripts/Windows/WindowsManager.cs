using Windows.API;
using ServiceLocator;
using UI.API;
using UnityEngine;

namespace Windows
{
    public class WindowsManager : MonoBehaviour
    {
        [SerializeField] private AWindow[] _windows;

        private IWindowsService _windowsService = new WindowsService();

        private void Awake()
        {
            foreach (var window in _windows)
            {
                _windowsService.AddWindow(window.GetType(), window);
            }
            DIContainer.Register(_windowsService);
        }
    }
}