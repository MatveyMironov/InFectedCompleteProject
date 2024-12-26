using CustomUtilities;
using System;
using System.Collections;
using UnityEngine;

namespace SprintSystem
{
    public class StaminaRecovery
    {
        private PositiveIntegerParameter _stamina;

        private float _staminaRecoveryDelay;
        private float _staminaRecoveryRate;

        private Coroutine _recoverStamina;
        private Coroutine _delayStaminaRecovery;

        public StaminaRecovery(PositiveIntegerParameter stamina, float staminaRecoveryDelay, float staminaRecoveryRate)
        {
            _stamina = stamina;
            _staminaRecoveryDelay = staminaRecoveryDelay;
            _staminaRecoveryRate = staminaRecoveryRate;
        }

        public event Action OnStaminaFullyRecovered;

        private void StartRecoverStamina()
        {
            _delayStaminaRecovery = null;

            _recoverStamina = CoroutineManager.StartRoutine(RecoverStamina());
        }

        public void StopRecoverStamina()
        {
            if (_recoverStamina != null)
            {
                CoroutineManager.StopRoutine(_recoverStamina);
                _recoverStamina = null;
            }

            if (_delayStaminaRecovery != null)
            {
                CoroutineManager.StopRoutine(_delayStaminaRecovery);
            }

            _delayStaminaRecovery = CoroutineManager.StartRoutine(DelayStaminaRecovery());
        }

        private IEnumerator DelayStaminaRecovery()
        {
            yield return new WaitForSeconds(_staminaRecoveryDelay);

            StartRecoverStamina();
        }

        private IEnumerator RecoverStamina()
        {
            WaitForSeconds recoveryInterval = new(1 / _staminaRecoveryRate);

            while (!CheckIfStaminaIsFull())
            {
                yield return recoveryInterval;

                _stamina.CurrentValue += 1;
            }

            OnStaminaFullyRecovered?.Invoke();
        }

        private bool CheckIfStaminaIsFull()
        {
            return _stamina.CurrentValue == _stamina.MaxValue;
        }
    }
}