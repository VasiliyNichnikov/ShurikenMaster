using DrawSlicing;
using UnityEngine;

namespace Shurikens
{
    public class CalculatorOfShurikenPoints
    {
        private DivisionIntoSegments _separator;
        private float _shurikenLength;
        private float _space;
        
        public CalculatorOfShurikenPoints(DivisionIntoSegments separator, float shurikenLength, float space)
        {
            _space = space;
            _separator = separator;
            _shurikenLength = shurikenLength;
        }

        public Vector3[] GetPoints()
        {
            return _separator.CalculateShurikenPoints(_shurikenLength, _space);
        }
    }
}