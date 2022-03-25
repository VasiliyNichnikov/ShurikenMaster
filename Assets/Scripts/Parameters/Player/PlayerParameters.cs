using UnityEngine;

namespace Parameters.Player
{
    [CreateAssetMenu(fileName = "Player", menuName = "Parameters/Player", order = 0)]
    public class PlayerParameters : ScriptableObject
    {
        public MotionParameter DefaultMotion => _defaultMotion;
        public MotionParameter SlowDownMotion => _slowDownMotion;

        [SerializeField, Header("Параметр движения при обычной скорости")]
        private MotionParameter _defaultMotion;

        [SerializeField, Header("Параметр движения при замедлении")]
        private MotionParameter _slowDownMotion;
    }
}