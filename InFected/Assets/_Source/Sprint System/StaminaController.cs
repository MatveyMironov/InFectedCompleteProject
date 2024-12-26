using System;

namespace SprintSystem
{
    public class StaminaController
    {
        private readonly PositiveIntegerParameter _stamina;
        private readonly StaminaRecovery _staminaRecovery;

        public StaminaController(int maxStamina, float staminaRecoveryDelay, float staminaRecoveryRate)
        {
            _stamina = new(maxStamina);
            _stamina.CurrentValue = maxStamina;

            IsStaminaReady = true;

            _stamina.OnValueChanged += InvokeOnStaminaChanged;
            _stamina.OnValueExpired += BlockStamina;

            _staminaRecovery = new(_stamina, staminaRecoveryDelay, staminaRecoveryRate);

            _staminaRecovery.OnStaminaFullyRecovered += InvokeOnStaminaRecovered;
            _staminaRecovery.OnStaminaFullyRecovered += UnblockStamina;
        }

        public bool IsStaminaReady { get; private set; }
        public int CurrentStamina { get { return _stamina.CurrentValue; } }
        public int MaxStamina { get { return _stamina.MaxValue; } }
        public int AvailableStamina { get { return IsStaminaReady ? _stamina.CurrentValue : 0; } set { ChangeStamina(value); } }

        public event Action<int> OnStaminaChanged;
        public event Action OnStaminaBlocked;
        public event Action OnStaminaRecovered;

        private void ChangeStamina(int newStamina)
        {
            if (newStamina < _stamina.CurrentValue)
            {
                _staminaRecovery.StopRecoverStamina();
            }

            _stamina.CurrentValue = newStamina;
        }

        private void BlockStamina()
        {
            IsStaminaReady = false;
            OnStaminaBlocked?.Invoke();
        }

        private void UnblockStamina()
        {
            IsStaminaReady = true;
        }

        private void InvokeOnStaminaChanged()
        {
            OnStaminaChanged?.Invoke(CurrentStamina);
        }

        private void InvokeOnStaminaRecovered()
        {
            OnStaminaRecovered?.Invoke();
        }
    }
}