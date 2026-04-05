using KeySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DoorSystem
{
    public class KeyCardUI : KeyDisplayer
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private Image colorIndicator;

        public void DisplayKey(string name, Color color)
        {
            nameText.text = name;
            colorIndicator.color = color;
        }
    }
}