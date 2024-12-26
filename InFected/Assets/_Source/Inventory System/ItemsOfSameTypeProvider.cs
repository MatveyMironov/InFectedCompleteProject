using System;
using System.Collections.Generic;

namespace InventorySystem
{
    public class ItemsOfSameTypeProvider<ItemOfType> where ItemOfType : Item
    {
        private Inventory _inventory;

        private List<ItemOfType> _itemsOfType;

        public ItemsOfSameTypeProvider(Inventory inventory)
        {
            _inventory = inventory;

            _itemsOfType = new();

            FindItemsOfType();

            _inventory.OnItemAdded += TryAddItemOfType;
            _inventory.OnItemRemoved += TryRemoveItemOfType;
        }

        public int ItemsCount { get => CountItems(); }

        public event Action<int> OnItemsCountChanged;

        public void GetReadyForDispose()
        {
            _inventory.OnItemAdded -= TryAddItemOfType;
            _inventory.OnItemRemoved -= TryRemoveItemOfType;
        }

        public bool TryGetItemOfType(out ItemOfType itemOfType)
        {
            itemOfType = _itemsOfType[0];

            return itemOfType != null;
        }

        private void FindItemsOfType()
        {
            foreach (ItemOfType item in _inventory.GetAllItemsOfType<ItemOfType>())
            {
                AddItemOfType(item);
            }
        }

        private void TryAddItemOfType(Item item)
        {
            if (item is ItemOfType itemOfType)
            {
                AddItemOfType(itemOfType);
            }
        }

        private void AddItemOfType(ItemOfType item)
        {
            _itemsOfType.Add(item);
            item.OnItemCountChanged += InvokeOnItemsCountChanged;
            item.OnItemCountZero += TryRemoveItemOfType;

            OnItemsCountChanged?.Invoke(ItemsCount);
        }

        private void TryRemoveItemOfType(Item item)
        {
            if (item is ItemOfType itemOfType)
            {
                RemoveItemOfType(itemOfType);
            }
        }

        private void RemoveItemOfType(ItemOfType itemOfType)
        {
            _itemsOfType.Remove(itemOfType);
            itemOfType.OnItemCountChanged -= InvokeOnItemsCountChanged;
            itemOfType.OnItemCountZero -= TryRemoveItemOfType;

            OnItemsCountChanged?.Invoke(ItemsCount);
        }

        private int CountItems()
        {
            int count = 0;

            foreach (Item item in _itemsOfType)
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