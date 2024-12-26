using KeySystem;
using UnityEngine;

namespace MicrobeSampleSystem
{
    [CreateAssetMenu(fileName = "NewMicrobeSample", menuName = "Keys/Microbe Sample")]
    public class MicrobeSampleDataSO : KeyDataSO
    {
        [SerializeField] private Sprite microbeSprite;
        [SerializeField] private MicrobeSampleUI microbeSampleUIPrefab;

        public override KeyUI CreateKeyUI(Transform parent)
        {
            MicrobeSampleUI microbeSampleUI = Instantiate(microbeSampleUIPrefab, parent);
            microbeSampleUI.DisplayKey(keyName, microbeSprite);
            return microbeSampleUI;
        }
    }
}