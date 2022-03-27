using DrawSlicing;
using Shurikens;
using UnityEngine;

namespace InteractionWithScreen
{
    public class TouchProcessing : MonoBehaviour
    {
        [SerializeField] private DrawTrail _clickTrail;
        [SerializeField] private LaunchShurikens _shurikens;
        
        private void Update()
        {
            Vector3 mousePosition = Input.mousePosition;
            if (Input.GetMouseButtonDown(0))
            {
                _clickTrail.ClickDown(mousePosition);
            }

            else if (Input.GetMouseButton(0))
            {
                _clickTrail.ClickDrag(mousePosition);
            }

            if (Input.GetMouseButtonUp(0))
            {
                _clickTrail.ClickUp(mousePosition);
                _shurikens.ClickUp(_clickTrail);
            }
        }
    }
}