using CustomUISystem;
using UnityEngine;

namespace HealthSystem
{
    public class HealthDisplayerMB : MonoBehaviour
    {
        [SerializeField] private ANumberDisplayerMB healthValueDisplayer;

        private Health _displayedHealth;

        private void OnDestroy()
        {
            HideHealth();
        }

        public void DisplayHealth(Health health)
        {
            HideHealth();
            _displayedHealth = health;
            _displayedHealth.OnHealthChanged += DisplayHealthValue;
            DisplayHealthValue();
        }

        public void HideHealth()
        {
            if (_displayedHealth == null) { return; }

            _displayedHealth.OnHealthChanged -= DisplayHealthValue;
            _displayedHealth = null;
        }

        public void DisplayHealthValue()
        {
            float healthValue = (float)_displayedHealth.CurrentHealth / _displayedHealth.MaxHealth;
            healthValueDisplayer.DisplayNumber(healthValue);
        }
    }
}