using HealingSystem;
using HealthSystem;
using InventorySystem;
using KeySystem;
using PlayerSystem;
using UISystem;
using UnityEngine;
using WeaponSystem;

namespace Core
{
    public class BootStrapper : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private PlayerMovementController playerMovement;
        [SerializeField] private SceneLoader mainMenuLoader;

        [Header("Weapon Use")]
        [SerializeField] private WeaponBody weaponBody;
        [SerializeField] private float equipingTime;
        [SerializeField] private float baseReloadingTime;
        [SerializeField] private float baseRechargingTime;

        [Header("Health")]
        [SerializeField] private int maxHealth;
        [SerializeField] private LoadCapacityDisplayer healthDisplayer;

        [Header("Inventory")]
        [SerializeField] private Vector2Int inventorySize;
        [SerializeField] private HideableUI inventoryMenu;
        [SerializeField] private InventoryFiller inventoryFiller;

        [Header("Key Collector")]
        [SerializeField] private KeysCollector keysCollector;
        [SerializeField] private LoadCapacityDisplayer keysDisplayer;

        [Header("Interaction")]
        [SerializeField] private AudioSource interactionSource;

        [Space]
        [SerializeField] private SceneLoader nextLevelLoader;

        private Inventory _inventory;

        private void Awake()
        {
        }

        private void Start()
        {
            inventoryFiller.FillInventory(_inventory);
        }
    }
}