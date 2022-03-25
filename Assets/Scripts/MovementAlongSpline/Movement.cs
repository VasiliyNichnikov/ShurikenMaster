using System;
using System.Collections;
using UnityEngine;

namespace MovementAlongSpline
{
    public class Movement : IMovement
    {
        public float SpeedMovement
        {
            get => _speedMovement;
            set
            {
                if (value > 0 && value <= 50)
                    _speedMovement = value;
                else
                    throw new OverflowException();
            }
        }

        public float SpeedRotation
        {
            get => _speedRotation;
            set
            {
                if (value > 0 && value <= 5)
                    _speedRotation = value;
                else
                    throw new OverflowException();
            }
        }
        
        private readonly Transform _obj;
        private readonly Vector3[] _points;
        private float _speedMovement;
        private float _speedRotation;

        public Movement(Transform obj, Vector3[] points)
        {
            _obj = obj;
            _points = points;
            _speedMovement = 1.0f;
            _speedRotation = 1.0f;
        }

        public IEnumerator Drive()
        {
            int index = 0;
            _obj.position = _points[index];
            while (index < _points.Length)
            {
                Vector3 positionPoint = _points[index];
                UpdateRotation(positionPoint);
                UpdatePosition(positionPoint);

                if (_obj.position == positionPoint)
                    index++;
                yield return null;
            }
        }

        private void UpdatePosition(Vector3 positionPoint)
        {
            Vector3 positionObj = _obj.position;
            positionObj = Vector3.MoveTowards(positionObj, positionPoint, _speedMovement * Time.deltaTime);
            _obj.position = positionObj;
        }

        private void UpdateRotation(Vector3 positionPoint)
        {
            Vector3 positionObj = _obj.position;
            Vector3 targetDirection = positionPoint - positionObj;
            Vector3 newDirection = Vector3.RotateTowards(_obj.forward, targetDirection,
                _speedRotation * Time.deltaTime, 0.0f);
            Debug.DrawRay(positionObj, newDirection * 10, Color.red);
            _obj.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}