using UnityEngine;

namespace AttackZone
{
    public class Deactivator : SwitchControl
    {
        public override void TurnOn(GameObject obj)
        {
            if (CheckPlayer(obj) && Counter.Running)
            {
                TimeControl.Stop();
            }
        }
    }
}