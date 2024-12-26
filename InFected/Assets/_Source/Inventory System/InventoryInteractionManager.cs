namespace InventorySystem
{
    public class InventoryInteractionManager
    {
        private InventoryMenuController _inventoryMenuController;
        private InventoryUIController _inventoryUIController;

        public InventoryInteractionManager(InventoryMenuController inventoryMenuController, InventoryUIController inventoryWindowController)
        {
            _inventoryMenuController = inventoryMenuController;
            _inventoryUIController = inventoryWindowController;

            _inventoryMenuController.OnInventoryClosed += CancelOffer;
        }

        internal void OfferInventory(Inventory inventory)
        {
            _inventoryUIController.ProvideInventory(inventory);
            _inventoryMenuController.OpenInventory();
        }

        private void CancelOffer()
        {
            _inventoryUIController.ClearInventoryWindow();
        }
    }
}