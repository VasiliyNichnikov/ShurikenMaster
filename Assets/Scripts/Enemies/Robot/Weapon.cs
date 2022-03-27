using System.Collections;
using Parameters.Enemy;
using UnityEngine;

namespace Enemies.Robot
{
    public class Weapon : Action
    {
        private Transform _parentBullet;

        public Weapon(Transform transformObj, Transform player, Transform parentBullet, RobotParameter parameter) :
            base(transformObj, player, parameter)
        {
            _parentBullet = parentBullet;
        }

        public IEnumerator Shoot()
        {
            Vector3 direction = Player.position - TransformObj.position;
            while (true)
            {
                float delay = Random.Range(Parameter.MinDelayBetweenShooting, Parameter.MaxDelayBetweenShooting);
                yield return new WaitForSeconds(delay);
                Transform bullet = CreateBullet();
                yield return Fly(direction, bullet);
            }
        }

        private Transform CreateBullet()
        {
            GameObject bullet = Object.Instantiate(Parameter.Bullet, TransformObj.position, Quaternion.identity, _parentBullet);
            return bullet.transform;
        }

        private IEnumerator Fly(Vector3 direction, Transform bullet)
        {
            while (true)
            {
                if(bullet != null)
                    bullet.Translate(direction * Parameter.SpeedBullet * Time.deltaTime);
                else
                    break;
                yield return null;
            }
        }
    }
}