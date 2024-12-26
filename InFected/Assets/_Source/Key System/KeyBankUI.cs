using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyBankUI : MonoBehaviour
    {
        [SerializeField] private Transform keyBankContent;

        public Transform KeyBankContent { get => keyBankContent; }
    }
}