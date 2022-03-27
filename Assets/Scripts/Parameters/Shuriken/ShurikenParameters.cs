using UnityEngine;

namespace Parameters.Shuriken
{
    [CreateAssetMenu(fileName = "Shuriken", menuName = "Parameters/ShurikenParameters", order = 0)]
    public class ShurikenParameters : ScriptableObject
    { 
        public float Space => _space;
        public GameObject Shuriken => _shuriken;
        public float Speed => _speed;
        
        [SerializeField, Header("Расстояние между сюрикенами"), Range(0, 1)] private float _space;

        [SerializeField, Header("Префаб сюрикена")]
        private GameObject _shuriken;

        [SerializeField, Header("Скорость полета"), Range(0, 10)]
        private float _speed;
        
    }
}