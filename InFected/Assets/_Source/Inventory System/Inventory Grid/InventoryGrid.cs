using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryGrid
    {
        private Dictionary<Vector2Int, GridPlacement> _gridData;

        public event Action<Item, Vector2Int> OnItemPlaced;
        public event Action<Item> OnItemRemoved;

        public InventoryGrid(Vector2Int size)
        {
            GridSize = size;
            _gridData = new();
        }

        public Vector2Int GridSize { get; private set; }

        public bool TryPlaceItemAt(Item item, Vector2Int placementOrigin)
        {
            List<Vector2Int> positionsToOccupy = CalculatePlacementPositions(placementOrigin, item.FunctionalSize);

            if (CheckIfCanOccupyPositions(positionsToOccupy))
            {
                OccupyPositionsWithItem(item, positionsToOccupy);
                OnItemPlaced?.Invoke(item, placementOrigin);

                return true;
            }

            return false;
        }

        public void RemoveItemAt(Vector2Int position)
        {
            if (_gridData.ContainsKey(position))
            {
                GridPlacement placement = _gridData[position];

                foreach (Vector2Int cell in placement.OccupiedCells)
                {
                    _gridData.Remove(cell);
                }

                Item removedItem = placement.Item;
                OnItemRemoved?.Invoke(removedItem);
            }
        }

        public bool TryGetItemAt(Vector2Int position, out Item item)
        {
            item = null;

            if (_gridData.ContainsKey(position))
            {
                GridPlacement placement = _gridData[position];
                item = placement.Item;

                return true;
            }

            return false;
        }

        private List<Vector2Int> CalculatePlacementPositions(Vector2Int placementOrigin, Vector2Int size)
        {
            List<Vector2Int> placementPositions = new();

            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    Vector2Int position = new(placementOrigin.x + x, placementOrigin.y + y);

                    placementPositions.Add(position);
                }
            }

            return placementPositions;
        }

        private bool CheckIfCanOccupyPositions(List<Vector2Int> positions)
        {
            foreach (var position in positions)
            {
                if (CheckIfPositionOutsideOfBounds(position) || CheckIfPositionOccupied(position))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckIfPositionOutsideOfBounds(Vector2Int position)
        {
            return position.x >= GridSize.x || position.x < 0 || position.y >= GridSize.y || position.y < 0;
        }

        private bool CheckIfPositionOccupied(Vector2Int position)
        {
            return _gridData.ContainsKey(position);
        }

        private void OccupyPositionsWithItem(Item item, List<Vector2Int> positionsToOccupy)
        {
            GridPlacement placement = new(item, positionsToOccupy);

            foreach (Vector2Int position in positionsToOccupy)
            {
                _gridData[position] = placement;
            }
        }

        private class GridPlacement
        {
            public GridPlacement(Item item, List<Vector2Int> occupiedCells)
            {
                Item = item;
                OccupiedCells = occupiedCells;
            }

            public Item Item { get; }
            public List<Vector2Int> OccupiedCells { get; }
        }
    }
}