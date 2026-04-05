using UnityEngine;

namespace KeySystem
{
    public abstract class KeyConfiguration : ScriptableObject
    {
        [SerializeField] protected string keyName;

        public string Name => keyName;

        public abstract KeyDisplayer CreateKeyDisplayer();
    }
}