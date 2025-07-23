using PlantsVsZombies.Entities.Bullets;

namespace PlantsVsZombies.Interfaces;

internal interface IBulletPoolProvider
{
    void Add(Bullet bullet);
}

internal delegate void AddBullet(Bullet bullet);