using SliceFramework;
using UnityEngine;

namespace CuttingWithShurikens
{
    public class TestSlice : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToSlice;
        [SerializeField] private Material _material;

        private void Start()
        {
            SlicedHull hull = _objectToSlice.Slice(transform.position, transform.up, _material);
            if (hull != null)
            {
                print("hull");
                GameObject left = hull.CreateLowerHull(_objectToSlice, _material);
                GameObject right = hull.CreateUpperHull(_objectToSlice, _material);
                
                // left.SetRotationY(objectToSlice.transform.eulerAngles.y);
                // right.SetRotationY(objectToSlice.transform.eulerAngles.y);
                //
                // slicedObjectLeftPos.SetPositionY(left.GetPositionY());
                // slicedObjectRightPos.SetPositionY(right.GetPositionY());
            }
        }
        
    }
}