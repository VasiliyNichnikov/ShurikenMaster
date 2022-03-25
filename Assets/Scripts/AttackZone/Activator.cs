using Enemies;
using TimeDilation;
using UnityEngine;

namespace AttackZone
{
    public class Activator: SwitchControl
    {
        public Activator(IEnemy[] enemies) : base(enemies)
        {
        }


        public override void TurnOn()
        {
            MonoBehaviour.print("Activator turn on");
        }
    }
}
