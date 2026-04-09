using CustomUISystem;
using UnityEngine;

namespace KeySystem
{
    public class KeysCollectorDisplayerMB : MonoBehaviour
    {
        [SerializeField] private KeysCollectorMB keysCollector;
        [SerializeField] private ANumberDisplayerMB requiredKeysCountDisplayer;

        private void Start()
        {
            requiredKeysCountDisplayer.DisplayNumber(keysCollector.RequiredKeysCount);
        }
    }
}