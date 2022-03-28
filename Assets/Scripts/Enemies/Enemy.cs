using UnityEngine;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour
    {   
        public bool IsDead { get; protected set; }

        public abstract void Die();

        public abstract void EnablingPreAttackDelay();
    }
}