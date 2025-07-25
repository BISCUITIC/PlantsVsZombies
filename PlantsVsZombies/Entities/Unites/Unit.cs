using PlantsVsZombies.Game;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Unites
{
    internal abstract class Unit : Entity, IDamagable
    {
        private int _health;
        private int Health
        {
            get => _health;
            set
            {
                if (value <= 0) IsAlive = false;
                else _health = value;
            }
        }

        protected Unit(IBoundsProvider bounds, Vector2i position, char symbol, int health) 
                : base(bounds, position, symbol)
        {
            Health = health;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }
}
