using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WeaponSystem
{
    public class WeaponDisplayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private Image iconImage;

        public void DisplayWeapon(string name, Sprite icon)
        {
            nameText.text = name;
            iconImage.sprite = icon;
        }
    }
}
