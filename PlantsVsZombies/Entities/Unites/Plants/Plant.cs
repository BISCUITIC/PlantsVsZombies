
using PlantsVsZombies.Entities.Bullets;
using PlantsVsZombies.Entities.Unites.Zombies;
using PlantsVsZombies.Game;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Unites.Plants;

internal abstract class Plant : Unit
{
    protected bool _isEnemyDetected;
    protected IBulletFactory _bulletFactory;
    protected IBulletPoolProvider _bulletPool;
    protected IEnemyPoolProvider _enemyPoolProvider;

    private const int _coolDown = 2;
    private int _deltaTicks;
    protected Plant(IBoundsProvider bounds, IBulletFactory bulletFactory, IEnemyPoolProvider enemyPoolProvider,  IBulletPoolProvider bulletPool, Vector2i position, char symbol, int health)
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
        DetectEnemy();
        _deltaTicks++;

        if (_isEnemyDetected && _deltaTicks > _coolDown)
        {
            _deltaTicks = 0;
            Shoot();
            _isEnemyDetected = false;
        }
    }


    public virtual void Shoot()
    {
        _bulletPool.Add(_bulletFactory.CreateNewBullet());
    }
    public virtual void DetectEnemy()
    {
        foreach(Zombie zombie in _enemyPoolProvider.GetZombiesPool())
        {
            if(zombie.Position.Y == Position.Y)
            {
                _isEnemyDetected = true;
            }
        }
    }
}
