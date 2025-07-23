using PlantsVsZombies.Entities.Bullets;
using PlantsVsZombies.Entities.Bullets.Types;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Factories;

internal class PearBulletFactory : IBulletFactory
{
    private readonly IBoundsProvider _bounds;
    private readonly IEnemyPoolProvider _enemyProvider;
    private readonly Vector2i _position;
    public PearBulletFactory(IBoundsProvider bounds, IEnemyPoolProvider enemyProvider, Vector2i position)
    {
        _bounds = bounds;
        _enemyProvider = enemyProvider;
        _position = position;
    }
    public Bullet CreateNewBullet()
    {
        return new PearBullet(_bounds, _enemyProvider, _position);
    }
}
