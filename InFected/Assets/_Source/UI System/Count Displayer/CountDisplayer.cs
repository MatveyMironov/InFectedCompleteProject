using UnityEngine;

namespace UISystem
{
    public abstract class CountDisplayer : MonoBehaviour
    {
        [SerializeField] private int maxCount;

        public void DisplayCount(int count)
        {
            if (count > maxCount)
            {
                count = maxCount;
            }

            DisplayImplementation(count);
        }

        protected abstract void DisplayImplementation(int count);
    }
}