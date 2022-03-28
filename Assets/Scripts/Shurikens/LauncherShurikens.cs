using System.Collections;
using Parameters.Shuriken;
using UnityEngine;

namespace Shurikens
{
    public class LauncherShurikens
    {
        private PowerShuriken[] _shurikens;
        private ShurikenParameters _parameters;
        
        public LauncherShurikens(PowerShuriken[] shurikens, ShurikenParameters parameters)
        {
            _shurikens = shurikens;
            _parameters = parameters;
        }

        public IEnumerator Fly()
        {
            // TODO Написан тестовый алгоритм, его нужно будет поменять
            foreach (var shuriken in _shurikens)
            {
                shuriken.gameObject.SetActive(true);
                shuriken.StartFly(_parameters.Speed);
                yield return new WaitForSeconds(_parameters.DelayBetweenShurikenDepartures);
            }
        }
    }
}