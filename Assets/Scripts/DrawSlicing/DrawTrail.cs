using Parameters.Segment;
using UnityEngine;

namespace DrawSlicing
{
    public class DrawTrail: MonoBehaviour, IClickTrail
    {
        public Line Line => _line;
        
        [SerializeField] private TrailParameters _parameters;
        [SerializeField] private Camera _camera;
        // [SerializeField, Header("Trail движения")] private ParticleSystem _particleTrail;
        
        private Line _line;
        private Trail _trail;
        private Transform _thisTransform;

        private void Start()
        {
            _thisTransform = transform;
            _line = new Line(_parameters, _thisTransform);
            // _trail = new Trail(_particleTrail);
        }
        
        public void ClickDown(Vector3 newPosition)
        {
            _line.Clear();
            Vector3 worldPosition = GetWorldPosition(newPosition);
            // _trail.ClickDown(worldPosition);
            _line.AddPoint(worldPosition);
        }

        public void ClickDrag(Vector3 newPosition)
        {
            Vector3 worldPosition = GetWorldPosition(newPosition);
            // _trail.ClickDrag(worldPosition);
            _line.AddPoint(worldPosition);
        }

        public void ClickUp(Vector3 newPosition)
        {
            // Vector3 worldPosition = GetWorldPosition(newPosition);
            // _trail.ClickUp(worldPosition);
        }

        private Vector3 GetWorldPosition(Vector3 mousePosition)
        {
            mousePosition.z = _camera.nearClipPlane + _parameters.ShiftZ;
            return _camera.ScreenToWorldPoint(mousePosition);
        }
        
        private void OnDrawGizmos()
        {
            if (_line != null && _line.Points.Count > 0)
            {
                foreach (var segment in _line.Division.Segments)
                {
                    Gizmos.color = segment.Color;
                    Vector3 start = new Vector3(segment.PositionStart.x, segment.PositionStart.y, 0);
                    Vector3 end = new Vector3(segment.PositionEnd.x, segment.PositionEnd.y, 0);
                    
                    start = _thisTransform.TransformPoint(start + Vector3.forward * _parameters.ShiftZ);
                    end = _thisTransform.TransformPoint(end + Vector3.forward * _parameters.ShiftZ);
                    Gizmos.DrawLine(start, end);
                }
                
            }
        }
    }
}