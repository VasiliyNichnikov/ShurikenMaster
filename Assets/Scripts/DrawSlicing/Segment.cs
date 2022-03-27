using UnityEngine;

namespace DrawSlicing
{
    public class Segment
    {
        public Color Color { get; }

        public Vector2 Direction => _direction;

        public Vector2 PositionStart => _positionStart;

        public Vector2 PositionEnd
        {
            get => _positionEnd;
            set
            {
                _direction = value - _positionStart;
                _length = Vector2.Distance(_positionStart, _positionEnd);
                _positionEnd = value;
            }
        }

        private readonly Vector2 _positionStart;
        private Vector2 _positionEnd;
        private Vector2 _direction;
        private float _length;

        public Segment(Vector2 positionStart)
        {
            _positionStart = positionStart;
            PositionEnd = positionStart;
            _length = 0;
            Color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1);
        }

        public Vector2[] GetDirectionPoints(float shurikenLength, float space)
        {
            int numberShurikens = GetNumberOfShurikensInSegment(shurikenLength, space);
            Vector2[] points = new Vector2[numberShurikens]; 
            
            float step = _length / numberShurikens;
            float distanceToPoint = step;
            for (int i = 0; i < numberShurikens; i++)
            {
                points[i] = GetPoint(distanceToPoint);
                distanceToPoint += step;
            }

            return points;
        }

        private Vector2 GetPoint(float distanceToPoint)
        {
            Vector2 point = _positionStart + _direction * (distanceToPoint / _length);
            return point;
        }
        
        private int GetNumberOfShurikensInSegment(float shurikenLength, float space)
        {
            float result = _length / (shurikenLength + space);
            return Mathf.FloorToInt(result);
        }
    }
}