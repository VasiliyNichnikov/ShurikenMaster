using System.Collections;
using Parameters.Enemy;
using UnityEngine;

namespace Enemies.Stickman
{
    [RequireComponent(typeof(Animator))]
    public class StickmanContol : Enemy
    {
        [Header("Точка до которой идет враг прежде чем ударить")]
        public Vector3 EndPoint;

        [SerializeField] private StickmanParameter _parameter;
        private Attacker _attacker;
        private Walker _walker;
        private Transform _thisTransform;
        private Animator _animator;
        private ManagementStateRagdoll _stateRagdoll;
        private IEnumerator _runningWalk;

        public override void EnablingPreAttackDelay()
        {
            if (_runningWalk != null || IsDead) return;

            _runningWalk = _walker.Go(_attacker.StrikeHand());
            StartCoroutine(_runningWalk);
        }

        public override void Die()
        {
            if(_runningWalk != null)
                StopCoroutine(_runningWalk);
            _animator.enabled = false;
            _stateRagdoll.Destruction();
            IsDead = true;
        }

        private void Start()
        {
            _thisTransform = transform;
            _animator = GetComponent<Animator>();
            _stateRagdoll = GetComponent<ManagementStateRagdoll>();

            _attacker = new Attacker(_parameter, _animator);
            _walker = new Walker(_parameter, _thisTransform, EndPoint, _animator);
        }
    }
}