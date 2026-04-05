using PlayerSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public class MovementInputListener : MonoBehaviour
    {
        [SerializeField] private InputActionReference move;

        [Space]
        [SerializeField] private PlayerMovementController movementController;

        private void OnEnable()
        {
            move.action.started += OnMoveInput;
            move.action.performed += OnMoveInput;
            move.action.canceled += OnMoveInput;

            move.action.Enable();
        }

        private void OnDisable()
        {
            move.action.started -= OnMoveInput;
            move.action.performed -= OnMoveInput;
            move.action.canceled -= OnMoveInput;

            move.action.Disable();
        }

        private void OnMoveInput(InputAction.CallbackContext context)
        {
            Vector2 movementInput = context.ReadValue<Vector2>();
            movementController.Move(movementInput);
        }
    }
}
