using UnityEngine;

namespace KeySystem
{

    [CreateAssetMenu(fileName = "New Key Bank", menuName = "Key Bank")]
    public class KeyBankSO : ScriptableObject
    {
        private KeyBank _keyBank;
        public KeyBank KeyBank
        {
            get
            {
                _keyBank ??= new();

                //As this property FOR NOW is uded only at the start of a scene, we can remove all keys from key bank, without affecting gameplay
                //The reason we need to do this is to remove keys from the previous level, which would otherwise appear in key bank
                //This is caused by the fact that key bank is stored in scriptable object, which is referenced on both levels, hence never unloading and resetting
                _keyBank.RemoveAllKeys();

                return _keyBank;
            }
        }
    }
}