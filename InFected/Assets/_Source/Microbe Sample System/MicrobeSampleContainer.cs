using InteractionSystem;
using KeySystem;
using UnityEngine;

namespace MicrobeSampleSystem
{
    public class MicrobeSampleContainer : KeyContainer
    {
        [SerializeField] private MicrobeSampleDataSO microbeSample;
        [SerializeField] private KeyBankSO keyBankSO;

        private KeyBank _keyBank;
        protected override KeySO _key => microbeSample;

        private void Awake()
        {
            _keyBank = keyBankSO.KeyBank;
        }

        public override void Interact(InteractionData interaction)
        {
            if (_keyBank.TryAddKey(_key))
            {
                gameObject.SetActive(false);
            }
        }
    }
}