using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public abstract class WeaponMagazineDataSO : ScriptableObject
    {
        public abstract WeaponMagazine WeaponMagazine { get; }
    }
}