using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KeySystem
{
    public class KeysCollectorCollectedKeysDisplayerMB : MonoBehaviour
    {
        [SerializeField] private KeysCollectorMB keysCollector;
        [SerializeField] private KeyBankSO keyBankSO;

        [Space]
        [SerializeField] private CollectedKeyDisplayerMB collectedKeyDisplayerPrefab;
        [SerializeField] private Transform content;

        private readonly Dictionary<KeySO, CollectedKeyDisplayerMB> _collectedKeysDisplayersDictionary = new();

        private KeyBank _keyBank;

        private void Awake()
        {
            _keyBank = keyBankSO.KeyBank;
        }

        private void Start()
        {
            DisplayRequiredKeys();
        }

        private void OnEnable()
        {
            _keyBank.OnKeyAdded += DisplayKeyCollected;
            _keyBank.OnKeyRemoved += DisplayKeyLost;

            DisplayCollectedKeys();
        }

        private void OnDisable()
        {
            _keyBank.OnKeyAdded -= DisplayKeyCollected;
            _keyBank.OnKeyRemoved -= DisplayKeyLost;
        }

        private void DisplayRequiredKeys()
        {
            foreach (var key in keysCollector.RequiredKeys)
            {
                if (_collectedKeysDisplayersDictionary.TryAdd(key, null))
                {
                    CollectedKeyDisplayerMB displayer = Instantiate(collectedKeyDisplayerPrefab, content);
                    displayer.DisplayKey(key);
                    _collectedKeysDisplayersDictionary[key] = displayer;
                }
            }
        }

        private void DisplayCollectedKeys()
        {
            foreach (var key in _keyBank.Keys)
            {
                DisplayKeyCollected(key);
            }
        }

        private void DisplayKeyCollected(KeySO key)
        {
            if (_collectedKeysDisplayersDictionary.TryGetValue(key, out var displayer))
            {
                displayer.DisplayCollected(true);
            }
        }

        private void DisplayKeyLost(KeySO key)
        {
            if (_collectedKeysDisplayersDictionary.TryGetValue(key, out var displayer))
            {
                displayer.DisplayCollected(false);
            }
        }
    }
}