using UnityEngine;
using UnityEngine.InputSystem;
using WeaponSystem;

namespace Core
{
    public class ScrollInputListener : MonoBehaviour
    {
        [SerializeField] private InputActionReference scroll;

        [Space]
        [SerializeField] private WeaponSelectorController weaponSelectorController;

        private void OnEnable()
        {
            scroll.action.performed += OnScrollInput;
        }

        private void OnDisable()
        {
            scroll.action.performed += OnScrollInput;
        }

        private void OnScrollInput(InputAction.CallbackContext context)
        {
            float scrollInput = context.ReadValue<float>();
            weaponSelectorController.SwitchWeapon(scrollInput);
        }
    }
}