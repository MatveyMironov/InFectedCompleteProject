using TMPro;
using UnityEngine;

namespace UISystem
{
    public class SingleTextLoadCapacityDisplayer : LoadCapacityDisplayer
    {
        [SerializeField] private TextMeshProUGUI loadCapacityText;

        private int _load;
        private int _capacity;

        protected override void DisplayCapacityImplementation(int capacity)
        {
            _capacity = capacity;
            DisplayLoadAndCapacity();
        }

        protected override void DisplayLoadImplementation(int load)
        {
            _load = load;
            DisplayLoadAndCapacity();
        }

        private void DisplayLoadAndCapacity()
        {
            loadCapacityText.text = $"{_load}/{_capacity}";
        }
    }
}