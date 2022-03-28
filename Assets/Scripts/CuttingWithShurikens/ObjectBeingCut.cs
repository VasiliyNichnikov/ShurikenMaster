using System;
using MyUtils;
using SliceFramework;
using UnityEngine;

namespace CuttingWithShurikens
{
    public class ObjectBeingCut : MonoBehaviour
    {
        private Material _material;
        private GameObject _thisGameObject;
        private Transform _thisTransform;

        private void Start()
        {
            _material = GetComponent<MeshRenderer>().material;
            _thisGameObject = gameObject;
            _thisTransform = transform;
        }
        
        
        private void OnTriggerEnter(Collider other)
        {
            if (ShurikenUtils.CheckThatObjectIsSuriken(other.gameObject))
            {
                Transform shurikenTransform = other.transform;
                SlicedHull hull = _thisGameObject.Slice(shurikenTransform.position, shurikenTransform.up, _material);
                if (hull != null)
                {
                    Transform left = hull.CreateLowerHull(_thisGameObject, _material).transform;
                    Transform right = hull.CreateUpperHull(_thisGameObject, _material).transform;

                    left.position = _thisTransform.position;
                    right.position = _thisTransform.position;
                    
                    _thisGameObject.SetActive(false);
                }
            }
        }
    }
}