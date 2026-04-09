using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyBankDisplayerMB : MonoBehaviour
    {
        [SerializeField] private KeyBank keyBank;

        [Space]
        [SerializeField] private Transform content;

        private readonly Dictionary<KeySO, KeyDisplayerMB> _keysDisplayersDictionary = new();

        private void OnEnable()
        {
            keyBank.OnKeyAdded += AddKeyDisplayer;
            keyBank.OnKeyRemoved += RemoveKeyDisplayer;

            foreach (KeySO key in keyBank.Keys)
            {
                AddKeyDisplayer(key);
            }
        }

        private void OnDisable()
        {
            keyBank.OnKeyAdded -= AddKeyDisplayer;
            keyBank.OnKeyRemoved -= RemoveKeyDisplayer;
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