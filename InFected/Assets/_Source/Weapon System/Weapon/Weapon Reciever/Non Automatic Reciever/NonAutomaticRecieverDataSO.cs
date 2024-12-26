using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "NewNonAutomaticRecieverData", menuName = "Weapons/Reciever Data/Non Automatic Reciever")]
    public class NonAutomaticRecieverDataSO : WeaponRecieverDataSO
    {
        [SerializeField] private NonAutomaticReciever.NonAutomaticRecieverParameters parameters;

        public override WeaponReciever WeaponReciever
        {
            get { return new NonAutomaticReciever(parameters); }
        }
    }
}