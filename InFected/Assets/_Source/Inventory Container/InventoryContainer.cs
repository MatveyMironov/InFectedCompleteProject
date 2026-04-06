using InteractionSystem;
using InventorySystem;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryContainer : MonoBehaviour, IInteractable
{
    [Header("Inventory")]
    [SerializeField] private Vector2Int inventorySize;
    [SerializeField] private List<ItemPlacement> itemsPlacement;
    [SerializeField] private InventoryFiller inventoryFiller;

    [Header("Interaction")]
    [SerializeField] private GameObject interactionIndicator;
    [SerializeField] private AudioClip interactionClip;

    private Inventory _inventory;

    private void Awake()
    {
        _inventory = new(inventorySize);
    }

    private void Start()
    {
        inventoryFiller.FillInventory(_inventory);
        HideInteraction();
    }

    public void ShowInteraction()
    {
        interactionIndicator.SetActive(true);
    }

    public void HideInteraction()
    {
        interactionIndicator.SetActive(false);
    }

    public void Interact(InteractionData interaction)
    {
        interaction.InventoryInteractionManager.OfferInventory(_inventory);
    }

    private void FillInventory(Inventory inventory)
    {
        foreach (var itemPlacement in itemsPlacement)
        {
            Item item = itemPlacement.ItemData.Item;
            item.Count = itemPlacement.Count;

            if (inventory.TryPlaceItemAt(item, itemPlacement.PlacementOrigin))
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