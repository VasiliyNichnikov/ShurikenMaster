using System;
using System.Linq;
using UnityEngine;

namespace Spline
{
    public class Spline : MonoBehaviour, ISpline
    {
        public bool IsActiveHandles;
    
        [SerializeField] private Vector3[] _points;

        public int LengthPoints => _points.Length;

        public int NumberCurves
        {
            get => _points.Length / 3;
        }
    
        public Vector3 this[int index]
        {
            get
            {
                if (index >= 0 && index < _points.Length)
                    return _points[index];
                throw new Exception("Данного элемента нет в массиве");
            }
            set
            {
                if (index < 0 || index >= _points.Length)
                    throw new Exception("Данного элемента нет в массиве");
                _points[index] = value;
            }
        }

        public Vector3[] GetPointsInCurves(int i)
        {
            int multiplyIByThree = i * 3;
            return new []
            {
                _points[multiplyIByThree], _points[multiplyIByThree + 1], _points[multiplyIByThree + 2],
                _points[multiplyIByThree + 3]
            };
        }

        public void AddCurve()
        {
            Vector3 point = _points[_points.Length - 1];
            Array.Resize(ref _points, _points.Length + 3);
            point.x += 1;
            _points[_points.Length - 3] = point;
            point.x += 1;
            _points[_points.Length - 2] = point;
            point.x += 1;
            _points[_points.Length - 1] = point;

            EnforceMode(_points.Length - 4);
        }

        private void EnforceMode(int index)
        {
            int modeIndex = (index + 1) / 3;
            int middleIndex = modeIndex * 3;
            int fixedIndex, enforcedIndex;

            if (index <= middleIndex)
            {
                fixedIndex = middleIndex - 1;
                if (fixedIndex < 0)
                {
                    fixedIndex = _points.Length - 2;
                }

                enforcedIndex = middleIndex + 1;
                if (enforcedIndex >= _points.Length)
                {
                    enforcedIndex = 1;
                }
            }
            else
            {
                fixedIndex = middleIndex + 1;
                if (fixedIndex >= _points.Length)
                {
                    fixedIndex = 1;
                }

                enforcedIndex = middleIndex - 1;
                if (enforcedIndex < 0)
                {
                    enforcedIndex = _points.Length - 2;
                }
            }

            Vector3 middle = _points[middleIndex];
            Vector3 enforcedTangent = middle - _points[fixedIndex];
            enforcedTangent = enforcedTangent.normalized * Vector3.Distance(middle, _points[enforcedIndex]);
            _points[enforcedIndex] = middle + enforcedTangent;
        }

        public void RemoveCurve()
        {
            bool curvesExist = CheckIfCurvesExist();
            if (curvesExist)
            {
                int pIndex1 = _points.Length - 3;
                int pIndex2 = _points.Length - 2;
                int pIndex3 = _points.Length - 1;

                _points = _points.Where((val, index) => index != pIndex1 && index != pIndex2 && index != pIndex3).ToArray();
            }
        }

        private bool CheckIfCurvesExist()
        {
            return _points.Length > 4;
        }

        private void Reset()
        {
            _points = new[]
            {
                new Vector3(1, 0, 0),
                new Vector3(2, 0, 0),
                new Vector3(3, 0, 0),
                new Vector3(4, 0, 0)
            };
        }
    }
}