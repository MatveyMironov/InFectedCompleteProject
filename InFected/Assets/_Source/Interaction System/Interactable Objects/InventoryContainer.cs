using InventorySystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    public class InventoryContainer : MonoBehaviour, IInteractable
    {
        [SerializeField] private InteractionIndicator indicator;

        [Header("Inventory")]
        [SerializeField] private Vector2Int inventorySize;
        [SerializeField] private List<ItemPlacement> itemsPlacement;

        [Header("Interaction Effects")]
        [SerializeField] private AudioClip interactionClip;

        private Inventory _inventory;

        private void Start()
        {
            _inventory = new(inventorySize);
            FillInventory(_inventory.InventoryGrid);
            indicator.SetInteractionInformation($"Box");
            HideInteraction();
        }

        #region IInteractable
        public void ShowInteraction()
        {
            indicator.ShowIndicator();
        }

        public void HideInteraction()
        {
            indicator.HideIndicator();
        }

        public void Interact(Interaction interaction)
        {
            InventoryInteractionManager inventoryInteractionManager = interaction.InventoryInteractionManager;
            inventoryInteractionManager.OfferInventory(_inventory);
        }
        #endregion

        private void FillInventory(InventoryGrid inventoryGrid)
        {
            foreach (var itemPlacement in itemsPlacement)
            {
                Item item = itemPlacement.ItemData.Item;
                item.Count = itemPlacement.Count;

                if (inventoryGrid.TryPlaceItemAt(item, itemPlacement.PlacementOrigin))
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