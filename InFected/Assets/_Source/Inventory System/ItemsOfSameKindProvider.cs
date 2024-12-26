using System;
using System.Collections.Generic;

namespace InventorySystem
{
    public class ItemsOfSameKindProvider
    {
        private readonly Inventory _inventory;
        private readonly ItemDataSO _itemKind;

        private List<Item> _itemsOfKind;

        public ItemsOfSameKindProvider(Inventory inventory, ItemDataSO itemKind)
        {
            _inventory = inventory;
            _itemKind = itemKind;

            _itemsOfKind = new();

            FindItemsOfKind();

            _inventory.OnItemAdded += TryAddItemOfKind;
            _inventory.OnItemRemoved += TryRemoveItemOfKind;
        }

        public int ItemsCount { get => CountItems(); }

        public event Action<int> OnItemsCountChanged;

        public void GetReadyForDispose()
        {
            _inventory.OnItemAdded -= TryAddItemOfKind;
        }

        public void RemoveItems(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("It is not possible to remove zero or negative amount of items");
            }

            if (count > ItemsCount)
            {
                throw new ArgumentOutOfRangeException("It is not possible to remove more items than is curently stored");
            }

            List<Item> availableItems = _itemsOfKind;

            while (count > 0)
            {
                if (_itemsOfKind.Count > 0)
                {
                    Item item = availableItems[0];

                    int availableCount = item.Count;

                    if (availableCount >= count)
                    {
                        item.Count -= count;
                        count = 0;
                    }
                    else
                    {
                        item.Count = 0;
                        count -= availableCount;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Something wen terribly wrong...");
                }
            }

            OnItemsCountChanged?.Invoke(ItemsCount);
        }

        private void FindItemsOfKind()
        {
            foreach (Item item in _inventory.GetAllItemsOfKind(_itemKind))
            {
                AddItem(item);
            }
        }

        private void TryAddItemOfKind(Item item)
        {
            if (item.ItemData == _itemKind)
            {
                AddItem(item);
            }
        }

        private void AddItem(Item item)
        {
            _itemsOfKind.Add(item);
            item.OnItemCountZero += RemoveItem;
            item.OnItemCountChanged += InvokeOnItemsCountChanged;

            OnItemsCountChanged?.Invoke(ItemsCount);
        }

        private void TryRemoveItemOfKind(Item item)
        {
            if (item.ItemData == _itemKind)
            {
                RemoveItem(item);
            }
        }

        private void RemoveItem(Item item)
        {
            item.OnItemCountChanged -= InvokeOnItemsCountChanged;
            item.OnItemCountZero -= RemoveItem;
            _itemsOfKind.Remove(item);

            OnItemsCountChanged?.Invoke(ItemsCount);
        }

        private int CountItems()
        {
            int count = 0;

            foreach (Item item in _itemsOfKind)
            {
                count += item.Count;
            }

            return count;
        }

        private void InvokeOnItemsCountChanged(int itemCount)
        {
            OnItemsCountChanged?.Invoke(ItemsCount);
        }
    }
}