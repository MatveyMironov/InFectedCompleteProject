using UnityEngine;
using UnityEngine.InputSystem;
using WeaponSystem;

namespace Core
{
    public class ShootInputListener : MonoBehaviour
    {
        [SerializeField] private InputActionReference shoot;

        [Space]
        [SerializeField] private WeaponUser weaponUser;

        private void OnEnable()
        {
            shoot.action.started += OnShootInput;
            shoot.action.canceled += OnShootInput;

            shoot.action.Enable();
        }

        private void OnDisable()
        {
            shoot.action.started -= OnShootInput;
            shoot.action.canceled -= OnShootInput;

            shoot.action.Disable();
        }

        private void OnShootInput(InputAction.CallbackContext context)
        {
            bool isTriggerPulled = context.ReadValueAsButton();

            if (isTriggerPulled)
            {
                weaponUser.PullWeaponTrigger();
            }
            else
            {
                weaponUser.ReleaseWeaponTrigger();
            }
        }
    }
}