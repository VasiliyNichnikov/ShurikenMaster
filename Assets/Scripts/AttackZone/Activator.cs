using Enemies;
using TimeDilation;
using UnityEngine;

namespace AttackZone
{
    public class Activator: SwitchControl
    {
        public Activator(IEnemy[] enemies, ITimeControl timeControl) : base(enemies, timeControl)
        {
        }
        
        public override void TurnOn(GameObject obj)
        {
            if (CheckPlayer(obj))
            {
                MonoBehaviour.print("Enemies go into battle");
            }
        }
    }
}
