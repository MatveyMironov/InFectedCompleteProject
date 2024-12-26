using System;
using UnityEngine;

namespace WeaponSystem
{
    [Serializable]
    public class WeaponUseSoundEffects
    {
        [field: SerializeField] public AudioClip RechargingSound { get; private set; }
        [field: SerializeField] public AudioClip ReloadingingSound { get; private set; }
    }
}