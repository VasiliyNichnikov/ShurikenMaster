using System.Collections.Generic;
using UnityEngine;

namespace Spline
{
    public static class CalculatePoints
    {
        public static Vector3[] GetEvenlySpacedPoints(ISpline spline, float spacing)
        {
            List<Vector3> points = new List<Vector3>();
            Vector3 firstPoint = spline[0];
            points.Add(firstPoint);
            Vector3 previousPoint = firstPoint;
            float distanceSinceLastEvenPoint = 0;
        
            int numberCurves = spline.NumberCurves;
        
            for(int indexCurve = 0; indexCurve < numberCurves; indexCurve++)
            {
                Vector3[] p = spline.GetPointsInCurves(indexCurve);

                float controlNetLength =
                    Vector3.Distance(p[0], p[1]) + Vector3.Distance(p[1], p[2]) + Vector3.Distance(p[2], p[3]);
                float estimatedCurveLength = Vector3.Distance(p[0], p[3]) + controlNetLength / 2f;
            
            
                int divisions = Mathf.CeilToInt(estimatedCurveLength * 10);
                float t = 0;
                
                while (t <= 1)
                {
                    t += 1f / divisions;
                    Vector3 pointOnCurve = Bezier.GetPoint(p[0], p[1], p[2], p[3], t);
                    distanceSinceLastEvenPoint += Vector3.Distance(previousPoint, pointOnCurve);

                    while (distanceSinceLastEvenPoint >= spacing)
                    {
                        float overshootDistance = distanceSinceLastEvenPoint - spacing;
                        Vector3 newEvenlySpacedPoint = pointOnCurve + (previousPoint - pointOnCurve)
                            .normalized * overshootDistance;
                        points.Add(newEvenlySpacedPoint);
                        distanceSinceLastEvenPoint = overshootDistance;
                        previousPoint = newEvenlySpacedPoint;
                    }
                    previousPoint = pointOnCurve;
                }
            }
        
            return points.ToArray();
        }
    }
}