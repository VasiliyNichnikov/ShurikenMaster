using System.Collections;
using Parameters.Enemy;
using UnityEngine;

namespace Enemies.Robot
{
    public class RobotControl : Enemy
    {
        [SerializeField] private RobotParameter _parameter;
        [SerializeField] private Transform _startBulletPosition;
        [SerializeField] private ParticleSystem _particleAttack;

        private Rigidbody _rigidbody;

        private Transform _parentBullet;
        private FocuserOnPlayer _focuser;
        private Weapon _weapon;

        private Transform _thisTransform;
        private ThisPlayer _player;

        private IEnumerator _runningFocuser;

        public override void Die()
        {
            if (_runningFocuser != null)
                StopCoroutine(_runningFocuser);
            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = true;
            IsDead = true;
        }

        public override void EnablingPreAttackDelay()
        {
            if (_runningFocuser != null || IsDead) return;

            _runningFocuser = _focuser.Focus(_weapon.Shoot());
            StartCoroutine(_runningFocuser);
        }

        private void Start()
        {
            _thisTransform = transform;
            _player = FindObjectOfType<ThisPlayer>();
            _rigidbody = GetComponent<Rigidbody>();
            _parentBullet = FindObjectOfType<ParentBullets>().transform;

            Transform playerTransform = _player.transform;
            _focuser = new FocuserOnPlayer(_thisTransform, playerTransform, _parameter);
            _weapon = new Weapon(_startBulletPosition, playerTransform, _parentBullet, _particleAttack, _parameter);
        }
    }
}