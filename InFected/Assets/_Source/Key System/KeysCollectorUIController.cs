using System.Collections.Generic;
using System.Linq;
using UISystem;

namespace KeySystem
{
    public class KeysCollectorUIController
    {
        private KeysCollector _keysCollector;
        private KeyBank _keyBank;
        private LoadCapacityDisplayer _loadCapacityDisplayer;

        private List<KeyDataSO> _collectedKeys;

        public KeysCollectorUIController(KeysCollector keysCollector, KeyBank keyBank, LoadCapacityDisplayer loadCapacityDisplayer)
        {
            _keysCollector = keysCollector;
            _keyBank = keyBank;
            _loadCapacityDisplayer = loadCapacityDisplayer;

            _collectedKeys = new();

            _keyBank.OnKeyAdded += AddToCollectedKeys;
            _keyBank.OnKeyRemoved += RemoveFromCollectedKeys;

            DisplayCollectedKeys();
        }

        private void AddToCollectedKeys(KeyDataSO key)
        {
            if (CheckIfRequiredKey(key))
            {
                if (!_collectedKeys.Contains(key))
                {
                    _collectedKeys.Add(key);
                    DisplayCollectedKeys();
                }
            }
        }

        private void RemoveFromCollectedKeys(KeyDataSO key)
        {
            if (_collectedKeys.Contains(key))
            {
                _collectedKeys.Remove(key);
                DisplayCollectedKeys();
            }
        }

        private bool CheckIfRequiredKey(KeyDataSO key)
        {
            return _keysCollector.RequiredKeys.Contains(key);
        }

        private void DisplayCollectedKeys()
        {
            _loadCapacityDisplayer.DisplayCapacity(_keysCollector.RequiredKeys.Length);
            _loadCapacityDisplayer.DisplayLoad(_collectedKeys.Count);
        }
    }
}