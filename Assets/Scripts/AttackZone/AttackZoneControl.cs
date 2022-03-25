using System;
using Enemies;
using MyUtils;
using TimeDilation;
using UnityEngine;

namespace AttackZone
{
    public class AttackZoneControl : MonoBehaviour
    {
        public BoxCollider BoxCollider
        {
            get
            {
                BoxCollider collider = GetComponent<BoxCollider>();
                if (collider != null)
                {
                    return collider;
                }

                throw new ArgumentNullException();
            }
        }
        
        [SerializeField] private Enemy[] _enemies;
        private ITimeControl _timeControl;
        private SwitchControl _activator;
        private SwitchControl _deactivator;
        
        

        private void Start()
        {
            _timeControl = FindObjectOfType<TimeControl>();
            if (_timeControl == null)
                throw new ArgumentNullException();
            
            _activator = new Activator(_enemies);
            _deactivator = new Deactivator(_enemies);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (PlayerUtils.CheckThatObjectIsPlayer(other.gameObject))
            {
                _activator.TurnOn();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (PlayerUtils.CheckThatObjectIsPlayer(other.gameObject))
            {
                _deactivator.TurnOn();
            }
        }
    }
}