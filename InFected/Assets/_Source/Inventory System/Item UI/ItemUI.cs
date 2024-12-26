using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventorySystem
{
    public class ItemUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI countText;
        [SerializeField] private ItemUIRotation itemUIRotation;

        public event Action OnDragBegun;
        public event Action OnDragEnded;

        public event Action<ItemUI> OnTryingCombineItemsUI;
        public event Action<ItemUI> OnItemUIDestroyed;

        public Func<ItemUIController> GetItemUIController;

        public ItemUIRotation Rotation { get { return itemUIRotation; } }

        public void OnBeginDrag(PointerEventData eventData)
        {
            OnDragBegun?.Invoke();

            image.raycastTarget = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            image.raycastTarget = true;

            OnDragEnded?.Invoke();
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag.TryGetComponent(out ItemUI itemUI))
            {
                OnTryingCombineItemsUI?.Invoke(itemUI);
            }
        }

        private void OnDestroy()
        {
            OnItemUIDestroyed?.Invoke(this);
        }

        public void DisplayCount(int count)
        {
            countText.text = count.ToString();
        }
    }
}