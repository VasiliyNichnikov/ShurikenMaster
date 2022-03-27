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
            var shurikenDirections = new CalculatorOfShurikenPoints(separator, _shurikenLength, _parameters.Space);
            var creator = new CreatorShurikens(shurikenDirections, _parameters.Shuriken, _parent, _startTransform.position);
            _shurikens = creator.GetNewShurikens();
        }

        private void LaunchSurikens()
        {
            if(_shurikens.Length == 0)
                return;
            
            var launcher = new LauncherShurikens(_shurikens, _parameters.Speed);
            launcher.Fly();
        }
    }
}