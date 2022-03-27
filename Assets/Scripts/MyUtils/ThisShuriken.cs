using UnityEngine;

namespace Shurikens
{
    public class ThisShuriken : MonoBehaviour
    {
        private float _width;
        private float _length;
        
        private MeshFilter _meshFilter;

        private Vector3 _topPointX, _bottomPointX;
        private Vector3 _topPointZ, _bottomPointZ;
        
        private void Awake()
        {
            _meshFilter = GetComponent<MeshFilter>();
            CalculateSpecifications();
        }

        private void CalculateSpecifications()
        {
            Bounds bounds = _meshFilter.mesh.bounds;
            Vector3 center = bounds.center;
            _width = CalculateWidth(bounds, center);
            _length = CalculateLength(bounds, center);
        }

        private float CalculateWidth(Bounds bounds, Vector3 center)
        {
            _topPointX = bounds.ClosestPoint(new Vector3(Mathf.Infinity, center.y, center.z));
            _bottomPointX = bounds.ClosestPoint(new Vector3(-Mathf.Infinity, center.y, center.z));
            return Vector3.Distance(_topPointX, _bottomPointX);
        }
        
        private float CalculateLength(Bounds bounds, Vector3 center)
        {
            _topPointZ = bounds.ClosestPoint(new Vector3(center.x, center.y, Mathf.Infinity));
            _bottomPointZ = bounds.ClosestPoint(new Vector3(center.x, center.y,-Mathf.Infinity));
            return Vector3.Distance(_topPointZ, _bottomPointZ);
        }

        private void OnDrawGizmos()
        {
            if (_topPointX == Vector3.zero 
                || _topPointZ == Vector3.zero 
                || _bottomPointX == Vector3.zero 
                || _bottomPointZ == Vector3.zero) return;
            
            Gizmos.color = Color.black;
            
            Vector3 worldTopPointX = transform.TransformPoint(_topPointX);
            Vector3 worldBottomPointX = transform.TransformPoint(_bottomPointX);
            
            Gizmos.DrawSphere(worldTopPointX, 0.1f);
            Gizmos.DrawSphere(worldBottomPointX, 0.1f);

            Vector3 worldTopPointZ = transform.TransformPoint(_topPointZ);
            Vector3 worldBottomPointZ = transform.TransformPoint(_bottomPointZ);
            
            Gizmos.DrawSphere(worldTopPointZ, 0.1f);
            Gizmos.DrawSphere(worldBottomPointZ, 0.1f);
            
            Gizmos.color = Color.red;
            Gizmos.DrawLine(worldTopPointX, worldBottomPointX);
            Gizmos.DrawLine(worldTopPointZ, worldBottomPointZ);
        }
    }
}