using KeySystem;
using UnityEngine;

namespace MicrobeSampleSystem
{
    public class MicrobeSampleContainer : KeyContainer
    {
        [SerializeField] private MicrobeSampleDataSO microbeSample;

        protected override KeyConfiguration _key => microbeSample;
    }
}