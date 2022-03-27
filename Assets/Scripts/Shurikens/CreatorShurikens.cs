using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Shurikens
{
    public class CreatorShurikens
    {
        private GameObject _shuriken;
        private Transform _parent;
        private Vector3 _startPosition;
        private CalculatorOfShurikenPoints _calculatorPoints;

        public CreatorShurikens(CalculatorOfShurikenPoints calculatorPoints, GameObject prefab, Transform parent, Vector3 startPosition)
        {
            _calculatorPoints = calculatorPoints;
            _shuriken = prefab;
            _parent = parent;
            _startPosition = startPosition;
        }

        public PowerShuriken[] GetNewShurikens()
        {
            Vector3[] points = _calculatorPoints.GetPoints();
            PowerShuriken[] shurikens = new PowerShuriken[points.Length];
            
            for (int i = 0; i < points.Length; i++)
            {
                Vector3 direction = points[i] - _startPosition;
                PowerShuriken shuriken = AddNewShuriken();
                shuriken.Direction = direction;
                shurikens[i] = shuriken;
            }

            return shurikens;
        }
        
        private PowerShuriken AddNewShuriken()
        {
            GameObject newShuriken = Object.Instantiate(_shuriken, _startPosition, Quaternion.identity, _parent);
            PowerShuriken shuriken = newShuriken.GetComponentInChildren<PowerShuriken>();
            if (shuriken == null)
                throw new ArgumentNullException();
            return shuriken;
        }
        
    }
}