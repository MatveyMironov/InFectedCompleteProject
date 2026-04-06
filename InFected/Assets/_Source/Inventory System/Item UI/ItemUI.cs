using Core;
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

        private Item _item;
        public Item Item => _item;

        private InventoryCellUI _currentCellUI;
        private InventoryCellUI _previousCellUI;
        private bool _isDragged;

        public event Action<ItemUI> OnItemUIDestroyed;

        private void Start()
        {
            if (_currentCellUI == null) { return; }

            OccupyCurrentCellUI();
        }

        private void OnDestroy()
        {
            _item.OnItemCountChanged -= DisplayCount;
            _item.OnItemCountZero -= DestroyItemUI;
            _item.OnRotationChanged -= RotateItemUI;

            InputListener.OnRotateItemInputRecieved -= RotateItem;

            OnItemUIDestroyed?.Invoke(this);
        }

        public void AssignItem(Item item)
        {
            _item = item;

            _item.OnItemCountChanged += DisplayCount;
            _item.OnItemCountZero += DestroyItemUI;
            _item.OnRotationChanged += RotateItemUI;

            InputListener.OnRotateItemInputRecieved += RotateItem;

            DisplayCount(_item.Count);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            //Disable item raycast target so that item can be droped on inventory cells underneath
            image.raycastTarget = false;

            //Item is removed from the cell, but this cell is remembered so that item can be returned
            _currentCellUI.RemoveItemUI(this);
            _previousCellUI = _currentCellUI;
            _currentCellUI = null;

            //Item is placed in the top most transform in the hierarchy so it is displayed on top of everything
            transform.SetParent(transform.root);

            _isDragged = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //Enable item raycast target so that item can be picked again
            image.raycastTarget = true;

            if (_currentCellUI == null)
            {
                ReturnToPreviousCellUI();
            }

            //Item is placed in the cell
            OccupyCurrentCellUI();

            _isDragged = false;
        }

        //When other item is droped on this one try to combine them
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag.TryGetComponent(out ItemUI itemUI))
            {
                TryCombineWithItem(itemUI);
            }
        }

        public void AssignCellUI(InventoryCellUI cellUI)
        {
            _currentCellUI = cellUI;
        }

        private void ReturnToPreviousCellUI()
        {
            _currentCellUI = _previousCellUI;
            _previousCellUI = null;

            if (!_currentCellUI.TryPlaceItemUI(this))
            {
                _item.IsRotated = !_item.IsRotated;
                _currentCellUI.TryPlaceItemUI(this);
            }
        }

        private void OccupyCurrentCellUI()
        {
            transform.SetParent(_currentCellUI.transform);
        }

        private void DisplayCount(int count)
        {
            countText.text = count.ToString();
        }

        private void DestroyItemUI(Item item)
        {
            Destroy(gameObject);
        }

        private void TryCombineWithItem(ItemUI itemUI)
        {
            if (itemUI == null) { return; }
            if (itemUI == this) { return; }

            Item combinedItem = itemUI._item;
            if (_item.ItemData != combinedItem.ItemData) { return; }

            int availableSpace = _item.MaxCount - _item.Count;
            if (availableSpace <= 0) { return; }

            if (availableSpace >= combinedItem.Count)
            {
                _item.Count += combinedItem.Count;
                combinedItem.Count = 0;
            }
            else
            {
                _item.Count = _item.MaxCount;
                combinedItem.Count -= availableSpace;
            }
        }

        private void RotateItem()
        {
            if (_isDragged)
            {
                _item.IsRotated = !_item.IsRotated;
            }
        }

        private void RotateItemUI(bool isRotated)
        {
            if (isRotated)
            {
                itemUIRotation.RotateToAlternative();
            }
            else
            {
                itemUIRotation.RotateToDefault();
            }
        }
    }
}