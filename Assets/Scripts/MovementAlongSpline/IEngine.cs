namespace MovementAlongSpline
{
    public interface IEngine
    {
        public void ToRun();
        public void ToRun(float speedMovement, float speedRotation);
        public void Stop();
    }
}