using System.Collections.Generic;
using DrawSlicing;
using Parameters.Shuriken;
using UnityEngine;

namespace Shurikens
{
    public class CalculatorOfShurikenPoints
    {
        private ShurikenParameters _parameters;
        private DivisionIntoSegments _separator;
        private const float _shurikenLength = 0.5753977f;
        private Vector3 _startPosition;
        private int _layer = 1 << 7;

        public CalculatorOfShurikenPoints(DivisionIntoSegments separator, Vector3 startPosition,
            ShurikenParameters parameters)
        {
            _separator = separator;
            _parameters = parameters;
            _startPosition = startPosition;
        }

        public Vector3[] GetPoints()
        {
            Vector3[] points = _separator.CalculateShurikenPoints(_parameters.DistanceBetweenRays);
            List<Vector3> result = new List<Vector3>();
            foreach (var point in points)
            {
                Vector3 direction = (point - _startPosition).normalized;

                RaycastHit hit;
                if (Physics.Raycast(point, direction, out hit, _parameters.MaxLengthRay, _layer))
                {
                    result.Add(hit.point);
                }
            }

            return result.Count == 0 ? _separator.CalculateShurikenPoints(_shurikenLength, _parameters.DistanceBetweenShurikens) : result.ToArray();
        }
    }
}