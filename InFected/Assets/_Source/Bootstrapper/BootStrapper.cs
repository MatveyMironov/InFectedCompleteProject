using AudioSettingsSystem;
using GameSystem;
using HealingSystem;
using HealthSystem;
using InteractionSystem;
using InventorySystem;
using KeySystem;
using PlayerSystem;
using SprintSystem;
using UISystem;
using UnityEngine;
using UnityEngine.Audio;
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
        [SerializeField] private WeaponUI weaponUI;

        [Header("Health")]
        [SerializeField] private int maxHealth;
        [SerializeField] private LoadCapacityDisplayer healthDisplayer;

        [Header("Healing")]
        [SerializeField] private HealingItemUI healingItemUI;

        [Header("Inventory")]
        [SerializeField] private Vector2Int inventorySize;
        [SerializeField] private InventoryUI playerInventoryWindow;
        [SerializeField] private InventoryUI containerInventoryWindow;
        [SerializeField] private HideableUI inventoryMenu;
        [SerializeField] private InventoryFiller inventoryFiller;

        [Header("Key Collector")]
        [SerializeField] private KeysCollector keysCollector;
        [SerializeField] private LoadCapacityDisplayer keysDisplayer;

        [Header("Interaction")]
        [SerializeField] private AudioSource interactionSource;

        [Header("Sprint")]
        [SerializeField] private int maxStamina;
        [SerializeField] private float staminaRecoveryDelay;
        [SerializeField] private float staminaRecoveryRate;
        [SerializeField] private StaminaUI staminaUI;

        [Header("Game UI")]
        [SerializeField] private GameStartMenu gameStartMenu;
        [SerializeField] private GameWinMenu gameWinMenu;
        [SerializeField] private GameLossMenu gameLossMenu;

        [Space]
        [SerializeField] private SceneLoader nextLevelLoader;

        private Inventory _inventory;

        private void Awake()
        {
            TimePause timePause = new();

            _inventory = new(inventorySize);

            InventoryUIController playerInventoryUIController = new(playerInventoryWindow);
            playerInventoryUIController.ProvideInventory(_inventory);

            InventoryUIController containerInventoryWindowController = new(containerInventoryWindow);

            InventoryMenuController inventoryMenuController = new(inventoryMenu, timePause);
            InventoryInteractionManager inventoryManager = new(inventoryMenuController, containerInventoryWindowController);

            WeaponUser weaponUser = new(_inventory, baseReloadingTime, baseRechargingTime, equipingTime);
            WeaponUserController weaponUserController = new(weaponUser);
            WeaponUIController weaponUIController = new(weaponUI, weaponUser);

            WeaponSelector weaponEquiper = new(_inventory, weaponBody, weaponUser);
            WeaponSelectorController weaponEquiperController = new(weaponEquiper);

            Health playerHealth = new(maxHealth, maxHealth);

            PlayerHealthController playerHealthController = new(player, playerHealth);
            HealthDisplayerController playerHealthDisplayerController = new(playerHealth, healthDisplayer);

            PlayerDeathController playerDeathController = new(playerHealth);

            StaminaController staminaController = new(maxStamina, staminaRecoveryDelay, staminaRecoveryRate);
            StaminaUIController staminaUIController = new(staminaController, staminaUI);
            playerMovement.Setup(staminaController);

            ItemsOfSameTypeProvider<HealingItem> healingItemsProvider = new(_inventory);
            Healing healing = new(playerHealth, healingItemsProvider);
            HealingController healingController = new(healing);
            HealingItemUIController healingItemUIController = new(healingItemUI, healingItemsProvider);

            GamePause gamePause = new();
            GamePauseController gamePauseController = new(gamePause);

            LevelWin levelWin = new(timePause, gameWinMenu);
            LevelWinController levelWinController = new(keysCollector, levelWin);

            LevelTransitionController levelTransitionController = new(nextLevelLoader, gameWinMenu);

            Remain remain = new(gameWinMenu, timePause);

            LevelRetryController levelRetryController = new(gameLossMenu);

            GameLoss gameLoss = new(timePause, gameLossMenu);
            GameLossController gameLossController = new(playerDeathController, gameLoss);

            GameStart gameStart = new(timePause, gameStartMenu);
            GameStartController gameStartController = new(gameStart, gameStartMenu);


            gameStart.Initialize();
        }

        private void Start()
        {
            inventoryFiller.FillInventory(_inventory);
        }
    }
}