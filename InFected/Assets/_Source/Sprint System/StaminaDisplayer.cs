using CustomUISystem;
using UnityEngine;

namespace SprintSystem
{
    public class StaminaDisplayer : MonoBehaviour
    {
        [SerializeField] private GameObject displayerObject;
        [SerializeField] private ANumberDisplayerMB staminaValueDisplayer;

        [Space]
        [SerializeField] private StaminaController staminaController;

        private void Awake()
        {
            HideStamina();
        }

        private void OnEnable()
        {
            staminaController.OnStaminaRecovered += HideStamina;
            staminaController.OnStaminaChanged += DisplayStamina;
            staminaValueDisplayer.DisplayNumber(staminaController.AvailableStamina);
        }

        private void OnDisable()
        {
            staminaController.OnStaminaRecovered -= HideStamina;
            staminaController.OnStaminaChanged -= DisplayStamina;
        }

        private void DisplayStamina()
        {
            staminaValueDisplayer.DisplayNumber(staminaController.CurrentStamina);
            displayerObject.SetActive(true);
        }

        private void HideStamina()
        {
            displayerObject.SetActive(false);
        }
    }
}