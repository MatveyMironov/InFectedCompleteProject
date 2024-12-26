using UnityEngine;

namespace WeaponSystem
{
    public class WeaponBody : MonoBehaviour
    {
        // This class will store weapon model and transforms such as muzzle

        [SerializeField] private Transform muzzle;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private Renderer modelRenderer;
        [SerializeField] private Animator modelAnimator;

        public Transform Muzzle { get => muzzle; }
        public AudioSource AudioSource { get => audioSource; }
        public Renderer ModelRenderer { get => modelRenderer; }
        public Animator ModelAnimator { get => modelAnimator; }
    }
}
