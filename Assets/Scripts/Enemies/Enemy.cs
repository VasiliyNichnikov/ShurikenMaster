using UnityEngine;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour, IEnemy
    {
        // TODO тестовая переменная
        [Header("Используется для тестирования")] public bool IsDeadInspector;

        public bool IsDead => IsDeadInspector;

        public void Attack()
        {
            
        }
    }
}