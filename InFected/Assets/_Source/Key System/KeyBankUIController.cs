using System.Collections.Generic;

namespace KeySystem
{
    public class KeyBankUIController
    {
        private readonly KeyBankUI _keyBankUI;
        private readonly KeyBank _keyBank;

        private Dictionary<KeyDataSO, KeyUI> _keysAndUIs;

        public KeyBankUIController(KeyBankUI keyBankUI, KeyBank keyBank)
        {
            _keyBankUI = keyBankUI;
            _keyBank = keyBank;

            _keysAndUIs = new();

            _keyBank.OnKeyAdded += CreateKeyUI;
            _keyBank.OnKeyRemoved += DestroyKeyUI;
        }

        private void CreateKeyUI(KeyDataSO key)
        {
            if (_keysAndUIs.ContainsKey(key))
            {
                throw new System.Exception("UI for this key already exists");
            }

            KeyUI keyUI = key.CreateKeyUI(_keyBankUI.KeyBankContent);
            _keysAndUIs.Add(key, keyUI);
        }

        private void DestroyKeyUI(KeyDataSO key)
        {
            if (_keysAndUIs.ContainsKey(key))
            {
                UnityEngine.Object.Destroy(_keysAndUIs[key]);
                _keysAndUIs.Remove(key);
            }
        }
    }
}