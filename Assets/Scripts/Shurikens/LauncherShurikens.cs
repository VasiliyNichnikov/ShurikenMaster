namespace Shurikens
{
    public class LauncherShurikens
    {
        private PowerShuriken[] _shurikens;
        private float _speed;
        
        public LauncherShurikens(PowerShuriken[] shurikens, float speed)
        {
            _shurikens = shurikens;
            _speed = speed;
        }

        public void Fly()
        {
            // TODO Написан тестовый алгоритм, его нужно будет поменять
            foreach (var shuriken in _shurikens)
            {
                shuriken.StartFly(_speed);
            }
        }
    }
}