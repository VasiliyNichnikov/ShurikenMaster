using System;
using System.Collections;
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

        private Transform _thisTransform;
        private PowerShuriken[] _shurikens;
        private CalculatorOfShurikenPoints _shurikenPoints;
        
        public void Launch(DrawTrail drawTrail)
        {
            if (drawTrail.Line == null)
                throw new ArgumentNullException();
            CreateSurikens(drawTrail);
            LaunchSurikens();
        }

        private void Start()
        {
            _thisTransform = transform;
        }

        private void CreateSurikens(DrawTrail drawTrail)
        {
            var separator = drawTrail.Line.Division;
            _shurikenPoints = new CalculatorOfShurikenPoints(separator, _thisTransform.position, _parameters);
            var creator = new CreatorShurikens(_shurikenPoints, _startTransform.position, _parameters.Shuriken, _parent);
            _shurikens = creator.GetNewShurikens();
        }

        private void LaunchSurikens()
        {
            if(_shurikens.Length == 0)
                return;
            
            var launcher = new LauncherShurikens(_shurikens, _parameters);
            StartCoroutine(launcher.Fly());
        }

        private void OnDrawGizmos()
        {
            if (_shurikenPoints != null)
            {
                foreach (var point in _shurikenPoints.GetPoints())
                {
                    Gizmos.DrawLine(_thisTransform.position, (point - _thisTransform.position) * 100);
                    Gizmos.DrawSphere(point, 0.1f);
                }
            }
        }
    }
}