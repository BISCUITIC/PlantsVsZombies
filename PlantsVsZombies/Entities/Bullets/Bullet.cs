using PlantsVsZombies.Entities.Unites.Zombies;
using PlantsVsZombies.Game;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Bullets;

internal abstract class Bullet : Entity
{
    protected int _damage;
    protected const int _speed = 1;
    public int Damage => _damage;

    protected Bullet(SceneContext sceneContext, Vector2i position, char symbol, int damage)
            : base(sceneContext, position, symbol)
    {
        _damage = damage;
    }

    public override void Update()
    {
        Fly();
        CheckForCollision();
    }

    protected virtual void Fly()
    {
        Position.X += _speed;
    }

    protected virtual void CheckForCollision()
    {
        foreach(Entity entity in _sceneContext.ZombiesPool.Data)
        {
            Zombie zombie = (entity as Zombie) ?? throw new ArgumentException("Поле entity должно быть класса Zombie");
            if (zombie.Position == Position)
            {                
                zombie.TakeDamage(_damage);
                _isAlive = false;
                break;
            }
        }
    }
}
