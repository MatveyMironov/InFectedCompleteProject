using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class InventoryUI : MonoBehaviour
    {
        [Header("Grid Inventory Window")]
        [SerializeField] private InventoryCellUI UICellPrefab;
        [SerializeField] private RectTransform cellsContent;
        [SerializeField] private GridLayoutGroup gridLayoutGroup;

        private List<InventoryCellUI> _createdCells = new();

        public void ShowWindow()
        {
            cellsContent.gameObject.SetActive(true);
        }

        public void HideWindow()
        {
            cellsContent.gameObject.SetActive(false);
        }

        public void ResizeWindow(Vector2Int gridSize)
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

        public Dictionary<Vector2Int, InventoryCellUI> CreateCells(Vector2Int gridSize)
        {
            Dictionary<Vector2Int, InventoryCellUI> cells = new();

            for (int i = 0; i < gridSize.y; i++)
            {
                for (int j = 0; j < gridSize.x; j++)
                {
                    InventoryCellUI UICell = Instantiate(UICellPrefab, cellsContent);
                    UICell.transform.position = cellsContent.position;
                    Vector2Int cellCoordinates = new(j, i);
                    cells.Add(cellCoordinates, UICell);
                    _createdCells.Add(UICell);
                }
            }

            return cells;
        }

        public void DestroyCells()
        {
            foreach (var cell in _createdCells)
            {
                Destroy(cell.gameObject);
            }

            _createdCells.Clear();
        }
    }
}