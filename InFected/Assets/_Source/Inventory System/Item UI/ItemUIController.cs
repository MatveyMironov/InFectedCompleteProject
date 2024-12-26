using Core;
using UnityEngine;

namespace InventorySystem
{
    public class ItemUIController
    {
        private readonly Item _item;
        private readonly ItemUI _itemUI;
        private readonly ItemUIReturnController _returnController;

        private InventoryCellUI _currentCellUI;
        private InventoryCellUI _previousCellUI;

        private bool _isDragged;

        public ItemUIController(Item item, ItemUI itemUI)
        {
            _item = item;
            _itemUI = itemUI;

            _returnController = new(_itemUI);

            _itemUI.OnDragBegun += RemoveFromCellUI;
            _itemUI.OnDragEnded += ReturnToCellUI;

            _itemUI.OnTryingCombineItemsUI += TryCombineItemsUI;
            _itemUI.OnItemUIDestroyed += GetReadyForDispose;

            _itemUI.GetItemUIController += ReturnThisController;

            _item.OnItemCountChanged += _itemUI.DisplayCount;
            _item.OnItemCountZero += DestroyItemUI;
            _item.OnRotationChanged += RotateItemUI;

            _itemUI.DisplayCount(_item.Count);

            InputListener.OnRotateItemInputRecieved += RotateItem;
        }

        public Item Item { get { return _item; } }

        public void AssignCellUIAndReturn(InventoryCellUI cellUI)
        {
            AssignCellUI(cellUI);
            _returnController.ReturnToCellUI(_currentCellUI);
        }

        public void AssignCellUI(InventoryCellUI cellUI)
        {
            _currentCellUI = cellUI;
        }

        private void DestroyItemUI(Item item)
        {
            if (_itemUI == null) { return; }

            UnityEngine.Object.Destroy(_itemUI.gameObject);
        }

        private void GetReadyForDispose(ItemUI itemUI)
        {
            _itemUI.OnDragBegun -= RemoveFromCellUI;
            _itemUI.OnDragEnded -= ReturnToCellUI;

            _itemUI.OnTryingCombineItemsUI -= TryCombineItemsUI;
            _itemUI.OnItemUIDestroyed -= GetReadyForDispose;

            _itemUI.GetItemUIController -= ReturnThisController;

            _item.OnItemCountChanged -= _itemUI.DisplayCount;
            _item.OnItemCountZero -= DestroyItemUI;
            _item.OnRotationChanged -= RotateItemUI;

            InputListener.OnRotateItemInputRecieved -= RotateItem;
        }

        private void RemoveFromCellUI()
        {
            _currentCellUI.RemoveItemUI(_itemUI);
            _previousCellUI = _currentCellUI;
            _currentCellUI = null;

            _itemUI.transform.SetParent(_itemUI.transform.root);

            _isDragged = true;
        }

        private void ReturnToCellUI()
        {
            if (_currentCellUI == null)
            {
                ReturnToPreviousCellUI();
            }

            _returnController.ReturnToCellUI(_currentCellUI);

            _isDragged = false;
        }

        private void ReturnToPreviousCellUI()
        {
            _currentCellUI = _previousCellUI;

            if (!_currentCellUI.TryPlaceItemUI(_itemUI))
            {
                _item.IsRotated = !_item.IsRotated;
                _currentCellUI.TryPlaceItemUI(_itemUI);
            }
        }

        private void TryCombineItemsUI(ItemUI combinedItemUI)
        {
            ItemUIController combinedItemUIController = combinedItemUI.GetItemUIController();

            if (combinedItemUIController != null)
            {
                if (combinedItemUIController != this)
                {
                    Item combinedItem = combinedItemUIController._item;

                    if (_item.ItemData == combinedItem.ItemData)
                    {
                        int availableSpace = _item.MaxCount - _item.Count;

                        if (availableSpace > 0)
                        {
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
                    }
                }
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
                _itemUI.Rotation.RotateToAlternative();
            }
            else
            {
                _itemUI.Rotation.RotateToDefault();
            }
        }

        private ItemUIController ReturnThisController()
        {
            return this;
        }
    }
}