using System.Collections;
using UnityEngine;

namespace CustomUtilities
{
    public class CoroutineManager : MonoBehaviour
    {
        private static CoroutineManager m_instance;

        private static CoroutineManager _instance
        {
            get
            {
                if (m_instance == null)
                {
                    GameObject instanceObject = new GameObject("Coroutine Manager");
                    m_instance = instanceObject.AddComponent<CoroutineManager>();
                    DontDestroyOnLoad(instanceObject);
                }

                return m_instance;
            }
        }

        public static Coroutine StartRoutine(IEnumerator coroutine)
        {
            return _instance.StartCoroutine(coroutine);
        }

        public static void StopRoutine(Coroutine coroutine)
        {
            _instance.StopCoroutine(coroutine);
        }
    }
}