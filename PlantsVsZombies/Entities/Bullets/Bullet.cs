using PlantsVsZombies.CoolDown;
using PlantsVsZombies.Entities.Unites.Zombies;
using PlantsVsZombies.Game;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Bullets;

internal abstract class Bullet : Entity
{
    private int _damage;
    private IEnemyPoolProvider _enemyProvider;
    private ICoolDown _moveCoolDown;
    protected int Damage => _damage;
    
    protected Bullet(IBoundsProvider bounds, IEnemyPoolProvider enemyProvider, 
                     ICoolDown shootCoolDown, Vector2i position, char symbol, int damage)
            : base(bounds, position, symbol)
    {
        _enemyProvider = enemyProvider;
        _damage = damage;
        _moveCoolDown = shootCoolDown;
    }

    public override void Update()
    {
        
        CheckForCollision();
        _moveCoolDown.Update();
        if (_moveCoolDown.IsReady()) Move();
        CheckForCollision();       
    }

    protected virtual void Move()
    {
        Position.X += 1;
    }

    protected virtual void CheckForCollision()
    {
        if (Position.IsOnBound)
        {
            IsAlive = false;
            return;
        }
        foreach (Zombie zombie in _enemyProvider.Get())
        {            
            if (zombie.Position == Position)
            {                
                zombie.TakeDamage(_damage);
                IsAlive = false;
                return;
            }
           
        }
    }
}
