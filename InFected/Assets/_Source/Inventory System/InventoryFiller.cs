using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [Serializable]
    public class InventoryFiller
    {
        [SerializeField] private List<ItemPlacement> itemPlacements;

        public void FillInventory(Inventory inventory)
        {
            foreach (var itemPlacement in itemPlacements)
            {
                Item item = itemPlacement.Item.Item;
                item.Count = itemPlacement.Count;

                if (inventory.TryPlaceItemAt(item, itemPlacement.PlacementOrigin))
                {

                }
                else
                {
                    Debug.Log($"Failed to place {item.Count} units of {item} at {itemPlacement.PlacementOrigin}");
                }
            }
        }

        [Serializable]
        private class ItemPlacement
        {
            [field: SerializeField] public ItemDataSO Item { get; private set; }
            [field: SerializeField] public int Count { get; private set; }
            [field: SerializeField] public Vector2Int PlacementOrigin { get; private set; }
        }
    }
}