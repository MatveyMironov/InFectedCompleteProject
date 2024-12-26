using AudioSettingsSystem;
using GameSystem;
using HealingSystem;
using HealthSystem;
using InteractionSystem;
using InventorySystem;
using KeySystem;
using NarrativeSystem;
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
        [SerializeField] private PlayerMovement playerMovement;
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

        [Header("Key Bank")]
        [SerializeField] private KeyBankUI keyBankUI;
        [SerializeField] private HideableUI keyBankMenu;

        [Header("Key Collector")]
        [SerializeField] private KeysCollector keysCollector;
        [SerializeField] private LoadCapacityDisplayer keysDisplayer;

        [Header("Interaction")]
        [SerializeField] private AudioSource interactionSource;
        [SerializeField] private InteractionFinder interactionFinder;

        [Header("Sprint")]
        [SerializeField] private int maxStamina;
        [SerializeField] private float staminaRecoveryDelay;
        [SerializeField] private float staminaRecoveryRate;
        [SerializeField] private StaminaUI staminaUI;

        [Header("Audio")]
        [SerializeField] private VolumeSettingsDataSO volumeSettingsData;
        [SerializeField] private VolumeSettingsUI volumeSettingsUI;
        [SerializeField] private AudioMixer audioMixer;

        [Header("Game UI")]
        [SerializeField] private GameStartMenu gameStartMenu;
        [SerializeField] private GamePauseMenu gamePauseMenu;
        [SerializeField] private GameWinMenu gameWinMenu;
        [SerializeField] private GameLossMenu gameLossMenu;

        [Header("Narrative")]
        [SerializeField] private NarrativeTabsAndTriggersBootstrapper narrativeBootstrapper;

        [Space]
        [SerializeField] private SceneLoader nextLevelLoader;

        private void Awake()
        {
            TimePause timePause = new();

            ActionMapsController actionMapsController = new();

            PlayerMovementController playerMovementController = new(mainCamera, playerMovement);

            Inventory inventory = new(inventorySize);

            InventoryUIController playerInventoryUIController = new(playerInventoryWindow);
            playerInventoryUIController.ProvideInventory(inventory);

            InventoryUIController containerInventoryWindowController = new(containerInventoryWindow);

            InventoryMenuController inventoryMenuController = new(inventoryMenu, timePause, actionMapsController);
            InventoryInteractionManager inventoryManager = new(inventoryMenuController, containerInventoryWindowController);

            WeaponUser weaponUser = new(inventory, baseReloadingTime, baseRechargingTime, equipingTime);
            WeaponUserController weaponUserController = new(weaponUser);
            WeaponUIController weaponUIController = new(weaponUI, weaponUser);

            WeaponSelector weaponEquiper = new(inventory, weaponBody, weaponUser);
            WeaponSelectorController weaponEquiperController = new(weaponEquiper);

            Health playerHealth = new(maxHealth, maxHealth);

            PlayerHealthController playerHealthController = new(player, playerHealth);
            HealthDisplayerController playerHealthDisplayerController = new(playerHealth, healthDisplayer);

            PlayerDeathController playerDeathController = new(playerHealth);

            KeyBank keyBank = new();

            TimePauseMenuController keyBankMenuController = new(keyBankMenu, timePause);
            KeyBankUIController keyBankUIController = new(keyBankUI, keyBank);

            Interaction interaction = new(inventoryManager, keyBank, playerHealth, interactionSource);
            InteractionController interactionController = new(interactionFinder, interaction);

            StaminaController staminaController = new(maxStamina, staminaRecoveryDelay, staminaRecoveryRate);
            StaminaUIController staminaUIController = new(staminaController, staminaUI);
            playerMovement.Setup(staminaController);

            ItemsOfSameTypeProvider<HealingItem> healingItemsProvider = new(inventory);
            Healing healing = new(playerHealth, healingItemsProvider);
            HealingController healingController = new(healing);
            HealingItemUIController healingItemUIController = new(healingItemUI, healingItemsProvider);

            if (narrativeBootstrapper != null)
            {
                narrativeBootstrapper.Bootstrapp(actionMapsController);
            }

            GamePause gamePause = new(timePause, actionMapsController, gamePauseMenu);
            GamePauseController gamePauseController = new(gamePause, gamePauseMenu);

            LevelWin levelWin = new(timePause, actionMapsController, gameWinMenu);
            LevelWinController levelWinController = new(keysCollector, levelWin);

            LevelTransitionController levelTransitionController = new(nextLevelLoader, gameWinMenu);

            Remain remain = new(gameWinMenu, timePause, actionMapsController);

            KeysCollectorUIController keysCollectorUIController = new(keysCollector, keyBank, keysDisplayer);

            LevelRetryController levelRetryController = new(gameLossMenu);

            GameLoss gameLoss = new(timePause, actionMapsController, gameLossMenu);
            GameLossController gameLossController = new(playerDeathController, gameLoss);

            GameStart gameStart = new(timePause, actionMapsController, gameStartMenu);
            GameStartController gameStartController = new(gameStart, gameStartMenu);

            GameQuit gameQuit = new(mainMenuLoader);
            QuitInputController gameQuitController1 = new(gameQuit, gameLossMenu);
            QuitInputController gameQuitController3 = new(gameQuit, gamePauseMenu);

            InputListener inputListener = new(actionMapsController,
                                              playerMovementController,
                                              inventoryMenuController,
                                              keyBankMenuController,
                                              weaponEquiperController,
                                              weaponUserController,
                                              interactionController,
                                              healingController,
                                              gamePauseController);

            gameStart.Initialize();
        }

        private void Start()
        {
            VolumeSettings volumeSettings = new(audioMixer);
            VolumeSettingsController volumeSettingsController = new(volumeSettings, volumeSettingsUI, volumeSettingsData);
        }
    }
}