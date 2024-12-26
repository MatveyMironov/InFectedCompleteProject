using KeySystem;
using UnityEngine;

namespace DoorSystem
{
    [CreateAssetMenu(fileName = "NewKeyCard", menuName = "Keys/Key Card")]
    public class KeyCardDataSO : KeyDataSO
    {
        [SerializeField] private Color color;
        [SerializeField] private KeyCardUI keyCardUIPrefab;

        public Color Color { get => color; }

        public override KeyUI CreateKeyUI(Transform parent)
        {
            KeyCardUI keyCardUI = Instantiate(keyCardUIPrefab, parent);
            keyCardUI.DisplayKey(keyName, color);
            return keyCardUI;
        }
    }
}
