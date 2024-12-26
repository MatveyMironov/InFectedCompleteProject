//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/_Presentation/Input/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""MainActionMap"",
            ""id"": ""1b852fb0-d4dc-46dc-af3c-0266bee9c3f6"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""1e091b6d-ca47-426e-b471-0c77e2a18eb3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""df2bb801-7967-4fb5-9b7a-357596846af0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Direct"",
                    ""type"": ""Value"",
                    ""id"": ""7ee6dbca-2f21-4da2-8e76-59b8c83d4a2f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""59aafbff-f84f-4a12-99c6-08156d44ef3d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""80af8ffb-1253-43e1-8774-6bf25ecee8cf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""60d3ad4f-4c9c-4a3a-8fa9-d00021f1285e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""7a62899c-52e2-4f76-99dc-82f5abfdb1db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scroll"",
                    ""type"": ""Value"",
                    ""id"": ""1c5c4c4c-2c8a-4b46-a783-e9f37076962d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Heal"",
                    ""type"": ""Button"",
                    ""id"": ""06e5b4f6-f400-4468-871b-55f83c92d8a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""68bee063-5681-47b5-9e63-601e542befae"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""00574a61-57bc-4379-8444-09f87b66bfdc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5b82ed34-2a0a-4514-bfc9-dc7a3268f9d3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9820e1ef-35b9-4ee1-a920-3f7416f5da60"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4cb1a7c9-0892-4a62-987c-2098f88b230e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fd54d8d3-bf17-43ef-813b-d31241dfdbe0"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ccf25644-0e4e-49ad-a15a-04ba5419283f"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direct"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d4a0cb7-ae55-48d5-a406-62b6161f7132"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66f73841-383e-47b4-918f-ef797ca3c072"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9933c656-ac60-489f-87a5-fd507ec452c0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca29e250-e73d-4cfc-b176-b4c8170bafa9"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""868b525c-3a5f-4e41-acd0-e6b29de2475f"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d91e62b-fe4e-4c38-babe-7fd4dd178191"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""JournalActionMap"",
            ""id"": ""50293a43-e85c-4c50-a359-5fdaf77fa494"",
            ""actions"": [
                {
                    ""name"": ""ToggleInventory"",
                    ""type"": ""Button"",
                    ""id"": ""19f2377b-b7c1-4a32-893a-af73ac550bf0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleKeyBank"",
                    ""type"": ""Button"",
                    ""id"": ""362ce15b-d4bb-475a-a7e6-8142db472210"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateItem"",
                    ""type"": ""Button"",
                    ""id"": ""391633b5-9596-4ab1-a524-8f0b305ccb5b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a0506f48-6a21-403a-82e7-8bc100e9062a"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8837dab-8670-4b22-9f67-1e3a3732cfe6"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleKeyBank"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""558a1384-1559-4570-8c7a-678eada01d85"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PauseActionMap"",
            ""id"": ""bf74be5e-95eb-42fc-89ed-fafa1a7f236f"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""2182a538-65b8-4196-a299-534ecc50533f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e916ea19-2267-4060-b4c7-d2daa6f60c0e"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MainActionMap
        m_MainActionMap = asset.FindActionMap("MainActionMap", throwIfNotFound: true);
        m_MainActionMap_Move = m_MainActionMap.FindAction("Move", throwIfNotFound: true);
        m_MainActionMap_Sprint = m_MainActionMap.FindAction("Sprint", throwIfNotFound: true);
        m_MainActionMap_Direct = m_MainActionMap.FindAction("Direct", throwIfNotFound: true);
        m_MainActionMap_Aim = m_MainActionMap.FindAction("Aim", throwIfNotFound: true);
        m_MainActionMap_Shoot = m_MainActionMap.FindAction("Shoot", throwIfNotFound: true);
        m_MainActionMap_Reload = m_MainActionMap.FindAction("Reload", throwIfNotFound: true);
        m_MainActionMap_Interact = m_MainActionMap.FindAction("Interact", throwIfNotFound: true);
        m_MainActionMap_Scroll = m_MainActionMap.FindAction("Scroll", throwIfNotFound: true);
        m_MainActionMap_Heal = m_MainActionMap.FindAction("Heal", throwIfNotFound: true);
        // JournalActionMap
        m_JournalActionMap = asset.FindActionMap("JournalActionMap", throwIfNotFound: true);
        m_JournalActionMap_ToggleInventory = m_JournalActionMap.FindAction("ToggleInventory", throwIfNotFound: true);
        m_JournalActionMap_ToggleKeyBank = m_JournalActionMap.FindAction("ToggleKeyBank", throwIfNotFound: true);
        m_JournalActionMap_RotateItem = m_JournalActionMap.FindAction("RotateItem", throwIfNotFound: true);
        // PauseActionMap
        m_PauseActionMap = asset.FindActionMap("PauseActionMap", throwIfNotFound: true);
        m_PauseActionMap_Pause = m_PauseActionMap.FindAction("Pause", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // MainActionMap
    private readonly InputActionMap m_MainActionMap;
    private List<IMainActionMapActions> m_MainActionMapActionsCallbackInterfaces = new List<IMainActionMapActions>();
    private readonly InputAction m_MainActionMap_Move;
    private readonly InputAction m_MainActionMap_Sprint;
    private readonly InputAction m_MainActionMap_Direct;
    private readonly InputAction m_MainActionMap_Aim;
    private readonly InputAction m_MainActionMap_Shoot;
    private readonly InputAction m_MainActionMap_Reload;
    private readonly InputAction m_MainActionMap_Interact;
    private readonly InputAction m_MainActionMap_Scroll;
    private readonly InputAction m_MainActionMap_Heal;
    public struct MainActionMapActions
    {
        private @PlayerControls m_Wrapper;
        public MainActionMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_MainActionMap_Move;
        public InputAction @Sprint => m_Wrapper.m_MainActionMap_Sprint;
        public InputAction @Direct => m_Wrapper.m_MainActionMap_Direct;
        public InputAction @Aim => m_Wrapper.m_MainActionMap_Aim;
        public InputAction @Shoot => m_Wrapper.m_MainActionMap_Shoot;
        public InputAction @Reload => m_Wrapper.m_MainActionMap_Reload;
        public InputAction @Interact => m_Wrapper.m_MainActionMap_Interact;
        public InputAction @Scroll => m_Wrapper.m_MainActionMap_Scroll;
        public InputAction @Heal => m_Wrapper.m_MainActionMap_Heal;
        public InputActionMap Get() { return m_Wrapper.m_MainActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActionMapActions set) { return set.Get(); }
        public void AddCallbacks(IMainActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_MainActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MainActionMapActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Sprint.started += instance.OnSprint;
            @Sprint.performed += instance.OnSprint;
            @Sprint.canceled += instance.OnSprint;
            @Direct.started += instance.OnDirect;
            @Direct.performed += instance.OnDirect;
            @Direct.canceled += instance.OnDirect;
            @Aim.started += instance.OnAim;
            @Aim.performed += instance.OnAim;
            @Aim.canceled += instance.OnAim;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @Reload.started += instance.OnReload;
            @Reload.performed += instance.OnReload;
            @Reload.canceled += instance.OnReload;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Scroll.started += instance.OnScroll;
            @Scroll.performed += instance.OnScroll;
            @Scroll.canceled += instance.OnScroll;
            @Heal.started += instance.OnHeal;
            @Heal.performed += instance.OnHeal;
            @Heal.canceled += instance.OnHeal;
        }

        private void UnregisterCallbacks(IMainActionMapActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Sprint.started -= instance.OnSprint;
            @Sprint.performed -= instance.OnSprint;
            @Sprint.canceled -= instance.OnSprint;
            @Direct.started -= instance.OnDirect;
            @Direct.performed -= instance.OnDirect;
            @Direct.canceled -= instance.OnDirect;
            @Aim.started -= instance.OnAim;
            @Aim.performed -= instance.OnAim;
            @Aim.canceled -= instance.OnAim;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @Reload.started -= instance.OnReload;
            @Reload.performed -= instance.OnReload;
            @Reload.canceled -= instance.OnReload;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Scroll.started -= instance.OnScroll;
            @Scroll.performed -= instance.OnScroll;
            @Scroll.canceled -= instance.OnScroll;
            @Heal.started -= instance.OnHeal;
            @Heal.performed -= instance.OnHeal;
            @Heal.canceled -= instance.OnHeal;
        }

        public void RemoveCallbacks(IMainActionMapActions instance)
        {
            if (m_Wrapper.m_MainActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMainActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_MainActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MainActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MainActionMapActions @MainActionMap => new MainActionMapActions(this);

    // JournalActionMap
    private readonly InputActionMap m_JournalActionMap;
    private List<IJournalActionMapActions> m_JournalActionMapActionsCallbackInterfaces = new List<IJournalActionMapActions>();
    private readonly InputAction m_JournalActionMap_ToggleInventory;
    private readonly InputAction m_JournalActionMap_ToggleKeyBank;
    private readonly InputAction m_JournalActionMap_RotateItem;
    public struct JournalActionMapActions
    {
        private @PlayerControls m_Wrapper;
        public JournalActionMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleInventory => m_Wrapper.m_JournalActionMap_ToggleInventory;
        public InputAction @ToggleKeyBank => m_Wrapper.m_JournalActionMap_ToggleKeyBank;
        public InputAction @RotateItem => m_Wrapper.m_JournalActionMap_RotateItem;
        public InputActionMap Get() { return m_Wrapper.m_JournalActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JournalActionMapActions set) { return set.Get(); }
        public void AddCallbacks(IJournalActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_JournalActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_JournalActionMapActionsCallbackInterfaces.Add(instance);
            @ToggleInventory.started += instance.OnToggleInventory;
            @ToggleInventory.performed += instance.OnToggleInventory;
            @ToggleInventory.canceled += instance.OnToggleInventory;
            @ToggleKeyBank.started += instance.OnToggleKeyBank;
            @ToggleKeyBank.performed += instance.OnToggleKeyBank;
            @ToggleKeyBank.canceled += instance.OnToggleKeyBank;
            @RotateItem.started += instance.OnRotateItem;
            @RotateItem.performed += instance.OnRotateItem;
            @RotateItem.canceled += instance.OnRotateItem;
        }

        private void UnregisterCallbacks(IJournalActionMapActions instance)
        {
            @ToggleInventory.started -= instance.OnToggleInventory;
            @ToggleInventory.performed -= instance.OnToggleInventory;
            @ToggleInventory.canceled -= instance.OnToggleInventory;
            @ToggleKeyBank.started -= instance.OnToggleKeyBank;
            @ToggleKeyBank.performed -= instance.OnToggleKeyBank;
            @ToggleKeyBank.canceled -= instance.OnToggleKeyBank;
            @RotateItem.started -= instance.OnRotateItem;
            @RotateItem.performed -= instance.OnRotateItem;
            @RotateItem.canceled -= instance.OnRotateItem;
        }

        public void RemoveCallbacks(IJournalActionMapActions instance)
        {
            if (m_Wrapper.m_JournalActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IJournalActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_JournalActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_JournalActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public JournalActionMapActions @JournalActionMap => new JournalActionMapActions(this);

    // PauseActionMap
    private readonly InputActionMap m_PauseActionMap;
    private List<IPauseActionMapActions> m_PauseActionMapActionsCallbackInterfaces = new List<IPauseActionMapActions>();
    private readonly InputAction m_PauseActionMap_Pause;
    public struct PauseActionMapActions
    {
        private @PlayerControls m_Wrapper;
        public PauseActionMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_PauseActionMap_Pause;
        public InputActionMap Get() { return m_Wrapper.m_PauseActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseActionMapActions set) { return set.Get(); }
        public void AddCallbacks(IPauseActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_PauseActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PauseActionMapActionsCallbackInterfaces.Add(instance);
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IPauseActionMapActions instance)
        {
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IPauseActionMapActions instance)
        {
            if (m_Wrapper.m_PauseActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPauseActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_PauseActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PauseActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PauseActionMapActions @PauseActionMap => new PauseActionMapActions(this);
    public interface IMainActionMapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnDirect(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnScroll(InputAction.CallbackContext context);
        void OnHeal(InputAction.CallbackContext context);
    }
    public interface IJournalActionMapActions
    {
        void OnToggleInventory(InputAction.CallbackContext context);
        void OnToggleKeyBank(InputAction.CallbackContext context);
        void OnRotateItem(InputAction.CallbackContext context);
    }
    public interface IPauseActionMapActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
