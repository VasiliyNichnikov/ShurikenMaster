using System;
using Enemies;
using TimeDilation;
using UnityEngine;

namespace AttackZone
{
    [RequireComponent(typeof(BoxCollider))]
    public class AttackZoneControl : MonoBehaviour
    {
        [SerializeField] private Enemy[] _enemies;
        private ITimeControl _timeControl;
        
        private SwitchControl _activator;
        private SwitchControl _deactivator;

        private void Start()
        {
            _timeControl = FindObjectOfType<TimeControl>();
            if (_timeControl == null)
                throw new ArgumentNullException();
            
            _activator = new Activator(_enemies, _timeControl);
            _deactivator = new Deactivator(_enemies, _timeControl);
        }

        private void OnTriggerEnter(Collider other)
        {
            _activator.TurnOn(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            _deactivator.TurnOn(other.gameObject);
        }
    }
}