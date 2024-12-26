namespace WeaponSystem
{
    public class SingleReloadMagazine : WeaponMagazine
    {
        public SingleReloadMagazine(MagazineParameters parameters) : base(parameters)
        {

        }

        public override int MaxAcceptedReload
        {
            get => (Parameters.Capacity - Load == 0) ? 0 : 1;
        }
    }
}