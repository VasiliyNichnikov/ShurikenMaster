using UnityEngine;

namespace Parameters.Enemy
{
    [CreateAssetMenu(fileName = "StickmanParameter", menuName = "Parameters/StickmanParameter", order = 0)]
    public class StickmanParameter : ScriptableObject
    {
        public float Speed => _speed;
        public float MinDistanceToPoint => _minDistanceToPoint;
        public float NumberIdleAnimator => _numberIdleAnimator;
        public float NumberWalkAnimator => _numberWalkAnimator;
        public float NumberAttackAnimator => _numberAttackAnimator;
        public string NameAnimatorSwitcher => _nameAnimatorSwitcher;

        [SerializeField, Header("Скорость движения к точке"), Range(0.001f, 5f)]
        private float _speed;

        [SerializeField,
         Header("Минимальное расстояние до точки, после преодоления которого бот останавливается и бьет врага"),
         Range(0f, 1f)]
        private float _minDistanceToPoint;

        [SerializeField, Header("Название параметра в Аниматоре, которй переключает анимации")]
        private string _nameAnimatorSwitcher;

        [SerializeField, Header("Значение при котором у врага будет проигрываться анимация idle"), Range(0f, 1f)]
        private float _numberIdleAnimator;

        [SerializeField, Header("Значение при котором у врага будет проигрываться анимация движения"), Range(0f, 1f)]
        private float _numberWalkAnimator;

        [SerializeField, Header("Значение при котором у врага будет проигрываться анимация атаки"), Range(0f, 1f)]
        private float _numberAttackAnimator;
    }
}