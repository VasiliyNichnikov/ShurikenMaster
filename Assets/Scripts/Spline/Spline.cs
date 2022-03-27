using System;
using System.Linq;
using UnityEngine;

namespace Spline
{
    public class Spline : MonoBehaviour, ISpline
    {
        public bool IsActiveHandles;

        [SerializeField] private BezierControlPointMode[] _modes;
        [SerializeField] private Vector3[] _points;

        public int LengthPoints => _points.Length;

        public int CurveCount
        {
            get { return (_points.Length - 1) / 3; }
        }

        public int NumberCurves
        {
            get => _points.Length / 3;
        }

        public Vector3 this[int index]
        {
            get
            {
                if (index >= 0 && index < _points.Length)
                    return transform.TransformPoint(_points[index]);
                throw new Exception("Данного элемента нет в массиве");
            }
            set
            {
                if (index < 0 || index >= _points.Length)
                    throw new Exception("Данного элемента нет в массиве");
                _points[index] = transform.InverseTransformPoint(value);
            }
        }

        public void SetControlPoint (int index, Vector3 point) {
            if (index % 3 == 0) {
                Vector3 delta = point - this[index];
                if (index > 0) {
                    this[index - 1] += delta;
                }
                if (index + 1 < _points.Length) {
                    this[index + 1] += delta;
                }
            }
            this[index] = point;
            EnforceMode(index);
        }
        
        public Vector3[] GetPointsInCurves(int i)
        {
            int multiplyIByThree = i * 3;

            return new[]
            {
                this[multiplyIByThree],
                this[multiplyIByThree + 1],
                this[multiplyIByThree + 2],
                this[multiplyIByThree + 3]
            };
        }

        public Vector3 GetPoint(float t)
        {
            int i;
            if (t >= 1f)
            {
                t = 1f;
                i = _points.Length - 4;
            }
            else
            {
                t = Mathf.Clamp01(t) * CurveCount;
                i = (int) t;
                t -= i;
                i *= 3;
            }

            return Bezier.GetPoint(this[i], this[i + 1], this[i + 2], this[i + 3], t);
        }

        public Vector3 GetDirection(float t)
        {
            return GetVelocity(t).normalized;
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

            Array.Resize(ref _modes, _modes.Length + 1);
            _modes[_modes.Length - 1] = _modes[_modes.Length - 2];
            EnforceMode(_points.Length - 4);
        }

        public BezierControlPointMode GetControlPointMode(int index)
        {
            return _modes[(index + 1) / 3];
        }

        public void SetControlPointMode(int index, BezierControlPointMode mode)
        {
            _modes[(index + 1) / 3] = mode;
            EnforceMode(index);
        }

        public void RemoveCurve()
        {
            bool curvesExist = CheckIfCurvesExist();
            if (curvesExist)
            {
                int pIndex1 = _points.Length - 3;
                int pIndex2 = _points.Length - 2;
                int pIndex3 = _points.Length - 1;

                _points = _points.Where((val, index) =>
                    index != pIndex1 && index != pIndex2 && index != pIndex3).ToArray();
            }
        }

        private Vector3 GetVelocity(float t)
        {
            return Bezier.GetFirstDerivative(this[0], this[1], this[2], this[3], t) - transform.position;
        }

        private void EnforceMode(int index)
        {
            int modeIndex = (index + 1) / 3;
            
            BezierControlPointMode mode = _modes[modeIndex];
            if (mode == BezierControlPointMode.Free || modeIndex == 0 
                                                    || modeIndex == _modes.Length - 1) {
                return;
            }
            
            int middleIndex = modeIndex * 3;
            int fixedIndex, enforcedIndex;
            
            if (index <= middleIndex) {
                fixedIndex = middleIndex - 1;
                enforcedIndex = middleIndex + 1;
            }
            else {
                fixedIndex = middleIndex + 1;
                enforcedIndex = middleIndex - 1;
            }
            
            Vector3 middle = this[middleIndex];
            Vector3 enforcedTangent = middle - this[fixedIndex];
            if (mode == BezierControlPointMode.Aligned) {
                enforcedTangent = enforcedTangent.normalized * Vector3.Distance(middle, this[enforcedIndex]);
            }
            this[enforcedIndex] = middle + enforcedTangent;
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
            _modes = new BezierControlPointMode[]
            {
                BezierControlPointMode.Free,
                BezierControlPointMode.Free
            };
        }
    }
}