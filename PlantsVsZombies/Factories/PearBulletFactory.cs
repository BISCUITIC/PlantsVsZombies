using PlantsVsZombies.Entities.Bullets.Types;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Factories;

internal class PearBulletFactory : BulletFactory
{
    public PearBulletFactory(IBoundsProvider bounds, IEnemyPoolProvider enemyProvider, IBulletPoolProvider bullets)
         : base(bounds, enemyProvider, bullets)
    {
    }
    public override void CreateNew(Vector2i position)
    {
        Bullets.Add(new PearBullet(Bounds, EnemyProvider, position));
    }
}
