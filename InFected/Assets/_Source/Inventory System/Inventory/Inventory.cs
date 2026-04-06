using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory
    {
        private readonly InventoryGrid _inventoryGrid;

        private readonly Dictionary<Item, Vector2Int> _itemsPlacementOriginsDictionary = new();

        public Inventory(Vector2Int inventorySize)
        {
            _inventoryGrid = new(inventorySize);
        }

        public Vector2Int Size => _inventoryGrid.Size;
        public Item[] Items => _itemsPlacementOriginsDictionary.Keys.ToArray();
        public Vector2Int[] PlacementOrigins => _itemsPlacementOriginsDictionary.Values.ToArray();

        public event Action<Item> OnItemAdded;
        public event Action<Item> OnItemRemoved;

        public bool TryPlaceItemAt(Item item, Vector2Int cell)
        {
            if (_itemsPlacementOriginsDictionary.ContainsKey(item)) { return false; }

            if (_inventoryGrid.TryPlaceItemAt(item, cell))
            {
                _itemsPlacementOriginsDictionary.Add(item, cell);
                item.OnItemCountZero += RemoveItem;
                OnItemAdded?.Invoke(item);
                return true;
            }

            return true;
        }

        public bool TryRemoveItemAt(Vector2Int cell, out Item removedItem)
        {
            if (_inventoryGrid.TryRemoveItemAt(cell, out removedItem))
            {
                _itemsPlacementOriginsDictionary.Remove(removedItem);
                RemoveItem(removedItem);
                return true;
            }

            return false;
        }

        public bool TryRemoveItem(Item item)
        {
            if (_itemsPlacementOriginsDictionary.Remove(item, out Vector2Int placementOrigin))
            {
                _inventoryGrid.TryRemoveItemAt(placementOrigin, out _);
                RemoveItem(item);
                return true;
            }

            return false;
        }

        public bool TryGetItemAt(Vector2Int cell, out Item item)
        {
            return _inventoryGrid.TryGetItemAt(cell, out item);
        }

        public bool CheckIfItemExists(Item item)
        {
            return _itemsPlacementOriginsDictionary.ContainsKey(item);
        }

        public bool TryGetItemPlacementOrigin(Item item, out Vector2Int placementOrigin)
        {
            return _itemsPlacementOriginsDictionary.TryGetValue(item, out placementOrigin);
        }

        public bool TryGetItemOfKind(ItemDataSO itemKind, out Item item)
        {
            item = _itemsPlacementOriginsDictionary.Keys.FirstOrDefault(item => item.ItemData == itemKind);
            return item != null;
        }

        public List<Item> GetAllItemsOfKind(ItemDataSO itemKind)
        {
            return _itemsPlacementOriginsDictionary.Keys.ToList().FindAll(item => item.ItemData == itemKind);
        }

        public List<ItemType> GetAllItemsOfType<ItemType>() where ItemType : Item
        {
            List<ItemType> itemsOfType = new();

            foreach (Item item in _itemsPlacementOriginsDictionary.Keys)
            {
                if (item is ItemType itemOfType)
                {
                    itemsOfType.Add(itemOfType);
                }
            }

            return itemsOfType;
        }

        private void RemoveItem(Item item)
        {
            item.OnItemCountZero -= RemoveItem;
            OnItemRemoved?.Invoke(item);
        }

        private class InventoryGrid
        {
            private readonly Dictionary<Vector2Int, PlacementData> _gridData = new();

            public InventoryGrid(Vector2Int size)
            {
                Size = size;
            }

            public Vector2Int Size { get; }

            public bool TryPlaceItemAt(Item item, Vector2Int cell)
            {
                Vector2Int[] placementCells = CalculatePlacementCells(cell, item.FunctionalSize);

                if (CheckIfCanOccupyCells(placementCells))
                {
                    OccupyCellsWithItem(item, placementCells);
                    return true;
                }

                return false;
            }

            public bool TryRemoveItemAt(Vector2Int cell, out Item removedItem)
            {
                if (_gridData.TryGetValue(cell, out PlacementData placement))
                {
                    foreach (Vector2Int placementCell in placement.Cells)
                    {
                        _gridData.Remove(placementCell);
                    }

                    removedItem = placement.Item;
                    return true;
                }

                removedItem = null;
                return false;
            }

            public bool TryGetItemAt(Vector2Int cell, out Item item)
            {
                if (_gridData.TryGetValue(cell, out PlacementData placement))
                {
                    item = placement.Item;
                    return true;
                }

                item = null;
                return false;
            }

            private Vector2Int[] CalculatePlacementCells(Vector2Int placementOrigin, Vector2Int size)
            {
                Vector2Int[] placementCells = new Vector2Int[size.x * size.y];
                int i = -1;

                for (int x = 0; x < size.x; x++)
                {
                    for (int y = 0; y < size.y; y++)
                    {
                        Vector2Int cell = new(placementOrigin.x + x, placementOrigin.y + y);
                        i++;
                        placementCells[i] = cell;
                    }
                }

                return placementCells;
            }

            private bool CheckIfCanOccupyCells(Vector2Int[] cells)
            {
                foreach (var cell in cells)
                {
                    if (CheckIfCellOutsideOfBounds(cell) || CheckIfCellOccupied(cell))
                    {
                        return false;
                    }
                }

                return true;
            }

            private bool CheckIfCellOutsideOfBounds(Vector2Int cell)
            {
                return cell.x >= Size.x || cell.x < 0 || cell.y >= Size.y || cell.y < 0;
            }

            private bool CheckIfCellOccupied(Vector2Int cell)
            {
                return _gridData.ContainsKey(cell);
            }

            private void OccupyCellsWithItem(Item item, Vector2Int[] cells)
            {
                PlacementData placement = new(item, cells);

                foreach (Vector2Int cell in cells)
                {
                    _gridData[cell] = placement;
                }
            }

            private class PlacementData
            {
                private readonly Item _item;
                private readonly Vector2Int[] _cells;

                public PlacementData(Item item, Vector2Int[] cells)
                {
                    _item = item;
                    _cells = cells;
                }

                public Item Item => _item;
                public Vector2Int[] Cells => _cells;
            }
        }
    }
}