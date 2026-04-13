using InteractionSystem;
using InventorySystem;
using UnityEngine;

public class InventoryContainer : MonoBehaviour, IInteractable
{
    [Header("Inventory")]
    [SerializeField] private Vector2Int inventorySize;
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
}