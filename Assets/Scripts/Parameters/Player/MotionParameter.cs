using System;
using UnityEngine;

namespace Parameters.Player
{
    [Serializable]
    public class MotionParameter
    {
        public float SpeedMovement => _speedMovement;
        public float SpeedRotation => _speedRotation;
        
        [SerializeField] private string _name;
        [SerializeField, Range(1, 50)] private float _speedMovement;
        [SerializeField, Range(0.01f, 5)] private float _speedRotation;
    }
}