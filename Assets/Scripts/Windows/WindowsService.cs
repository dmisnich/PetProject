using System;
using System.Collections.Generic;
using Windows.API;
using UI.API;
using UnityEngine;

namespace Windows
{
    public class WindowsService : IWindowsService
    {
        private Dictionary<Type, AWindow> _windowDictionary = new Dictionary<Type, AWindow>();

        public void AddWindow(Type type, AWindow window)
        {
            _windowDictionary.Add(type, window);
        }

        public void ShowWindow(Type windowType)
        {
            if (_windowDictionary.ContainsKey(windowType))
            {
                HideAll();
                
                AWindow window = _windowDictionary[windowType];
                window.Show();
            }
            else
            {
                Debug.LogError("Window of type " + windowType.ToString() + " does not exist!");
            }
        }

        public void HideAll()
        {
            foreach (var window in _windowDictionary.Values)
                window.Hide();
        }
    }
}