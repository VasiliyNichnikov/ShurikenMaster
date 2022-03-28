using Enemies;
using MyUtils;
using UnityEngine;

namespace ObjectsOnScene
{
    public class Barrel : MonoBehaviour
    {
        [SerializeField, Header("Радиус поражения"), Range(1, 80)]
        private float _radius;

        [SerializeField, Header("Сила удара"), Range(0, 1000)]
        private float _power;

        private Transform _explosionTransform;

        public void OnTriggerEnter(Collider other)
        {
            if (ShurikenUtils.CheckThatObjectIsSuriken(other.gameObject))
            {
                Explode();
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _explosionTransform = transform;
        }
        
        private void Explode()
        {
            Collider[] colliders = Physics.OverlapSphere(_explosionTransform.position, _radius);

            foreach (var collider in colliders)
            {
                Rigidbody rigidbody = collider.GetComponent<Rigidbody>();
                Enemy enemy = collider.GetComponent<Enemy>();
                
                if(enemy != null)
                    enemy.Die();
                if(rigidbody != null)
                    rigidbody.AddExplosionForce(_power, _explosionTransform.position, _radius, 3.0f);
            }
        }
    }
}
