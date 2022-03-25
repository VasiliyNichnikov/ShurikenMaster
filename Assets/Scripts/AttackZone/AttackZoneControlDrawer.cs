using UnityEngine;

namespace AttackZone
{
    public class AttackZoneControlDrawer : MonoBehaviour
    {
        private AttackZoneControl _attackZoneControl;
        
        private void OnDrawGizmos()
        {
            _attackZoneControl = GetComponent<AttackZoneControl>();

            if (_attackZoneControl)
            {
                Gizmos.color = Color.red;
                var thisTransform = transform;

                Vector3 scale = thisTransform.localScale;
                Vector3 boxColliderSize = _attackZoneControl.BoxCollider.size;
                Vector3 boxColliderCenter = _attackZoneControl.BoxCollider.center;

                Vector3 size = new Vector3(scale.x * boxColliderSize.x,
                    scale.y * boxColliderSize.y,
                    scale.z * boxColliderSize.z);

                Gizmos.DrawCube(transform.TransformPoint(boxColliderCenter), size);
            }
        }
    }
}