using System;

namespace SprintSystem
{
    public class PositiveIntegerParameter
    {
        private int _currentValue;

        public PositiveIntegerParameter(int maxValue)
        {
            MaxValue = maxValue;
        }

        public int CurrentValue { get { return _currentValue; } set { ChangeValue(value); } }
        public int MaxValue { get; }

        public event Action OnValueChanged;
        public event Action OnValueExpired;

        private void ChangeValue(int newValue)
        {
            if (newValue < 0)
            {
                newValue = 0;
            }

            if (newValue > MaxValue)
            {
                newValue = MaxValue;
            }

            _currentValue = newValue;
            OnValueChanged?.Invoke();

            if (_currentValue == 0)
            {
                OnValueExpired?.Invoke();
            }
        }
    }
}