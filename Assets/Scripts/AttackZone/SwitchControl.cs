using Enemies;
using TimeDilation;

namespace AttackZone
{
    public abstract class SwitchControl
    {
        protected IEnemy[] Enemies;

        protected SwitchControl(IEnemy[] enemies)
        {
            Enemies = enemies;
        }

        public abstract void TurnOn();
    }
}