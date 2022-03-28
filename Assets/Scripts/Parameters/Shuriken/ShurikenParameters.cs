using UnityEngine;

namespace Parameters.Shuriken
{
    [CreateAssetMenu(fileName = "Shuriken", menuName = "Parameters/ShurikenParameters", order = 0)]
    public class ShurikenParameters : ScriptableObject
    { 
        public float DistanceBetweenShurikens => _distanceBetweenShurikens;
        public GameObject Shuriken => _shuriken;
        public float Speed => _speed;

        public float MaxLengthRay => _maxLengthRay;
        // public float LengthShuriken => _lengthShuriken;
        public float DistanceBetweenRays => _distanceBetweenRays;
        public float DelayBetweenShurikenDepartures => _delayBetweenShurikenDepartures;
        
        [SerializeField, Header("Расстояние между сюрикенами"), Range(0, 1)] private float _distanceBetweenShurikens;

        // [SerializeField, Header("Длина сюрикена"), Range(0, 10)]
        // private float _lengthShuriken;

        [SerializeField, Header("Расстояние между лучами"), Range(0, 2)]
        private float _distanceBetweenRays;
        
        [SerializeField, Header("Префаб сюрикена")]
        private GameObject _shuriken;
        
        [SerializeField, Header("Задержка между вылетами сюрикенов"), Range(0, 1)]
        private float _delayBetweenShurikenDepartures;

        [SerializeField, Header("Макимальная длина линии луча"), Range(0, 200)]
        private float _maxLengthRay;
        
        [SerializeField, Header("Скорость полета сюрикена"), Range(0, 200)]
        private float _speed;
        
    }
}