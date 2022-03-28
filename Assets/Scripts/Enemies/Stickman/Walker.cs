using System.Collections;
using Parameters.Enemy;
using UnityEngine;

namespace Enemies.Stickman
{
    public class Walker
    {
        private Animator _animator;
        private StickmanParameter _parameter;
        private Transform _transformObject;
        private Vector3 _endPoint;

        public Walker(StickmanParameter parameter, Transform transformObject, Vector3 endPoint, Animator animator)
        {
            _parameter = parameter;
            _transformObject = transformObject;
            _endPoint = endPoint;
            _animator = animator;
        }
        
        public IEnumerator Go(IEnumerator attack)
        {
            var positionObject = _transformObject.position;
            float distance = Vector3.Distance(positionObject, _endPoint);
            ChangeConditionAnimator(true);
            
            Quaternion rotation = Quaternion.LookRotation(_endPoint - positionObject);

            while (distance > _parameter.MinDistanceToPoint)
            {
                positionObject = _transformObject.position;
                positionObject = Vector3.MoveTowards(positionObject, _endPoint, _parameter.Speed * Time.deltaTime);
                _transformObject.rotation = Quaternion.Lerp(_transformObject.rotation, rotation, _parameter.Speed * Time.deltaTime);
                distance = Vector3.Distance(positionObject, _endPoint);
                _transformObject.position = positionObject;
                yield return null;
            }
            ChangeConditionAnimator();
            yield return attack;
        }

        private void ChangeConditionAnimator(bool toRun=false)
        {
            float value = toRun ? _parameter.NumberWalkAnimator : _parameter.NumberIdleAnimator;
            _animator.SetFloat(_parameter.NameAnimatorSwitcher, value);
        }
    }
}