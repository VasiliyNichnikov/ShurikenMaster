using Enemies;
using TimeDilation;
using UnityEngine;

namespace AttackZone
{
    public class Deactivator: SwitchControl
    {
        public Deactivator(IEnemy[] enemies) : base(enemies)
        {
        }


        public override void TurnOn()
        {
            MonoBehaviour.print("Deactivator turn on");
        }
    }
}