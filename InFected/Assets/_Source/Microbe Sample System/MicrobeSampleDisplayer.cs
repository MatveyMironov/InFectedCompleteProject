using KeySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MicrobeSampleSystem
{
    public class MicrobeSampleDisplayer : KeyDisplayer
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private Image microbeImage;

        public void DisplayKey(string name, Sprite microbeIcon)
        {
            nameText.text = name;
            microbeImage.sprite = microbeIcon;
        }
    }
}