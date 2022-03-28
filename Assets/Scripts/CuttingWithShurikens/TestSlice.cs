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
                // Base left = hull.CreateLowerHull(_objectToSlice, _material).AddComponent(typeof(Base)) as Base;
                // Base right = hull.CreateUpperHull(_objectToSlice, _material).AddComponent(typeof(Base)) as Base;
                //
                // left.SetRotationY(_objectToSlice.transform.eulerAngles.y);
                // right.SetRotationY(_objectToSlice.transform.eulerAngles.y);

                // slicedObjectLeftPos.SetPositionY(left.GetPositionY());
                // slicedObjectRightPos.SetPositionY(right.GetPositionY());
                
                // left.SetRotationY(objectToSlice.transform.eulerAngles.y);
                // right.SetRotationY(objectToSlice.transform.eulerAngles.y);
                //
                // slicedObjectLeftPos.SetPositionY(left.GetPositionY());
                // slicedObjectRightPos.SetPositionY(right.GetPositionY());
            }
        }
        
    }
}