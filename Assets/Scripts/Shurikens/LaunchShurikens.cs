using System;
using DrawSlicing;
using UnityEngine;

namespace Shurikens
{
    public class LaunchShurikens : MonoBehaviour
    {
        private Vector3[] _points;

        public void ClickUp(DrawTrail drawTrail)
        {
            if (drawTrail.Line != null)
            {
                var separator = drawTrail.Line.Division;
                var shurikenDirections = new CalculatorOfShurikenDirections(separator, 0.5753977f, 0);
                _points = shurikenDirections.GetPoints();
            }
            else
                throw new ArgumentNullException();
        }

        private void OnDrawGizmos()
        {
            if (_points != null && _points.Length > 0)
            {
                foreach (var point in _points)
                {
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawSphere(point, 0.1f);
                }
            }
        }
    }
}