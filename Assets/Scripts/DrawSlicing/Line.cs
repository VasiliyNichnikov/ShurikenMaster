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

        private Transform _transformObj;
        private TrailParameters _parameters;
        private List<Vector3> _points;
        private DivisionIntoSegments _division;

        public Line(TrailParameters parameters, Transform transformObj)
        {
            _parameters = parameters;
            _points = new List<Vector3>();
            _transformObj = transformObj;
        }

        public void AddPoint(Vector3 pointWorldPosition)
        {
            Vector3 pointLocalPosition = _transformObj.InverseTransformPoint(pointWorldPosition);
            
            if (_points.Count == 0)
            {
                _division = new DivisionIntoSegments(_parameters, _transformObj);
                _division.CreateFirstSegment(pointLocalPosition);
                _points.Add(pointLocalPosition);
            }
            else
            {
                if(CheckDistance(pointLocalPosition))
                {
                    // MonoBehaviour.print("Add point");
                    _points.Add(pointLocalPosition);
                    _division.AddPointToSegment(pointLocalPosition);
                }
            }
        }

        public void Clear()
        {
            _division?.ClearSegments();
            _points.Clear();
        }
        
        private bool CheckDistance(Vector3 newPoint)
        {
            float distance = Vector3.Distance(newPoint, LastPoint);
            return distance >= _parameters.Step;
        }
    }
}