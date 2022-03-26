using Parameters.Segment;
using UnityEngine;

namespace DrawSlicing
{
    public class DrawTrail: MonoBehaviour, IClickTrail
    {
        [SerializeField] private TrailParameters _parameters;
        [SerializeField] private Camera _camera;
        [SerializeField, Header("Trail движения")] private ParticleSystem _particleTrail;
        
        private Line _line;
        private Trail _trail;

        private void Start()
        {
            _line = new Line(_parameters);
            _trail = new Trail(_particleTrail);
        }
    
        
        public void ClickDown(Vector3 newPosition)
        {
            _line.Clear();
            Vector3 worldPosition = GetWorldPosition(newPosition);
            _trail.ClickDown(worldPosition);
            _line.AddPoint(worldPosition);
        }

        public void ClickDrag(Vector3 newPosition)
        {
            Vector3 worldPosition = GetWorldPosition(newPosition);
            _trail.ClickDrag(worldPosition);
            _line.AddPoint(worldPosition);
        }

        public void ClickUp(Vector3 newPosition)
        {
            Vector3 worldPosition = GetWorldPosition(newPosition);
            _trail.ClickUp(worldPosition);
        }

        private Vector3 GetWorldPosition(Vector3 mousePosition)
        {
            mousePosition.z = _camera.nearClipPlane + _parameters.ShiftZ;
            return _camera.ScreenToWorldPoint(mousePosition);
        }
        
        // private void Update()
        // {
        //     Vector3 mousePosition = Input.mousePosition;
        //     if (Input.GetMouseButtonDown(0))
        //     {
        //         _points.Clear();
        //         _trail.Play();
        //         _division = new DivisionIntoSegments(_parameters.AngleRestrictions);
        //         
        //         mousePosition.z = _camera.nearClipPlane + _shiftZ;
        //         Vector3 worldPosition = _camera.ScreenToWorldPoint(mousePosition);
        //         _particleTransform.position = worldPosition;
        //         
        //         _division.CreateFirstSegment(worldPosition);
        //         _points.Add(worldPosition);
        //         return;
        //     }
        //
        //     if (Input.GetMouseButton(0))
        //     {
        //         mousePosition.z = _camera.nearClipPlane + _shiftZ;
        //         Vector3 worldPosition = _camera.ScreenToWorldPoint(mousePosition);
        //         _particleTransform.position = worldPosition;
        //         
        //         Vector3 lastPoint = _points[_points.Count - 1];
        //         float distance = Vector3.Distance(worldPosition, lastPoint);
        //         
        //         if (distance >= _step)
        //         {
        //             _points.Add(worldPosition);
        //             _division.AddPointToSegment(worldPosition);
        //         }
        //     }
        //
        //     if (Input.GetMouseButtonUp(0))
        //     {
        //         _trail.Stop();
        //     }
        // }

        private void OnDrawGizmos()
        {
            if (_line != null && _line.Points.Count > 0)
            {
                foreach (var segment in _line.Division.Segments)
                {
                    Gizmos.color = segment.Color;
                    Vector3 start = new Vector3(segment.PositionStart.x, segment.PositionStart.y, transform.position.z);
                    Vector3 end = new Vector3(segment.PositionEnd.x, segment.PositionEnd.y, transform.position.z);
                    Gizmos.DrawLine(start, end);
                }
            }
        }
    }
}