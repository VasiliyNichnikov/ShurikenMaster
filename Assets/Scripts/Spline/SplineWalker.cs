using UnityEngine;

namespace Spline
{
    public class SplineWalker : MonoBehaviour
    {
        [SerializeField] private Spline _spline;
        [SerializeField] private float _spacing;
        [SerializeField] private float _speed;
        private Vector3[] _points;
        private int _index;
        private Transform _thisTransform;

        private void Start()
        {
            _thisTransform = transform;
            _points = CalculatePoints.GetEventlySpacedPoints(_spline, _spacing);
            _thisTransform.position = _points[0];
        }

        private void Update()
        {
            if (_index < _points.Length)
            {
                _thisTransform.position =
                    Vector3.MoveTowards(_thisTransform.position, _points[_index], _speed * Time.deltaTime);
            
                Vector3 targetDir = _points[_index] - _thisTransform.position;
                Vector3 newDir = Vector3.RotateTowards(_thisTransform.forward, targetDir, _speed * Time.deltaTime, 0.0f);
                _thisTransform.rotation = Quaternion.LookRotation(newDir);
            
                if (_thisTransform.position == _points[_index])
                {
                    _index++;
                }
            }
        }
    }
}
