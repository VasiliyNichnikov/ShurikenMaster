using System;
using MyUtils;
using UnityEngine;

namespace Shurikens
{
    [RequireComponent(typeof(Rigidbody))]
    public class SwitchRigidbody : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {   
            if (ShurikenUtils.CheckThatObjectIsSuriken(collision.gameObject) == false)
            {
            }
        }
    }
}