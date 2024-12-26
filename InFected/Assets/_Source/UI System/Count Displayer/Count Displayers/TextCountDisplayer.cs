using TMPro;
using UnityEngine;

namespace UISystem
{
    public class TextCountDisplayer : CountDisplayer
    {
        [SerializeField] private TextMeshProUGUI countText;

        protected override void DisplayImplementation(int count)
        {
            countText.text = count.ToString();
        }
    }
}