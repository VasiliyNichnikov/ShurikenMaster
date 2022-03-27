using UnityEngine;

namespace Parameters.Segment
{
    [CreateAssetMenu(fileName = "Segment", menuName = "Parameters/CalculationParameters", order = 0)]
    public class TrailParameters : ScriptableObject
    {
        public float AngleRestrictions => _angleRestrictions;
        public float ShiftZ => _shiftZ;
        public float Step => _step;
        
        [SerializeField, Range(0, 180), Header("Ограничения угла при вычисление отрезков")]
        private float _angleRestrictions;
        
        [SerializeField, Range(0, 20), Header("Расстояние от камеры до трейла по Z")] private float _shiftZ;
        [SerializeField, Range(0, 1), Header("Шаг между точками отрезка")] private float _step;
    }
}