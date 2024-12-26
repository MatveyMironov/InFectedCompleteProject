using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "NewItemData", menuName = "Items/Item Data")]
    public class ItemDataSO : ScriptableObject
    {
        [SerializeField] protected string itemName;
        [SerializeField] protected string description;
        [SerializeField] protected int maxCount;
        [SerializeField] protected Vector2Int size;
        [SerializeField] protected ItemUI itemUIPrefab;

        public virtual Item Item { get { return new Item(this, itemName, description, maxCount, size, itemUIPrefab); } }
    }
}