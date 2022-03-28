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
            var shurikenPoints = new CalculatorOfShurikenPoints(separator, _thisTransform.position, _parameters);
            var creator = new CreatorShurikens(shurikenPoints, _startTransform.position, _parameters.Shuriken, _parent);
            _shurikens = creator.GetNewShurikens();
        }

        private void LaunchSurikens()
        {
            if(_shurikens.Length == 0)
                return;
            
            var launcher = new LauncherShurikens(_shurikens, _parameters);
            StartCoroutine(launcher.Fly());
        }
    }
}