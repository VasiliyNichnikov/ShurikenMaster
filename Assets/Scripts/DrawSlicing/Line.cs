using System;
using System.Collections.Generic;
using Parameters.Segment;
using UnityEngine;

namespace DrawSlicing
{
    public class Line
    {
        public List<Vector3> Points => new List<Vector3>(_points);
        public DivisionIntoSegments Division => _division;
        
        private Vector3 LastPoint
        {
            get
            {
                if (_points != null && _points.Count > 0)
                    return _points[_points.Count - 1];
                throw new ArgumentNullException();
            }
        }
        private TrailParameters _parameters;
        private List<Vector3> _points;
        private DivisionIntoSegments _division;

        public Line(TrailParameters parameters)
        {
            _parameters = parameters;
            _points = new List<Vector3>();
        }

        public void AddPoint(Vector3 pointPosition)
        {
            if (_points.Count == 0)
            {
                _division = new DivisionIntoSegments(_parameters.AngleRestrictions);
                _division.CreateFirstSegment(pointPosition);
                _points.Add(pointPosition);
            }
            else
            {
                if(CheckDistance(pointPosition))
                {
                    MonoBehaviour.print("Add point");
                    _points.Add(pointPosition);
                    _division.AddPointToSegment(pointPosition);
                }
            }
        }

        public void Clear()
        {
            _points.Clear();
        }
        
        private bool CheckDistance(Vector3 newPoint)
        {
            float distance = Vector3.Distance(newPoint, LastPoint);
            return distance >= _parameters.Step;
        }
    }
}