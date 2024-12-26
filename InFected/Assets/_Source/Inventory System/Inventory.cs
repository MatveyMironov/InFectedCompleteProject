using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory
    {
        private Dictionary<Item, Vector2Int> _itemsStorageData;

        public Inventory(Vector2Int inventorySize)
        {
            InventoryGrid = new(inventorySize);

            _itemsStorageData = new();

            InventoryGrid.OnItemPlaced += AddItemToInventory;
            InventoryGrid.OnItemRemoved += RemoveItemFromInventory;
        }

        public InventoryGrid InventoryGrid { get; }
        public Dictionary<Item, Vector2Int> ItemsPlacementData { get { return new(_itemsStorageData); } }

        public event Action<Item> OnItemAdded;
        public event Action<Item> OnItemRemoved;

        public bool TryGetItemOfKind(ItemDataSO itemKind, out Item item)
        {
            item = _itemsStorageData.Keys.FirstOrDefault(item => item.ItemData == itemKind);

            return item != null;
        }

        public List<Item> GetAllItemsOfKind(ItemDataSO itemKind)
        {
            return _itemsStorageData.Keys.ToList().FindAll(item => item.ItemData == itemKind);
        }

        public List<ItemType> GetAllItemsOfType<ItemType>() where ItemType : Item
        {
            List<ItemType> itemsOfType = new();

            foreach (Item item in _itemsStorageData.Keys)
            {
                if (item is ItemType itemOfType)
                {
                    itemsOfType.Add(itemOfType);
                }
            }

            return itemsOfType;
        }

        public void AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(Item item)
        {
            if (_itemsStorageData.Keys.Contains(item))
            {
                InventoryGrid.RemoveItemAt(_itemsStorageData[item]);
                RemoveItemFromInventory(item);
            }
        }

        private void AddItemToInventory(Item item, Vector2Int placementOrigin)
        {
            if (_itemsStorageData.ContainsKey(item)) { return; }
            _itemsStorageData.Add(item, placementOrigin);
            item.OnItemCountZero += RemoveItem;
            OnItemAdded?.Invoke(item);
        }

        private void RemoveItemFromInventory(Item item)
        {
            _itemsStorageData.Remove(item);
            item.OnItemCountZero -= RemoveItem;
            OnItemRemoved?.Invoke(item);
        }
    }
}