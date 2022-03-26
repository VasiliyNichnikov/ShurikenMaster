using System;
using Spline;
using UnityEngine;

namespace MovementAlongSpline
{
    public class Route: IRoute
    {
        public Vector3[] Points { get; private set; }

        public float Spacing
        {
            get => _spacing;
            set
            {
                if (value >= 0 && value <= 1)
                    _spacing = value;
                else
                    throw new OverflowException();
            } 
        }
        
        private readonly ISpline _spline;
        private float _spacing;
        
        public Route(ISpline spline)
        {
            _spline = spline;
            _spacing = 1;
        }

        public void Build()
        {
            Points = CalculatePoints.GetEvenlySpacedPoints(_spline, _spacing);
        }
        
    }
}