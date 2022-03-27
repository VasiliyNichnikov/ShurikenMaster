using MyUtils;
using UnityEngine;

namespace Enemies
{
    public class Penetration : MonoBehaviour
    {
        private Enemy _enemy;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (ShurikenUtils.CheckThatObjectIsSuriken(other.gameObject))
            {
                _enemy.Die();
            }
        }
    }
}