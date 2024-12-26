using UnityEngine;

namespace UISystem
{
    public abstract class LoadCapacityDisplayer : MonoBehaviour
    {
        [SerializeField] private int maxValue;

        public void DisplayCapacity(int capacity)
        {
            if (capacity > maxValue)
            {
                capacity = maxValue;
            }

            DisplayCapacityImplementation(capacity);
        }

        public void DisplayLoad(int load)
        {
            if (load > maxValue)
            {
                load = maxValue;
            }

            DisplayLoadImplementation(load);
        }

        protected abstract void DisplayCapacityImplementation(int capacity);

        protected abstract void DisplayLoadImplementation(int load);
    }
}
