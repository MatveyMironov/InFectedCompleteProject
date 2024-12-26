using UnityEngine;

namespace KeySystem
{
    public abstract class KeyDataSO : ScriptableObject
    {
        [SerializeField] protected string keyName;

        public string Name { get { return keyName; } }

        public abstract KeyUI CreateKeyUI(Transform parent);
    }
}