using PlantsVsZombies.Entities.Unites.Zombies;
using PlantsVsZombies.Game;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Bullets;

internal abstract class Bullet : Entity, IMoveable
{
    protected int _damage;
    public int Damage => _damage;
    protected IEnemyPoolProvider _enemyProvider;

    private const int _moveCoolDown = 1;
    private int _deltaTicks;

    protected Bullet(IBoundsProvider bounds, IEnemyPoolProvider enemyProvider, Vector2i position, char symbol, int damage)
            : base(bounds, position, symbol)
    {
        _enemyProvider = enemyProvider;
        _damage = damage;
    }

    public override void Update()
    {
        
        CheckForCollision();
        _deltaTicks++;
        if (MoveCoolDownIsComplited()) Move();
        CheckForCollision();       
    }

    public virtual void Move()
    {
        Position.X += 1;
    }

    public bool MoveCoolDownIsComplited()
    {
        if(_deltaTicks >= _moveCoolDown) { _deltaTicks = 0; return true; } 
        return false;
    }

    protected virtual void CheckForCollision()
    {
        if (Position.IsOnBound)
        {
            _isAlive = false;
            return;
        }
        foreach (Zombie zombie in _enemyProvider.Get())
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
