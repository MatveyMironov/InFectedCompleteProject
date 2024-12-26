using InventorySystem;
using System;
using UnityEngine;

namespace WeaponSystem
{
    public abstract class WeaponMagazine
    {
        public WeaponMagazine(MagazineParameters parameters)
        {
            Parameters = parameters;
            Load = 0;
        }

        public MagazineParameters Parameters { get; }

        public int Load { get; private set; }

        public abstract int MaxAcceptedReload { get; }

        public event Action<int> OnLoadChanged;

        public void AddAmmunition(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Can't add negative or zero amount of ammunition");
            }

            if (amount > MaxAcceptedReload)
            {
                throw new ArgumentOutOfRangeException("Can't add more ammunition then maximum accepted load");
            }

            Load += amount;
            OnLoadChanged?.Invoke(Load);
        }

        public void RemoveAmmunition(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Can't remove negative or zero amount of ammunition");
            }

            if (amount > Load)
            {
                throw new ArgumentOutOfRangeException("Can't remove more ammunition than is stored");
            }

            Load -= amount;
            OnLoadChanged?.Invoke(Load);
        }

        [Serializable]
        public class MagazineParameters
        {
            [field: SerializeField] public ItemDataSO AmmunitionType { get; private set; }
            [field: SerializeField] public int Capacity { get; private set; }
        }
    }
}
