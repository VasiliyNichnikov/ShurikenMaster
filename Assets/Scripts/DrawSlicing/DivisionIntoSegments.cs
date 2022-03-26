using System;
using System.Collections.Generic;
using MyUtils;
using UnityEngine;

namespace DrawSlicing
{
    public class DivisionIntoSegments
    {
        public List<Segment> Segments => _segments;
        private List<Segment> _segments;
        private float _angleRestrictions;
        
        public DivisionIntoSegments(float angleRestrictions)
        {
            _segments = new List<Segment>();
            _angleRestrictions = angleRestrictions;
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
            if (Calculations.SegmentBelongToContinuationOfCurrentSegment(current, duration, _angleRestrictions))
            {
                MonoBehaviour.print("Adding to the previous line");
                last.PositionEnd = positionPoint;
            }
            else
            {
                MonoBehaviour.print("Creating a new segment");
                Segment segment = new Segment(last.PositionEnd);
                segment.PositionEnd = positionPoint;
                _segments.Add(segment);
            }
        }

        public void ClearSegments()
        {
            _segments.Clear();
        }
    }
}