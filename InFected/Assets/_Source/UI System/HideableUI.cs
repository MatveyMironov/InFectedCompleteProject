using System;
using UnityEngine;

namespace UISystem
{
    public class HideableUI : MonoBehaviour
    {
        public bool IsUIShown { get; private set; }

        public event Action OnUIShown;
        public event Action OnUIHidden;

        public virtual void Show()
        {
            gameObject.SetActive(true);
            IsUIShown = true;
            OnUIShown?.Invoke();
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
            IsUIShown = false;
            OnUIHidden?.Invoke();
        }

    }
}