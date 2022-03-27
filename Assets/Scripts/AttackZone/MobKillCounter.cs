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
    
        public void ToRun(Enemy[] enemies, MobsDestroyed challenge)
        {
            if (_runningCheck == null)
            {
                _runningCheck = CheckNumberOfLiveMobs(enemies, challenge);
                StartCoroutine(_runningCheck);
            }
        }

        private IEnumerator CheckNumberOfLiveMobs(Enemy[] enemies, MobsDestroyed challenge)
        {
            if (enemies.Length == 0)
                throw new Exception("The array must not be empty");
            
            while (true)
            {
                _numberKilledEnemies = 0;
                foreach (var enemy in enemies)
                {
                    if (enemy == null)
                        _numberKilledEnemies++;
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