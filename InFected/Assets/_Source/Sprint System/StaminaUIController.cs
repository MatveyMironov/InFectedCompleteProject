namespace SprintSystem
{
    public class StaminaUIController
    {
        private readonly StaminaController _staminaController;
        private readonly StaminaUI _staminaUI;

        public StaminaUIController(StaminaController staminaController, StaminaUI staminaUI)
        {
            _staminaController = staminaController;
            _staminaUI = staminaUI;

            _staminaController.OnStaminaChanged += DisplayStamina;
            _staminaController.OnStaminaRecovered += HideStamina;

            _staminaUI.HideStamina();
        }

        private void DisplayStamina(int currentStamina)
        {
            _staminaUI.DisplayStamina(_staminaController.MaxStamina, currentStamina);
        }

        private void HideStamina()
        {
            _staminaUI.HideStamina();
        }
    }
}