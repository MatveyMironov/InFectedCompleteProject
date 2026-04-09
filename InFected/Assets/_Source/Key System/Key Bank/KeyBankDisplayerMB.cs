using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyBankDisplayerMB : MonoBehaviour
    {
        [SerializeField] private KeyBankSO keyBankSO;

        [Space]
        [SerializeField] private Transform content;

        private KeyBank _keyBank;
        private readonly Dictionary<KeySO, KeyDisplayerMB> _keysDisplayersDictionary = new();

        private void Awake()
        {
            _keyBank = keyBankSO.KeyBank;
        }

        private void OnEnable()
        {
            _keyBank.OnKeyAdded += AddKeyDisplayer;
            _keyBank.OnKeyRemoved += RemoveKeyDisplayer;

            foreach (KeySO key in _keyBank.Keys)
            {
                AddKeyDisplayer(key);
            }
        }

        private void OnDisable()
        {
            _keyBank.OnKeyAdded -= AddKeyDisplayer;
            _keyBank.OnKeyRemoved -= RemoveKeyDisplayer;
        }

        private void AddKeyDisplayer(KeySO key)
        {
            if (_keysDisplayersDictionary.TryAdd(key, null))
            {
                _keysDisplayersDictionary[key] = key.CreateKeyDisplayer();
                _keysDisplayersDictionary[key].transform.SetParent(content);
            }
        }

        private void RemoveKeyDisplayer(KeySO key)
        {
            if (_keysDisplayersDictionary.Remove(key, out KeyDisplayerMB displayer))
            {
                Destroy(displayer.gameObject);
            }
        }
    }
}