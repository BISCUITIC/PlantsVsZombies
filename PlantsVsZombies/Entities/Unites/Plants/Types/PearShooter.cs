using PlantsVsZombies.Entities.Bullets.Types;
using PlantsVsZombies.Factories;
using PlantsVsZombies.Game;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Unites.Plants.Types;

internal class PearShooter : Plant
{
    public PearShooter(IBoundsProvider bounds, IBulletPoolProvider bulletPool, IEnemyPoolProvider enemies, Vector2i position)
         : base(bounds, new PearBulletFactory(bounds, enemies, bulletPool) , enemies, bulletPool, position, '#', 100)
    {        
    }   
}
