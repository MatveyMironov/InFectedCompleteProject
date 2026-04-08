using System;
using System.Collections;
using UnityEngine;

namespace SprintSystem
{
    public class StaminaController : MonoBehaviour
    {
        [SerializeField] private float staminaRecoveryDelay;
        [SerializeField] private float staminaRecoveryRate;

        private Coroutine _recoveringStamina;
        private Coroutine _delayStaminaRecovery;

        public bool IsStaminaReady { get; private set; }
        public float CurrentStamina { get; private set; }
        public float AvailableStamina { get => IsStaminaReady ? CurrentStamina : 0.0f; set => ChangeStamina(value); }

        public event Action OnStaminaChanged;
        public event Action OnStaminaRecovered;

        private void Awake()
        {
            IsStaminaReady = true;
            CurrentStamina = 1.0f;
        }

        private void ChangeStamina(float value)
        {
            if (value < 0.0f) { value = 0.0f; }
            if (value > 1.0f) { value = 1.0f; }

            if (value < CurrentStamina)
            {
                StopRecoveringStamina();
            }

            CurrentStamina = value;
            OnStaminaChanged?.Invoke();
        }

        private void StartRecoveringStamina()
        {
            if (_recoveringStamina != null) { return; }

            if (_delayStaminaRecovery != null)
            {
                StopCoroutine(_delayStaminaRecovery);
                _delayStaminaRecovery = null;
            }

            _recoveringStamina = StartCoroutine(RecoveringStamina());
        }

        private void StopRecoveringStamina()
        {
            if (_recoveringStamina != null)
            {
                StopCoroutine(_recoveringStamina);
                _recoveringStamina = null;
            }

            if (_delayStaminaRecovery != null)
            {
                StopCoroutine(_delayStaminaRecovery);
            }

            _delayStaminaRecovery = StartCoroutine(DelayRecoveringStamina());
        }

        private IEnumerator DelayRecoveringStamina()
        {
            yield return new WaitForSeconds(staminaRecoveryDelay);
            StartRecoveringStamina();
        }

        private IEnumerator RecoveringStamina()
        {
            while (CurrentStamina < 1.0f)
            {
                yield return null;
                CurrentStamina = Mathf.MoveTowards(CurrentStamina, 1.0f, Time.deltaTime * staminaRecoveryRate);
                OnStaminaChanged?.Invoke();
            }

            OnStaminaRecovered?.Invoke();
        }
    }
}