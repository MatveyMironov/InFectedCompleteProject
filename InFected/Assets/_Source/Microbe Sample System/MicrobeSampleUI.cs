using KeySystem;
using UnityEngine;
using UnityEngine.UI;

namespace MicrobeSampleSystem
{
    public class MicrobeSampleUI : KeyUI
    {
        [SerializeField] private Image microbeImage;

        public void DisplayKey(string name, Sprite microbeIcon)
        {
            nameText.text = name;
            microbeImage.sprite = microbeIcon;
        }
    }
}