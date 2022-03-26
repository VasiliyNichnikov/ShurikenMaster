using System;
using System.Collections;
using Enemies;
using UnityEngine;

namespace AttackZone
{
    public class MobKillCounter : MonoBehaviour
    {
        public bool Running => _runningCheck != null;
        
        private int _numberKilledEnemies;
        private IEnumerator _runningCheck;
    
        public void ToRun(IEnemy[] enemies, MobsDestroyed challenge)
        {
            if (_runningCheck == null)
            {
                _runningCheck = CheckNumberOfLiveMobs(enemies, challenge);
                StartCoroutine(_runningCheck);
            }
        }

        private IEnumerator CheckNumberOfLiveMobs(IEnemy[] enemies, MobsDestroyed challenge)
        {
            if (enemies.Length == 0)
                throw new Exception("The array must not be empty");
            
            while (true)
            {
                foreach (var enemy in enemies)
                {
                    if (enemy.IsDead)
                        _numberKilledEnemies++;
                    else
                        _numberKilledEnemies = 0;
                }

                if (_numberKilledEnemies == enemies.Length)
                {
                    challenge();
                    break;
                }

                yield return null;
            }

            _runningCheck = null;
        }
    }
}