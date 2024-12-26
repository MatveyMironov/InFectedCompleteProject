using KeySystem;
using System;
using UnityEngine;

namespace ProceduralLevelSystem
{
    public class LevelFragment : MonoBehaviour
    {
        [SerializeField] private FragmentConnection upperConnection;
        [SerializeField] private FragmentConnection rightConnection;
        [SerializeField] private FragmentConnection lowerConnection;
        [SerializeField] private FragmentConnection leftConnection;

        public FragmentConnection UpperConnection { get { return upperConnection; } }
        public FragmentConnection RightConnection { get { return rightConnection; } }
        public FragmentConnection LowerConnection { get { return lowerConnection; } }
        public FragmentConnection LeftConnection { get { return leftConnection; } }

        [Serializable]
        public class FragmentConnection
        {
            [SerializeField] private GameObject connectedStateObject;
            [SerializeField] private GameObject disconnectedStateObject;

            public void Connect()
            {
                connectedStateObject.SetActive(true);
                disconnectedStateObject.SetActive(false);
            }

            public void Disconnect()
            {
                disconnectedStateObject.SetActive(true);
                connectedStateObject.SetActive(false);
            }
        }

        [Serializable]
        public class ClosedArea
        {
            [SerializeField] private KeysCollector[] keysCollectors;
            

        }
    }
}