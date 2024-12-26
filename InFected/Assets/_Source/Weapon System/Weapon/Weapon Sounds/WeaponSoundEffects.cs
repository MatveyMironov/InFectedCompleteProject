using System;
using UnityEngine;

[Serializable]
public class WeaponSoundEffects
{
    [field: SerializeField] public AudioClip ShotSound { get; private set; }
    [field: SerializeField] public AudioClip EmptyMagazineSound { get; private set; }
}
