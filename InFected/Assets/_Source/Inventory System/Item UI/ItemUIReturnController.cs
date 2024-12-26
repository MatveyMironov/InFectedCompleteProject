namespace InventorySystem
{
    public class ItemUIReturnController
    {
        private ItemUI _itemUI;

        public ItemUIReturnController(ItemUI itemUI)
        {
            _itemUI = itemUI;
        }

        public void ReturnToCellUI(InventoryCellUI cellUI)
        {
            _itemUI.transform.position = cellUI.transform.position;
            _itemUI.transform.SetParent(cellUI.transform.parent.parent);
        }
    }
}