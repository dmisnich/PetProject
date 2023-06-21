using System;
using Enums;
using UI.API;

namespace Windows.API
{
    public interface IWindowsService
    {
        void AddWindow(Type type, AWindow window);
        void ShowWindow(Type windowType);
        void HideAll();
    }
}