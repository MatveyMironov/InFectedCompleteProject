using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class InventoryDisplayer : MonoBehaviour
    {
        [Header("Grid Inventory Window")]
        [SerializeField] private InventoryCellUI UICellPrefab;
        [SerializeField] private RectTransform cellsContent;
        [SerializeField] private GridLayoutGroup gridLayoutGroup;

        private Inventory _displayedInventory;

        private readonly List<ItemUI> _itemUIs = new();
        private readonly Dictionary<Vector2Int, InventoryCellUI> _cellUIsDictionary = new();

        public void DisplayInventory(Inventory inventory)
        {
            HideInventory();
            _displayedInventory = inventory;

            ShowWindow();

            ResizeCellsContent(inventory.Size);
            CreateCellUIs(inventory.Size);

            //Delay solves the bug of incorrect item UI position
            //CreateItemUIs(inventory);
            StartCoroutine(CreateItemsUIWithDelay(inventory));

            void ResizeCellsContent(Vector2Int gridSize)
            {
                Vector2 cellSize = gridLayoutGroup.cellSize;
                Vector2 cellSpacing = gridLayoutGroup.spacing;
                int horizontalPadding = gridLayoutGroup.padding.right + gridLayoutGroup.padding.left;
                int verticalPadding = gridLayoutGroup.padding.top + gridLayoutGroup.padding.bottom;

                Vector2 contentSize;
                contentSize.x = cellSize.x * gridSize.x + cellSpacing.x * (gridSize.x - 1) + horizontalPadding;
                contentSize.y = cellSize.y * gridSize.y + cellSpacing.y * (gridSize.y - 1) + verticalPadding;

                cellsContent.sizeDelta = contentSize;
            }

            void CreateCellUIs(Vector2Int gridSize)
            {
                for (int i = 0; i < gridSize.y; i++)
                {
                    for (int j = 0; j < gridSize.x; j++)
                    {
                        Vector2Int cell = new(j, i);
                        InventoryCellUI cellUI = Instantiate(UICellPrefab, cellsContent);
                        _cellUIsDictionary.Add(cell, cellUI);

                        cellUI.OnItemPlaceRequested += TryAddItemUIToThisCell;
                        cellUI.OnItemRemoveRequested += RemoveItemUI;

                        bool TryAddItemUIToThisCell(ItemUI itemUI)
                        {
                            return TryAddItemUI(itemUI, cell);
                        } 
                    }
                }
            }

            void CreateItemUIs(Inventory inventory)
            {
                foreach (Vector2Int placementOrigin in inventory.PlacementOrigins)
                {
                    if (inventory.TryGetItemAt(placementOrigin, out Item item))
                    {
                        ItemUI itemUI = Instantiate(item.ItemUIPrefab, transform);
                        itemUI.AssignItem(item);
                        itemUI.AssignCurrentCellUI(_cellUIsDictionary[placementOrigin]);
                        _itemUIs.Add(itemUI);
                    }
                }
            }

            IEnumerator CreateItemsUIWithDelay(Inventory inventory)
            {
                yield return null;

                CreateItemUIs(inventory);
            }
        }

        public void HideInventory()
        {
            DestroyCellUIs();
            DestroyItemUIs();
            HideWindow();

            _displayedInventory = null;

            void DestroyCellUIs()
            {
                foreach (var cellCoordinates in _cellUIsDictionary.Keys.ToArray())
                {
                    _cellUIsDictionary.Remove(cellCoordinates, out InventoryCellUI cellUI);
                    Destroy(cellUI.gameObject);
                }
            }

            void DestroyItemUIs()
            {
                foreach (var itemUI in _itemUIs)
                {
                    itemUI.OnItemUIDestroyed -= RemoveItemUI;
                    Destroy(itemUI.gameObject);
                }

                _itemUIs.Clear();
            }
        }

        private bool TryAddItemUI(ItemUI itemUI, Vector2Int cell)
        {
            if (_displayedInventory.TryPlaceItemAt(itemUI.Item, cell))
            {
                _itemUIs.Add(itemUI);
                itemUI.OnItemUIDestroyed += RemoveItemUI;
                return true;
            }

            return false;
        }

        private void RemoveItemUI(ItemUI itemUI)
        {
            itemUI.OnItemUIDestroyed -= RemoveItemUI;
            _displayedInventory.TryRemoveItem(itemUI.Item);
            _itemUIs.Remove(itemUI);
        }

        private void ShowWindow()
        {
            gameObject.SetActive(true);
        }

        private void HideWindow()
        {
            gameObject.SetActive(false);
        }
    }
}