using UISystem;
using UnityEngine;

namespace SprintSystem
{
    public class StaminaUI : MonoBehaviour
    {
        [SerializeField] private GameObject staminaUIObject;
        [SerializeField] private LoadCapacityDisplayer staminaDisplayer;

        public void DisplayStamina(int maxStamina, int currentStamina)
        {
            staminaDisplayer.DisplayCapacity(maxStamina);
            staminaDisplayer.DisplayLoad(currentStamina);
            staminaUIObject.SetActive(true);
        }

        public void HideStamina()
        {
            staminaUIObject.SetActive(false);
        }
    }
}