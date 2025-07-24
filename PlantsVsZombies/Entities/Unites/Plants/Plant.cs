
using PlantsVsZombies.Entities.Bullets;
using PlantsVsZombies.Entities.Unites.Zombies;
using PlantsVsZombies.Factories;
using PlantsVsZombies.Game;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Unites.Plants;

internal abstract class Plant : Unit, IShooter
{
    protected bool _isEnemyDetected;
    protected BulletFactory _bulletFactory;
    protected IBulletPoolProvider _bulletPool;
    protected IEnemyPoolProvider _enemyPoolProvider;

    private const int _shootCoolDown = 3;
    private int _deltaTicks;

    protected Plant(IBoundsProvider bounds, BulletFactory bulletFactory, IEnemyPoolProvider enemyPoolProvider,  IBulletPoolProvider bulletPool, Vector2i position, char symbol, int health)
            : base(bounds, position, symbol, health)
    {
        _isEnemyDetected = false;
        _bulletFactory = bulletFactory;
        _bulletPool = bulletPool;
        _enemyPoolProvider = enemyPoolProvider;
        Health = health;
        _deltaTicks = 0;
    }

    public override void Update()
    {
        _deltaTicks++;
        DetectEnemy();
    
        if (_isEnemyDetected && ShootCoolDownIsComplited())
        {
            Shoot();                  
        }
    }

    public void Shoot()
    {
        _bulletFactory.CreateNew(_position.ToLocalCoordinates());
    }

    public bool ShootCoolDownIsComplited()
    {
        if (_deltaTicks >= _shootCoolDown) { _deltaTicks = 0; return true; }
        return false;
    }

    public virtual void DetectEnemy()
    {
        _isEnemyDetected = false;
        foreach (Zombie zombie in _enemyPoolProvider.Get())
        {
            if(zombie.Position.Y == Position.Y)
            {
                _isEnemyDetected = true;                
            }
        }
    }
}
