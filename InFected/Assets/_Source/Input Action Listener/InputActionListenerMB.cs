using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace InputActionListenerSystem
{
    public class InputActionListenerMB : MonoBehaviour
    {
        [SerializeField] private InputActionReference inputAction;
        [SerializeField] private UnityEvent unityEvent;

        private void Start()
        {
            inputAction.action.Enable();
        }

        private void OnEnable()
        {
            //Debug.Log($"Input action listener on {gameObject.name} enabled");
            inputAction.action.performed += InvokeEvent;
        }

        private void OnDisable()
        {
            //Debug.Log($"Input action listener on {gameObject.name} disabled");
            inputAction.action.performed -= InvokeEvent;
        }

        private void InvokeEvent(InputAction.CallbackContext context)
        {
            //Debug.Log($"Input {inputAction.action.name} recieved by {gameObject.name}");
            unityEvent.Invoke();
        }
    }
}