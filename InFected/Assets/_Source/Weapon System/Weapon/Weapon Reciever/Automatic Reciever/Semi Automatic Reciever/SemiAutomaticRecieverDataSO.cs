using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "NewSemiAutomaticRecieverData", menuName = "Weapons/Reciever Data/Semi Automatic Reciever")]
    public class SemiAutomaticRecieverDataSO : WeaponRecieverDataSO
    {
        [SerializeField] private AutomaticReciever.AutomaticRecieverParameters parameters;

        public override WeaponReciever WeaponReciever
        {
            get { return new SemiAutomaticReciever(parameters); }
        }
    }
}