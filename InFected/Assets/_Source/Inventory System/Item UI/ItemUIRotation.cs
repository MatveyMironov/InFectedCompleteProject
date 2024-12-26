using UnityEngine;

namespace InventorySystem
{
    public class ItemUIRotation : MonoBehaviour
    {
        [SerializeField] private RectTransform iconImageTransform;
        [SerializeField] private RectTransform itemImageTransform;

        private Vector2 _iconImageDefaultSize;
        private Vector2 _iconImageAlternativeSize;
        private Vector2 _iconImageDefaultPosition;
        private Vector2 _iconImageAlternativePosition;

        private void Awake()
        {
            _iconImageDefaultSize = iconImageTransform.sizeDelta;
            _iconImageAlternativeSize = new(_iconImageDefaultSize.y, _iconImageDefaultSize.x);

            _iconImageDefaultPosition = iconImageTransform.localPosition;
            _iconImageAlternativePosition = new(_iconImageDefaultPosition.y, _iconImageDefaultPosition.x);
        }

        public void RotateToAlternative()
        {
            itemImageTransform.rotation = Quaternion.Euler(0f, 0f, -90.0f);
            iconImageTransform.sizeDelta = _iconImageAlternativeSize;
            iconImageTransform.localPosition = _iconImageAlternativePosition;
        }

        public void RotateToDefault()
        {
            itemImageTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
            iconImageTransform.sizeDelta = _iconImageDefaultSize;
            iconImageTransform.localPosition = _iconImageDefaultPosition;
        }
    }
}