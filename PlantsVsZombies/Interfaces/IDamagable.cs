namespace PlantsVsZombies.Interfaces
{
    internal interface IDamagable
    {
        int Health { get; set; }
        void TakeDamage(int damage);
    }
}
