using System;
using UnityEngine;

namespace InventorySystem
{
    public class Item
    {
        private int _count;

        private readonly Vector2Int _actualSize;
        private bool _isRotated;

        public Item(ItemDataSO itemData,
                    string name,
                    string description,
                    int maxCount,
                    Vector2Int size,
                    ItemUI itemUIPrefab)
        {
            ItemData = itemData;
            Name = name;
            Description = description;
            MaxCount = maxCount;
            _actualSize = size;
            ItemUIPrefab = itemUIPrefab;
        }

        public ItemDataSO ItemData { get; }
        public string Name { get; }
        public string Description { get; }
        public int MaxCount { get; }
        public ItemUI ItemUIPrefab { get; }

        public int Count { get { return _count; } set { ChangeCount(value); } }
        public Vector2Int FunctionalSize { get { return CalculateFunctionalSize(); } }
        public bool IsRotated { get { return _isRotated; } set { ChangeRotation(); } }

        public event Action<int> OnItemCountChanged;
        public event Action<Item> OnItemCountZero;
        public event Action<bool> OnRotationChanged;

        private void ChangeCount(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("Items count can't be negative");
            }

            if (count > MaxCount)
            {
                throw new ArgumentOutOfRangeException("Items count can't be greater than max count");
            }

            _count = count;
            OnItemCountChanged?.Invoke(_count);

            if (_count == 0)
            {
                OnItemCountZero?.Invoke(this);
            }
        }

        private void ChangeRotation()
        {
            _isRotated = !_isRotated;
            OnRotationChanged?.Invoke(_isRotated);
        }

        private Vector2Int CalculateFunctionalSize()
        {
            if (IsRotated)
            {
                return new(_actualSize.y, _actualSize.x);
            }

            return _actualSize;
        }
    }
}