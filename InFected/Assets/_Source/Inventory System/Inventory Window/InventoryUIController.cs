using CustomUtilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryUIController
    {
        private readonly InventoryUI _inventoryUI;
        private Inventory _inventory;

        private List<ItemUI> _itemsUI;

        public InventoryUIController(InventoryUI inventoryWindow)
        {
            _inventoryUI = inventoryWindow;

            _itemsUI = new();
        }

        public void ProvideInventory(Inventory inventory)
        {
            _inventory = inventory;

            ClearInventoryWindow();
            _inventoryUI.ResizeWindow(inventory.InventoryGrid.GridSize);
            _inventoryUI.ShowWindow();

            Dictionary<Vector2Int, InventoryCellUI> inventoryCellsUI = _inventoryUI.CreateCells(inventory.InventoryGrid.GridSize);
            CreateCellUIControllers(inventoryCellsUI);
            CoroutineManager.StartRoutine(DelayUIItemControllersCreation(inventoryCellsUI));
        }

        public void ClearInventoryWindow()
        {
            DestroyItemsUI();
            _inventoryUI.DestroyCells();
            _inventoryUI.HideWindow();
        }

        private void DestroyItemsUI()
        {
            foreach (var itemUI in _itemsUI)
            {
                UnityEngine.Object.Destroy(itemUI.gameObject);
            }

            _itemsUI.Clear();
        }

        private void CreateCellUIControllers(Dictionary<Vector2Int, InventoryCellUI> inventoryCellsUI)
        {
            foreach (Vector2Int position in inventoryCellsUI.Keys)
            {
                InventoryCellUI cellUI = inventoryCellsUI[position];
                InventoryCellUIController cellController = new(cellUI, _inventory.InventoryGrid, position);
                cellController.OnItemUIPlaced += AddItemUI;
                cellController.OnItemUIRemoved += RemoveItemUI;
            }
        }

        private IEnumerator DelayUIItemControllersCreation(Dictionary<Vector2Int, InventoryCellUI> inventoryCellsUI)
        {
            yield return null;

            CreateItemUIControllers(inventoryCellsUI);
        }

        private void CreateItemUIControllers(Dictionary<Vector2Int, InventoryCellUI> inventoryCellsUI)
        {
            foreach (Item item in _inventory.ItemsPlacementData.Keys)
            {
                ItemUI itemUI = UnityEngine.Object.Instantiate(item.ItemUIPrefab, _inventoryUI.transform);
                ItemUIController itemUIController = new(item, itemUI);
                itemUIController.AssignCellUIAndReturn(inventoryCellsUI[_inventory.ItemsPlacementData[item]]);
                AddItemUI(itemUI);
            }
        }

        private void AddItemUI(ItemUI itemUI)
        {
            _itemsUI.Add(itemUI);
            itemUI.OnItemUIDestroyed += RemoveItemUI;
        }

        private void RemoveItemUI(ItemUI itemUI)
        {
            itemUI.OnItemUIDestroyed -= RemoveItemUI;
            _itemsUI.Remove(itemUI);
        }
    }
}