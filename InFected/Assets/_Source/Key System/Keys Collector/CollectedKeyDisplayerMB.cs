using UnityEngine;

namespace KeySystem
{
    public class CollectedKeyDisplayerMB : MonoBehaviour
    {
        [SerializeField] private GameObject collectedIndicator;
        [SerializeField] private Transform keyDisplayerParent;

        private void Awake()
        {
            DisplayCollected(false);
        }

        public void DisplayKey(KeySO key)
        {
            KeyDisplayerMB displayer = key.CreateKeyDisplayer();
            displayer.transform.SetParent(keyDisplayerParent);
        }

        public void DisplayCollected(bool isCollected)
        {
            collectedIndicator.SetActive(isCollected);
        }
    }
}