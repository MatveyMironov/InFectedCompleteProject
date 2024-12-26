using System;
using UnityEngine;

namespace WeaponSystem
{
    [Serializable]
    public class WeaponUseParameters
    {
        [field: SerializeField] public float ReloadDifficulty { get; private set; }
        [field: SerializeField] public float RechargeDifficulty { get; private set; }
    }
}