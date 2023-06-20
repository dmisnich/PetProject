using Enums;
using UI.API;

namespace Windows.API
{
    public interface IWindowsService
    {
        void AddWindow(eWindowType type, AWindow window);
        void ShowWindow(eWindowType windowType);
        void HideAll();
    }
}