using InventorySystem;
using UnityEngine;

namespace HealingSystem
{
    public class HealingItemUIController
    {
        private HealingItemUI _healingItemUI;
        private ItemsOfSameTypeProvider<HealingItem> _healingItemProvider;

        public HealingItemUIController(HealingItemUI healingItemUI, ItemsOfSameTypeProvider<HealingItem> healingItemProvider)
        {
            _healingItemUI = healingItemUI;
            _healingItemProvider = healingItemProvider;

            _healingItemProvider.OnItemsCountChanged += DisplayItemsCount;

            DisplayItemsCount(_healingItemProvider.ItemsCount);
        }

        private void DisplayItemsCount(int count)
        {
            _healingItemUI.FirstAidKitsDisplayer.DisplayCount(count);

            if (count > 0)
            {
                _healingItemUI.Show();
            }
            else
            {
                _healingItemUI.Hide();
            }
        }
    }
}