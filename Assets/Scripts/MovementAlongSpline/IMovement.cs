using System.Collections;

namespace MovementAlongSpline
{
    public interface IMovement
    {
        public bool Pause { get; set; }
        public float SpeedMovement { get; set; }
        public float SpeedRotation { get; set; }
        public IEnumerator Drive();
    }
}