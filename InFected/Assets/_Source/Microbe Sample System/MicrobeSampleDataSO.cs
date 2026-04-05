using KeySystem;
using UnityEngine;

namespace MicrobeSampleSystem
{
    [CreateAssetMenu(fileName = "NewMicrobeSample", menuName = "Keys/Microbe Sample")]
    public class MicrobeSampleDataSO : KeyConfiguration
    {
        [SerializeField] private Sprite microbeSprite;
        [SerializeField] private MicrobeSampleDisplayer microbeSampleDisplayerPrefab;

        public override KeyDisplayer CreateKeyDisplayer()
        {
            MicrobeSampleDisplayer microbeSampleUI = Instantiate(microbeSampleDisplayerPrefab);
            microbeSampleUI.DisplayKey(keyName, microbeSprite);
            return microbeSampleUI;
        }
    }
}