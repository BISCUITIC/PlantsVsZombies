using PlantsVsZombies.Entities.Bullets;
using PlantsVsZombies.Entities.Unites;
using PlantsVsZombies.Game;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Unites.Plants
{
    internal abstract class Plant : Unit
    {
        protected bool _isEnemyDetected;        
        protected Bullet _bullet;
       
        public bool IsAlive => _isAlive;

        protected Plant(SceneContext sceneContext, Vector2i position, int health, char symbol, Bullet bullet) : base(sceneContext, position)
        {
            _isAlive = true;
            _isEnemyDetected = false;
            _symbol = symbol;
            _bullet = bullet;
            Health = health;
        }

        public abstract void Shoot();

        public override void Draw()
        {
            Console.SetCursorPosition(_position.Y, _position.X);
            Console.Write(_symbol);
        }
    }
}
