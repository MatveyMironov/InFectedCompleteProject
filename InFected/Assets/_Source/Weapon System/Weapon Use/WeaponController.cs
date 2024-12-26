using InventorySystem;
using System;
using UnityEngine;

namespace WeaponSystem
{
    public class WeaponController
    {
        private readonly Weapon _weapon;
        private readonly WeaponBody _body;

        public WeaponController(Weapon weapon, WeaponBody body)
        {
            _weapon = weapon;
            _body = body;

            _weapon.Magazine.OnLoadChanged += InvokeOnMagazineLoadChanged;
        }

        public int WeaponID { get { return _weapon.GetHashCode(); } }
        public ItemDataSO AmmunitionType { get => _weapon.Magazine.Parameters.AmmunitionType; }
        public int MagazineCapacity { get => _weapon.Magazine.Parameters.Capacity; }
        public int MagazineLoad { get => _weapon.Magazine.Load; }
        public int MagazineMaxAcceptedReload { get => _weapon.Magazine.MaxAcceptedReload; }

        public bool IsRecharged { get => _weapon.Reciever.IsRecharged; }
        public bool CanBeManuallyRecharged {  get => _weapon.Reciever.CanBeManuallyRecharged; }

        public string WeaponName { get => _weapon.Name; }
        public Sprite WeaponSprite { get => _weapon.Icon; }

        public WeaponBody WeaponBody { get => _body; }

        public WeaponUseParameters UseParameters { get => _weapon.UseParameters; }
        public WeaponUseSoundEffects UseSoundEffects { get => _weapon.UseSoundEffects; }
        public AnimatorOverrideController Animator { get => _weapon.Animator; }
        public AudioSource WeaponAudioSource { get => _body.AudioSource; }

        public event Action<int> OnMagazineLoadChanged;

        public void PullTheTrigger()
        {
            _weapon.Reciever.PullTheTrigger(_weapon.Magazine, _body, _weapon.SoundEffects, _weapon.Shooter);
        }

        public void ReleaseTheTrigger()
        {
            _weapon.Reciever.ReleaseTheTrigger();
        }

        public void Reload(int ammunition)
        {
            _weapon.Magazine.AddAmmunition(ammunition);
        }

        public void RechargeManually()
        {
            _weapon.Reciever.RechargeManually(_weapon.Magazine, _body, _weapon.SoundEffects, _weapon.Shooter);
        }

        private void InvokeOnMagazineLoadChanged(int load)
        {
            OnMagazineLoadChanged?.Invoke(load);
        }
    }
}
