using UnityEngine;
using UnityEngine.InputSystem;
using WeaponSystem;

namespace Core
{
    public class ShootInputListener : MonoBehaviour
    {
        [SerializeField] private InputActionReference shoot;

        [Space]
        [SerializeField] private WeaponUserController weaponUserController;

        private void OnEnable()
        {
            shoot.action.started += OnShootInput;
            shoot.action.canceled += OnShootInput;
        }

        private void OnDisable()
        {
            shoot.action.started += OnShootInput;
            shoot.action.canceled += OnShootInput;
        }

        private void OnShootInput(InputAction.CallbackContext context)
        {
            bool isTriggerPulled = context.ReadValueAsButton();
            weaponUserController.ControlTrigger(isTriggerPulled);
        }
    }
}