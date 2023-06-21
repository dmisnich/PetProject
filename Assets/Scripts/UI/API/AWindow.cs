using Enums;
using UnityEngine;

namespace UI.API
{
    public abstract class AWindow : MonoBehaviour, IWindow
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}