using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "NewFullyAutomaticRecieverData", menuName = "Weapons/Reciever Data/Fully Automatic Reciever")]
    public class FullyAutomaticRecieverDataSO : WeaponRecieverDataSO
    {
        [SerializeField] private AutomaticReciever.AutomaticRecieverParameters parameters;

        public override WeaponReciever WeaponReciever
        {
            get { return new FullyAutomaticReciever(parameters); }
        }
    }
}