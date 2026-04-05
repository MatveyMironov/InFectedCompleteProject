using KeySystem;
using UnityEngine;

namespace DoorSystem
{
    [CreateAssetMenu(fileName = "NewKeyCard", menuName = "Keys/Key Card")]
    public class KeyCardDataSO : KeyConfiguration
    {
        [SerializeField] private Color color;
        [SerializeField] private KeyCardUI keyCardUIPrefab;

        public Color Color { get => color; }

        public override KeyDisplayer CreateKeyDisplayer()
        {
            KeyCardUI keyCardUI = Instantiate(keyCardUIPrefab);
            keyCardUI.DisplayKey(keyName, color);
            return keyCardUI;
        }
    }
}
