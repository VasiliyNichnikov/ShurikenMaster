using Enemies;
using TimeDilation;
using UnityEngine;

namespace AttackZone
{
    public class Deactivator : SwitchControl
    {
        private int _numberKilledEnemies;

        public Deactivator(IEnemy[] enemies, ITimeControl timeControl) : base(enemies, timeControl)
        {
            _numberKilledEnemies = 0;
        }

        public override void TurnOn(GameObject obj)
        {
            if (CheckPlayer(obj))
            {
                TimeControl.Stop();
            }
        }
    }
}