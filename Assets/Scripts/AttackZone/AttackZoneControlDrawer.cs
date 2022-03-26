using UnityEngine;

namespace AttackZone
{
    public class AttackZoneControlDrawer : MonoBehaviour
    {
        private AttackZoneControl _zoneControl;
        private BoxCollider _collider;
        
        private void OnDrawGizmos()
        {
            _zoneControl = GetComponent<AttackZoneControl>();
            _collider = GetComponent<BoxCollider>();
            if (_collider == null || _zoneControl == null) return;
            
            Gizmos.color = Color.red;
            var thisTransform = transform;

            Vector3 scale = thisTransform.localScale;
            Vector3 boxColliderSize = _collider.size;

            Vector3 size = new Vector3(scale.x * boxColliderSize.x,
                scale.y * boxColliderSize.y,
                scale.z * boxColliderSize.z);
                
            Matrix4x4 rotationMatrix = Matrix4x4.TRS(thisTransform.position, thisTransform.rotation, Vector3.one);
            Gizmos.matrix = rotationMatrix;
            if (_zoneControl.PlayerInZone)
            {
                Gizmos.DrawCube(Vector3.zero, size);
            }
            else
            {
                Gizmos.DrawWireCube(Vector3.zero, size);
            }
        }
    }
}