namespace WeaponSystem
{
    public class UnlimitedReloadMagazine : WeaponMagazine
    {
        public UnlimitedReloadMagazine(MagazineParameters parameters) : base(parameters)
        {

        }

        public override int MaxAcceptedReload
        {
            get => Parameters.Capacity - Load; 
        }
    }
}