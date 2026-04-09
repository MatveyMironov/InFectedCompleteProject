using UnityEngine;

namespace KeySystem
{
    public abstract class KeySO : ScriptableObject
    {
        [SerializeField] protected string keyName;

        public string Name => keyName;

        public abstract KeyDisplayerMB CreateKeyDisplayer();
    }
}