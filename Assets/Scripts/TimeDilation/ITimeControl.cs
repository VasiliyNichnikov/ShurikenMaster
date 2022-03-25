namespace TimeDilation
{
    public interface ITimeControl
    {
        public void Continue();
        public void SlowDown();
        public void Stop();
    }
}