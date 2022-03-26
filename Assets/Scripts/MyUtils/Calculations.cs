using UnityEngine;

namespace MyUtils
{
    public static class Calculations
    {
        public static bool SegmentBelongToContinuationOfCurrentSegment(Vector2 current, Vector2 duration,
            float angleRestrictions)
        {
            float angle = Vector2.Angle(current, duration);
            // MonoBehaviour.print($"Angle: {angle}");
            return angle < angleRestrictions;
        }
    }
}