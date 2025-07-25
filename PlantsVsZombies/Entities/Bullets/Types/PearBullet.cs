using PlantsVsZombies.CoolDown;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Bullets.Types;

internal class PearBullet : Bullet
{
    public PearBullet(IBoundsProvider bounds, IEnemyPoolProvider enemyProvider, Vector2i position)
         : base(bounds, enemyProvider, new SimpleCoolDown(1), position, '*', 20)
    {

    }
}
