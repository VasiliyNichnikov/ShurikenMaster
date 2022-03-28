using System.Collections;
using UnityEngine;

namespace Shurikens
{
    public class PowerShuriken : MonoBehaviour
    {
        public Vector3 Direction { get; set; }
        
        private Transform _thisTransform;

        private IEnumerator _runningFly;

        private void Awake()
        {
            _thisTransform = transform;
        }

        public void StartFly(float speed)
        {
            if (_runningFly != null) return;
            
            _runningFly = Fly(speed);
            StartCoroutine(_runningFly);
        }

        private IEnumerator Fly(float speed)
        {
            while (true)
            {
                _thisTransform.Translate(Direction.normalized * speed * Time.deltaTime);
                yield return null;
            }
        }
    }
}