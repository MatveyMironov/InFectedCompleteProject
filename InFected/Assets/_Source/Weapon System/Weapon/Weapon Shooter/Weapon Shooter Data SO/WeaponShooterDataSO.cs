using UnityEngine;

namespace WeaponSystem
{
    public abstract class WeaponShooterDataSO : ScriptableObject
    {
        public abstract WeaponShooter WeaponShooter { get; }
    }
}