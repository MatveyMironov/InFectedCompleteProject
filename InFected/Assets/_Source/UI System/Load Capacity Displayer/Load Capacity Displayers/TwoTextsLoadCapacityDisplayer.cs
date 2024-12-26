using TMPro;
using UnityEngine;

namespace UISystem
{
    public class TwoTextsLoadCapacityDisplayer : LoadCapacityDisplayer
    {
        [SerializeField] private TextMeshProUGUI loadText;
        [SerializeField] private TextMeshProUGUI capacityText;

        protected override void DisplayCapacityImplementation(int capacity)
        {
            capacityText.text = capacity.ToString();
        }

        protected override void DisplayLoadImplementation(int load)
        {
            loadText.text = load.ToString();
        }
    }
}
