using PlayerSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public class AimInputListener : MonoBehaviour
    {
        [SerializeField] private InputActionReference aim;

        [Space]
        [SerializeField] private Camera mainCamera;

        [Space]
        [SerializeField] private PlayerMovementController movementController;

        private void OnEnable()
        {
            aim.action.performed += OnAimInput;

            aim.action.Enable();
        }

        private void OnDisable()
        {
            aim.action.performed += OnAimInput;

            aim.action.Disable();
        }

        private void OnAimInput(InputAction.CallbackContext context)
        {
            Vector2 mouseScreenPosition = context.ReadValue<Vector2>();
            Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
            movementController.Aim(mouseWorldPosition);
        }
    }
}