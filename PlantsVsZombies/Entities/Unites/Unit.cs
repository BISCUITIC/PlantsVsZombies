using PlantsVsZombies.Game;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Unites
{
    internal abstract class Unit : Entity, IDamagable
    {
        protected int _health;
        public int Health
        {
            get => _health;
            set
            {
                if (value <= 0) _isAlive = false;
                else _health = value;
            }
        }

        protected Unit(SceneContext sceneContext, Vector2i position, char symbol, int health) 
                : base(sceneContext, position, symbol)
        {
            _health = health;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
        //void IDamagable.TakeDamage(int damage)
        //{
        //    Health -= damage;
        //}
    }
}
