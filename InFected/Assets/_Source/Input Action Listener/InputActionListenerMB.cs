using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace InputActionListenerSystem
{
    public class InputActionListenerMB : MonoBehaviour
    {
        [SerializeField] private InputActionReference inputAction;
        [SerializeField] private UnityEvent unityEvent;

        private void OnEnable()
        {
            inputAction.action.performed += InvokeEvent;

            inputAction.action.Enable();
        }

        private void OnDisable()
        {
            inputAction.action.performed -= InvokeEvent;

            inputAction.action.Disable();
        }

        private void InvokeEvent(InputAction.CallbackContext context)
        {
            unityEvent.Invoke();
        }
    }
}