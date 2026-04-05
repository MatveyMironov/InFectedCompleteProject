using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [Serializable]
    public class InventoryFiller
    {
        [SerializeField] private List<ItemPlacement> itemsPlacement;

        public void FillInventory(Inventory inventory)
        {
            foreach (var itemPlacement in itemsPlacement)
            {
                Item item = itemPlacement.ItemData.Item;
                item.Count = itemPlacement.Count;

                if (inventory.InventoryGrid.TryPlaceItemAt(item, itemPlacement.PlacementOrigin))
                {

                }
            }
        }

        [Serializable]
        private class ItemPlacement
        {
            [field: SerializeField] public ItemDataSO ItemData { get; private set; }
            [field: SerializeField] public int Count { get; private set; }
            [field: SerializeField] public Vector2Int PlacementOrigin { get; private set; }
        }
    }
}