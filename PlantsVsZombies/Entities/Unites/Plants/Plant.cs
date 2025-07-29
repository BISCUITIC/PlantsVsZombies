
using PlantsVsZombies.CoolDown;
using PlantsVsZombies.Entities.Bullets;
using PlantsVsZombies.Entities.Unites.Zombies;
using PlantsVsZombies.Factories;
using PlantsVsZombies.Game;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Unites.Plants;

internal abstract class Plant : Unit
{
    private bool _isEnemyDetected;
    private BulletFactory _bulletFactory;    
    private IEnemyPoolProvider _enemyPoolProvider;
    private ICoolDown _shootCoolDown;   

    protected Plant(IBoundsProvider bounds, BulletFactory bulletFactory, IEnemyPoolProvider enemyPoolProvider,  
                    ICoolDown shootCoolDown,Vector2i position, char symbol, int health)
            : base(bounds, position, symbol, health)
    {
        _isEnemyDetected = false;
        _bulletFactory = bulletFactory;        
        _enemyPoolProvider = enemyPoolProvider;
        _shootCoolDown = shootCoolDown;
    }

    public override void Update()
    {
        _shootCoolDown.Update();
        DetectEnemy();
    
        if (_isEnemyDetected && _shootCoolDown.IsReady())
        {
            Shoot();                  
        }
    }

    private void Shoot()
    {
        _bulletFactory.AddNewObjectAtPool(Position.ToLocalCoordinates());
    }

    private void DetectEnemy()
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
