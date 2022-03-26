using MovementAlongSpline;
using Parameters.Player;
using UnityEngine;

namespace TimeDilation
{
    [RequireComponent(typeof(Engine))]
    public class TimeControl: MonoBehaviour, ITimeControl
    {
        [SerializeField] private PlayerParameters _parameters;
        private IEngine _engine;
        
        public void Continue()
        {
            MotionParameter motion = _parameters.DefaultMotion;
            _engine.ToRun(motion.SpeedMovement, motion.SpeedRotation);
        }

        public void SlowDown()
        {
            MotionParameter motion = _parameters.SlowDownMotion;
            _engine.ToRun(motion.SpeedMovement, motion.SpeedRotation);
        }

        public void Stop()
        {
            _engine.Stop();
        }

        private void Start()
        {
            _engine = GetComponent<Engine>();
            Continue();
        }
    }
}