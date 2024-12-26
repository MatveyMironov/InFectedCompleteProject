namespace WeaponSystem
{
    public class WeaponUserController
    {
        private readonly WeaponUser _weaponUser;

        public WeaponUserController(WeaponUser weaponUser)
        {
            _weaponUser = weaponUser;
        }

        public void ControlTrigger(bool isTriggerPulled)
        {
            if (isTriggerPulled)
            {
                _weaponUser.PullWeaponTrigger();
            }
            else
            {
                _weaponUser.ReleaseWeaponTrigger();
            }
        }

        public void Reload()
        {
            _weaponUser.ReloadWeapon();
        }
    }
}