using System;
using Enemies;
using TimeDilation;
using UnityEngine;

namespace AttackZone
{
    [RequireComponent(typeof(BoxCollider), 
        typeof(Activator), 
        typeof(Deactivator))]
    public class AttackZoneControl : MonoBehaviour
    {
        public bool PlayerInZone => _playerInZone;
        
        [SerializeField] private Enemy[] _enemies;
        private ITimeControl _timeControl;

        private bool _playerInZone;
        private SwitchControl _activator;
        private SwitchControl _deactivator;

        private void Start()
        {
            _timeControl = FindObjectOfType<TimeControl>();
            if (_timeControl == null)
                throw new ArgumentNullException();
            InitActivator();
            InitDeactivator();
        }

        private void InitActivator()
        {
            _activator = GetComponent<Activator>();
            InitParametersSwitchControl(_activator);
        }

        private void InitDeactivator()
        {
            _deactivator = GetComponent<Deactivator>();
            InitParametersSwitchControl(_deactivator);
        }

        private void InitParametersSwitchControl(SwitchControl control)
        {
            control.Enemies = _enemies as IEnemy[];
            control.TimeControl = _timeControl;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            _playerInZone = true;
            _activator.TurnOn(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            // _playerInZone = false;
            _deactivator.TurnOn(other.gameObject);
        }
    }
}