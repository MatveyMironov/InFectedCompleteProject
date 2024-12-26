using TMPro;
using UnityEngine;

namespace KeySystem
{
    [RequireComponent(typeof(RectTransform))]
    public class KeyUI : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI nameText;
    }
}