using LevelTransition;
using MyUtils;
using UnityEngine;

namespace Enemies.Robot
{
    public class DestroyBullet : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (PlayerUtils.CheckThatObjectIsPlayer(other.gameObject))
            {
                WorkingWithLevel.Reload();
                Destroy(gameObject);
            }
        }
    }
}