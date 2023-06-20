using Enums;

namespace UI.API
{
    public interface IWindow
    {
        eWindowType WindowType { get; }
        void Show();
        void Hide();
    }
}