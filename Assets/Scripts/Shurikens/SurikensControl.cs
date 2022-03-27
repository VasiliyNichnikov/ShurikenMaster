using System;
using DrawSlicing;
using Parameters.Shuriken;
using UnityEngine;

namespace Shurikens
{
    public class SurikensControl : MonoBehaviour
    {
        [SerializeField] private ShurikenParameters _parameters;
        [SerializeField] private Transform _parent;
        [SerializeField] private Transform _startTransform;
        
        private const float _shurikenLength = 0.5753977f;
        private PowerShuriken[] _shurikens;
        private CalculatorOfShurikenPoints _shurikenPoints;

        public void Launch(DrawTrail drawTrail)
        {
            if (drawTrail.Line == null)
                throw new ArgumentNullException();
            CreateSurikens(drawTrail);
            LaunchSurikens();
        }
        

        private void CreateSurikens(DrawTrail drawTrail)
        {
            var separator = drawTrail.Line.Division;
            _shurikenPoints = new CalculatorOfShurikenPoints(separator, _shurikenLength, _parameters.Space);
            var creator = new CreatorShurikens(_shurikenPoints, _parameters.Shuriken, _parent, _startTransform.position);
            _shurikens = creator.GetNewShurikens();
        }

        private void LaunchSurikens()
        {
            if(_shurikens.Length == 0)
                return;
            
            var launcher = new LauncherShurikens(_shurikens, _parameters.Speed);
            launcher.Fly();
        }

        private void OnDrawGizmos()
        {
            if (_shurikenPoints != null)
            {
                Vector3[] points = _shurikenPoints.GetPoints();
                foreach (var point in points)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawSphere(point, 0.1f);
                }
            }
        }
    }
}