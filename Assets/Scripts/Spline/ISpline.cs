using UnityEngine;

namespace Spline
{
    public interface ISpline
    {
        int NumberCurves { get; }
        Vector3 this[int index] { get; }
        int LengthPoints { get; }
        void AddCurve();
        void RemoveCurve();
        Vector3[] GetPointsInCurves(int i);
    }
}