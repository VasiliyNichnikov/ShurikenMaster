using UnityEngine;

namespace AttackZone
{
    public class Activator : SwitchControl
    {
        
        
        public override void TurnOn(GameObject obj)
        {
            if (CheckPlayer(obj) && Counter.Running == false)
            {
                print("Enemies go into battle");
                Counter.ToRun(Enemies, TurnOff);
            }
        }
    }
}