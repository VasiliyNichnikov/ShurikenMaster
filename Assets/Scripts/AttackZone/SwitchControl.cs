using Enemies;
using MyUtils;
using TimeDilation;
using UnityEngine;


namespace AttackZone
{
    public delegate void MobsDestroyed();
    
    public abstract class SwitchControl : MonoBehaviour
    {
        public IEnemy[] Enemies { get; set; }
        public ITimeControl TimeControl { get; set; }
        protected MobKillCounter Counter { get; private set; }
        
        protected bool CheckPlayer(GameObject obj)
        {
            return PlayerUtils.CheckThatObjectIsPlayer(obj);
        }

        public abstract void TurnOn(GameObject obj);

        public virtual void TurnOff()
        {
            TimeControl.Continue();
        }

        private void Start()
        {
            Counter = GetComponent<MobKillCounter>();
        }
    }
}