using UnityEngine;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour
    {   
        public bool IsDead { get; }

        public abstract void Attack();

        public abstract void EnablingPreAttackDelay();
    }
}