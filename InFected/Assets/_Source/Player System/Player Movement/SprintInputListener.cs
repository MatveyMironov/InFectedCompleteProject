using PlayerSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public class SprintInputListener : MonoBehaviour
    {
        [SerializeField] private InputActionReference sprint;

        [Space]
        [SerializeField] private PlayerMovementController movementController;

        private void OnEnable()
        {
            sprint.action.started += OnSprintInput;
            sprint.action.canceled += OnSprintInput;

            sprint.action.Enable();
        }

        private void OnDisable()
        {
            sprint.action.started += OnSprintInput;
            sprint.action.canceled += OnSprintInput;

            sprint.action.Disable();
        }

        private void OnSprintInput(InputAction.CallbackContext context)
        {
            bool shouldSprint = context.ReadValueAsButton();
            movementController.Sprint(shouldSprint);
        }
    }
}