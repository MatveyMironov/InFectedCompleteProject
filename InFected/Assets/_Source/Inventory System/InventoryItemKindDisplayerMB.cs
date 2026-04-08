using CustomUISystem;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryItemKindDisplayerMB : MonoBehaviour
    {
        [SerializeField] private ANumberDisplayerMB itemCountDisplayer;
        [SerializeField] private GameObject displayerObject;

        [Space]
        [SerializeField] private InventorySO inventorySO;
        [SerializeField] private ItemDataSO item;

        private ItemsOfSameKindProvider _itemProvider;

        private void Awake()
        {
            Inventory inventory = inventorySO.Inventory;
            _itemProvider = new(inventory, item);

            HideDisplayer();
        }

        private void OnEnable()
        {
            _itemProvider.OnItemsCountChanged += DisplayItemsCount;
            DisplayItemsCount(_itemProvider.ItemsCount);
        }

        private void OnDisable()
        {
            _itemProvider.OnItemsCountChanged -= DisplayItemsCount;
        }

        private void DisplayItemsCount(int count)
        {
            itemCountDisplayer.DisplayNumber(count);

            if (count > 0)
            {
                ShowDisplayer();
            }
            else
            {
                HideDisplayer();
            }
        }

        private void ShowDisplayer()
        {
            displayerObject.SetActive(true);
        }

        private void HideDisplayer()
        {
            displayerObject.SetActive(false);
        }
    }
}