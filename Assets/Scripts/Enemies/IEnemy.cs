namespace Enemies
{
    public interface IEnemy
    {
        public bool IsDead { get; }
        public void Attack();
    }
}