using System.Collections;
using Parameters.Enemy;
using UnityEngine;

namespace Enemies.Robot
{
    public class Weapon : Action
    {
        private Transform _parentBullet;
        private ParticleSystem _particleAttack;

        public Weapon(Transform transformObj, Transform player, Transform parentBullet, 
            ParticleSystem particle,
            RobotParameter parameter) :
            base(transformObj, player, parameter)
        {
            _parentBullet = parentBullet;
            _particleAttack = particle;
        }

        public IEnumerator Shoot()
        {
            Vector3 direction = Player.position - TransformObj.position;
            while (true)
            {
                float delay = Random.Range(Parameter.MinDelayBetweenShooting, Parameter.MaxDelayBetweenShooting);
                yield return new WaitForSeconds(delay);
                Transform bullet = CreateBullet();
                _particleAttack.Play();
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
            float distance = 0;
            while (bullet != null && distance < 100)
            {
                distance = Vector3.Distance(TransformObj.position, bullet.transform.position);
                bullet.Translate(direction * Parameter.SpeedBullet * Time.deltaTime);
                yield return null;
            }
            if(bullet != null)
                Object.Destroy(bullet.gameObject);
        }
    }
}