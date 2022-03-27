using UnityEngine;

namespace Parameters.Enemy
{
    [CreateAssetMenu(fileName = "Robot", menuName = "Parameters/Robot", order = 0)]
    public class RobotParameter : ScriptableObject
    {
        public float MinDelayBetweenShooting => _minDelayBetweenShooting;
        public float MaxDelayBetweenShooting => _maxDelayBetweenShooting;
        public float DelayBeforeFocusing => _delayBeforeFocusing;
        public float SpeedRotationHead => _speedRotatationHead;
        public float SpeedBullet => _speedBullet;
        public GameObject Bullet => _bullet;
        public float MinAngle => _minAngle;

        [SerializeField, Header("Задержка перед тем как начать двигать головную часть в сторону игрока"), Range(0, 10)]
        private float _delayBeforeFocusing;

        [SerializeField, Header("Скорость движение вращения головной части"), Range(0, 50)]
        private float _speedRotatationHead;

        [SerializeField, Header("Префаб патрона")]
        private GameObject _bullet;

        [SerializeField, Header("Скорость патрона"), Range(0, 10)]
        private float _speedBullet;

        [SerializeField, Header("Минимальный угол пока будет происходить движение головной части"), Range(0, 180)]
        private float _minAngle;

        [SerializeField, Header("Минимальная задержка между стрельбой"), Range(0, 10)]
        private float _minDelayBetweenShooting;

        [SerializeField, Header("Максимальная задержкам между стрельбой"), Range(0, 10)]
        private float _maxDelayBetweenShooting;
    }
}