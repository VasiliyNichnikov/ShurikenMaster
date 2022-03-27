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
                print("GameOver (Bullet)");
                Destroy(gameObject);
            }
        }
    }
}