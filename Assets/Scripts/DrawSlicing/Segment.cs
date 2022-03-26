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
                _positionEnd = value;
            }
        }
    
        private readonly Vector2 _positionStart;
        private Vector2 _positionEnd;
        private Vector2 _direction;
        
        public Segment(Vector2 positionStart)
        {
            _positionStart = positionStart;
            PositionEnd = positionStart;
            Color =  new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1);
        }
        
    }
}