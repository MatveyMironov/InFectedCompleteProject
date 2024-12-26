using KeySystem;
using UnityEngine;

namespace MicrobeSampleSystem
{
    public class MicrobeSampleContainer : KeyContainer
    {
        [SerializeField] private MicrobeSampleDataSO microbeSample;

        protected override KeyDataSO _key => microbeSample;
    }
}