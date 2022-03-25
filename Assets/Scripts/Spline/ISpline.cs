using UnityEngine;

namespace Spline
{
    public interface ISpline
    {
        int NumberCurves { get; }
        Vector3 this[int index] { get; }
        Vector3 GetPoint(float t);
        Vector3 GetDirection(float t);
        Vector3[] GetPointsInCurves(int i);
    }
}