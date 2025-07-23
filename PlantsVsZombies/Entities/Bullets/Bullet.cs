using PlantsVsZombies.Entities.Unites.Zombies;
using PlantsVsZombies.Game;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Bullets;

internal abstract class Bullet : Entity
{
    protected int _damage;
    protected IEnemyPoolProvider _enemyProvider;
    protected const int _speed = 1;
    public int Damage => _damage;

    protected Bullet(IBoundsProvider bounds, IEnemyPoolProvider enemyProvider, Vector2i position, char symbol, int damage)
            : base(bounds, position, symbol)
    {
        _enemyProvider = enemyProvider;
        _damage = damage;
    }

    public override void Update()
    {
        CheckForCollision();
        Fly();
        CheckForCollision();       
    }

    protected virtual void Fly()
    {
        Position.X += _speed;
    }

    protected virtual void CheckForCollision()
    {
        if (Position.IsOnBound)
        {
            _isAlive = false;
            return;
        }
        foreach (Zombie zombie in _enemyProvider.GetZombiesPool())
        {            
            if (zombie.Position == Position)
            {                
                zombie.TakeDamage(_damage);
                _isAlive = false;
                return;
            }
           
        }
    }
}
