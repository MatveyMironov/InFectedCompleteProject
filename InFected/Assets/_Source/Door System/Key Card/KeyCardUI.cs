using KeySystem;
using UnityEngine;
using UnityEngine.UI;

namespace DoorSystem
{
    public class KeyCardUI : KeyUI
    {
        [SerializeField] private Image colorIndicator;

        public void DisplayKey(string name, Color color)
        {
            nameText.text = name;
            colorIndicator.color = color;
        }
    }
}