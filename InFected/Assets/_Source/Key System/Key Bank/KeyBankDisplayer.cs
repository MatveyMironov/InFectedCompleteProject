using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyBankDisplayer : MonoBehaviour
    {
        [SerializeField] private KeyBank keyBank;

        [Space]
        [SerializeField] private Transform content;

        private readonly Dictionary<KeyConfiguration, KeyDisplayer> _keysDisplayersDictionary = new();

        private void OnEnable()
        {
            keyBank.OnKeyAdded += AddKeyDisplayer;
            keyBank.OnKeyRemoved += RemoveKeyDisplayer;

            foreach (KeyConfiguration key in keyBank.Keys)
            {
                AddKeyDisplayer(key);
            }
        }

        private void OnDisable()
        {
            keyBank.OnKeyAdded -= AddKeyDisplayer;
            keyBank.OnKeyRemoved -= RemoveKeyDisplayer;
        }

        private void AddKeyDisplayer(KeyConfiguration key)
        {
            if (_keysDisplayersDictionary.TryAdd(key, null))
            {
                _keysDisplayersDictionary[key] = key.CreateKeyDisplayer();
                _keysDisplayersDictionary[key].transform.SetParent(content);
            }
        }

        private void RemoveKeyDisplayer(KeyConfiguration key)
        {
            if (_keysDisplayersDictionary.Remove(key, out KeyDisplayer displayer))
            {
                Destroy(displayer.gameObject);
            }
        }
    }
}