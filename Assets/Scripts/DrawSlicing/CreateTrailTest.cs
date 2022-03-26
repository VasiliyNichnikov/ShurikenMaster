using Parameters.Segment;
using UnityEngine;

namespace DrawSlicing
{
    // [RequireComponent(typeof(LineRenderer))]
    public class CreateTrailTest: MonoBehaviour
    {
        [SerializeField]
        private Vector3[] _points;

        [SerializeField] private TrailParameters _parameters;
        private DivisionIntoSegments _division;
        private bool _segmentsCreated;
        


        private void Start()
        {
            _division = new DivisionIntoSegments(_parameters.AngleRestrictions);

            _division.CreateFirstSegment(_points[0]);
            for (int i = 1; i < _points.Length; i++)
            {
                _division.AddPointToSegment(_points[i]);
            }

            _segmentsCreated = true;
        }

        private void OnDrawGizmos()
        {
            if(_points == null || _points.Length == 0)
                return;
            if(_segmentsCreated == false)
            {
                for (int i = 0; i < _points.Length; i++)
                {
                    if (i + 1 < _points.Length)
                    {
                        Gizmos.DrawLine(_points[i], _points[i + 1]);
                    }
                }
            }
            else
            {
                foreach (var segment in _division.Segments)
                {
                    Gizmos.color = segment.Color;
                    Gizmos.DrawLine(segment.PositionStart, segment.PositionEnd);
                }
            }
        }
    }
}