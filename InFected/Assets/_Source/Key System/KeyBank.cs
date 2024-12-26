using System;
using System.Collections.Generic;

namespace KeySystem
{
    public class KeyBank
    {
        private List<KeyDataSO> _keys;

        public KeyBank()
        {
            _keys = new();
        }

        public event Action<KeyDataSO> OnKeyAdded;
        public event Action<KeyDataSO> OnKeyRemoved;

        public bool TryAddKey(KeyDataSO key)
        {
            if (_keys.Contains(key))
            {
                return false;
            }

            _keys.Add(key);
            OnKeyAdded?.Invoke(key);
            return true;
        }

        public void RemoveKey(KeyDataSO key)
        {
            _keys.Remove(key);
            OnKeyRemoved?.Invoke(key);
        }

        public bool CheckIfContains(KeyDataSO key)
        {
            return _keys.Contains(key);
        }
    }
}