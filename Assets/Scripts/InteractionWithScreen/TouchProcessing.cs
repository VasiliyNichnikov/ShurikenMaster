using DrawSlicing;
using Shurikens;
using TimeDilation;
using UnityEngine;

namespace InteractionWithScreen
{
    public class TouchProcessing : MonoBehaviour
    {
        [SerializeField] private DrawTrail _clickTrail;
        [SerializeField] private SurikensControl _shurikens;
        [SerializeField] private TimeControl _timeControl;
        
        private void Update()
        {
            Vector3 mousePosition = Input.mousePosition;
            if (Input.GetMouseButtonDown(0))
            {
                // _timeControl.SlowDown();
                _clickTrail.ClickDown(mousePosition);
            }

            else if (Input.GetMouseButton(0))
            {
                _clickTrail.ClickDrag(mousePosition);
            }

            if (Input.GetMouseButtonUp(0))
            {
                // _timeControl.Continue();
                _clickTrail.ClickUp(mousePosition);
                _shurikens.Launch(_clickTrail);
            }
        }
    }
}