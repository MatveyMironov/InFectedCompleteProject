using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class BarLoadCapacityDisplayer : LoadCapacityDisplayer
    {
        [SerializeField] private Image barFillImage;

        private int _capacity;

        protected override void DisplayCapacityImplementation(int capacity)
        {
            _capacity = capacity;
        }

        protected override void DisplayLoadImplementation(int load)
        {
            barFillImage.fillAmount = (float)load / _capacity;
        }
    }
}