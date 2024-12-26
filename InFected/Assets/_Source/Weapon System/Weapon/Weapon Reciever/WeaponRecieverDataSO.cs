using UnityEngine;

namespace WeaponSystem
{
    public abstract class WeaponRecieverDataSO : ScriptableObject
    {
        public abstract WeaponReciever WeaponReciever { get; }
    }
}
