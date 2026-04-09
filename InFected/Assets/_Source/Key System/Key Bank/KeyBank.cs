using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KeySystem
{
    [CreateAssetMenu(fileName = "New Key Bank", menuName = "Key Bank")]
    public class KeyBank : ScriptableObject
    {
        private readonly HashSet<KeySO> _keys = new();

        public KeySO[] Keys => _keys.ToArray();
        public event Action<KeySO> OnKeyAdded;
        public event Action<KeySO> OnKeyRemoved;

        public bool TryAddKey(KeySO key)
        {
            if (_keys.Add(key))
            {
                OnKeyAdded?.Invoke(key);
                return true;
            }

            return false;
        }

        public bool TryRemoveKey(KeySO key)
        {
            if (_keys.Remove(key))
            {
                OnKeyRemoved?.Invoke(key);
                return true;
            }
            
            return false;
        }

        public bool CheckIfContainsKey(KeySO key)
        {
            return _keys.Contains(key);
        }
    }
}