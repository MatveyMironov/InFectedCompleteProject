namespace HealingSystem
{
    public class HealingController
    {
        private Healing _healing;

        public HealingController(Healing healing)
        {
            _healing = healing;
        }

        public void Heal()
        {
            _healing.TryHeal();
        }
    }
}