using System.Collections;
using Parameters.Enemy;
using UnityEngine;

namespace Enemies.Stickman
{
    public class Attacker
    {
        private Animator _animator;
        private StickmanParameter _parameter;

        public Attacker(StickmanParameter parameter, Animator animator)
        {
            _parameter = parameter;
            _animator = animator;
        }

        public IEnumerator StrikeHand()
        {
            ChangeConditionAnimator(true);
            yield return new WaitForSeconds(0.5f);
            MonoBehaviour.print("GameOver (Stickman)");
        }

        private void ChangeConditionAnimator(bool toRun = false)
        {
            float value = toRun ? _parameter.NumberAttackAnimator : _parameter.NumberIdleAnimator;
            _animator.SetFloat(_parameter.NameAnimatorSwitcher, value);
        }
    }
}