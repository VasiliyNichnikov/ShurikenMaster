using UnityEngine;

namespace AttackZone
{
    public class Activator : SwitchControl
    {
        public override void TurnOn(GameObject obj)
        {
            if (!CheckPlayer(obj) || Counter.Running) return;
            
            Counter.ToRun(Enemies, TurnOff);
            StartEnemies();
        }

        private void StartEnemies()
        {
            foreach (var enemy in Enemies)
            {
                if(enemy == null)
                    continue;
                enemy.EnablingPreAttackDelay();
            }
        }
    }
}