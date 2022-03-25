using System.Collections;

namespace MovementAlongSpline
{
    public interface IMovement
    {
        public float SpeedMovement { get; set; }
        public float SpeedRotation { get; set; }
        public IEnumerator Drive();
    }
}