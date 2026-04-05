using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KeySystem
{
    [CreateAssetMenu(fileName = "New Key Bank", menuName = "Key Bank")]
    public class KeyBank : ScriptableObject
    {
        private readonly HashSet<KeyConfiguration> _keys = new();

        public KeyConfiguration[] Keys => _keys.ToArray();
        public event Action<KeyConfiguration> OnKeyAdded;
        public event Action<KeyConfiguration> OnKeyRemoved;

        public bool TryAddKey(KeyConfiguration key)
        {
            if (_keys.Add(key))
            {
                OnKeyAdded?.Invoke(key);
                return true;
            }

            return false;
        }

        public bool TryRemoveKey(KeyConfiguration key)
        {
            if (_keys.Remove(key))
            {
                OnKeyRemoved?.Invoke(key);
                return true;
            }
            
            return false;
        }

        public bool CheckIfContainsKey(KeyConfiguration key)
        {
            return _keys.Contains(key);
        }
    }
}