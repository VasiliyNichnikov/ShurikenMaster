using Enemies;
using MyUtils;
using TimeDilation;
using UnityEngine;


namespace AttackZone
{
    public abstract class SwitchControl
    {
        protected IEnemy[] Enemies;
        protected ITimeControl TimeControl;
        
        protected SwitchControl(IEnemy[] enemies, ITimeControl timeControl)
        {
            Enemies = enemies;
            TimeControl = timeControl;
        }

        protected bool CheckPlayer(GameObject obj)
        {
            return PlayerUtils.CheckThatObjectIsPlayer(obj);
        }
        
        public abstract void TurnOn(GameObject obj);
    }
}