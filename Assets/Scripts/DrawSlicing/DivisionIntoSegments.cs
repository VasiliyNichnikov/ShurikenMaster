using System;
using System.Collections.Generic;
using MyUtils;
using Parameters.Segment;
using UnityEngine;

namespace DrawSlicing
{
    public class DivisionIntoSegments
    {
        public List<Segment> Segments => _segments;
        private List<Segment> _segments;
        private TrailParameters _parameters;
        private Transform _transformObj;
        
        public DivisionIntoSegments(TrailParameters parameters, Transform transformObj)
        {
            _transformObj = transformObj;
            _segments = new List<Segment>();
            _parameters = parameters;
        }

        public void CreateFirstSegment(Vector2 positionStart)
        {
            if (_segments.Count > 0)
                throw new Exception("Segments have already been created in the list");
            
            Segment segment = new Segment(positionStart);
            _segments.Add(segment);
        }

        public void AddPointToSegment(Vector2 positionPoint)
        {
            Segment last = _segments[_segments.Count - 1];

            Vector2 current = last.Direction;
            Vector2 duration = positionPoint - last.PositionEnd;
            if (Calculations.SegmentBelongToContinuationOfCurrentSegment(current, duration, _parameters.AngleRestrictions))
            {
                // MonoBehaviour.print("Adding to the previous line");
                last.PositionEnd = positionPoint;
            }
            else
            {
                // MonoBehaviour.print("Creating a new segment");
                Segment segment = new Segment(last.PositionEnd);
                segment.PositionEnd = positionPoint;
                _segments.Add(segment);
            }
        }

        public Vector3[] CalculateShurikenPoints(float shurikenLength, float space = 0)
        {
            List<Vector3> points = new List<Vector3>();
            foreach (var segment in _segments)
            {
                Vector2[] directionPoints = segment.GetDirectionPoints(shurikenLength, space);
                foreach (var point in directionPoints)
                {
                    Vector3 point3 = new Vector3(point.x, point.y, 0);
                    Vector3 readyPoint = _transformObj.TransformPoint( point3 + Vector3.forward * _parameters.ShiftZ);
                    points.Add(readyPoint);
                }
            }

            return points.ToArray();
        }
        
        public void ClearSegments()
        {
            _segments.Clear();
        }
    }
}