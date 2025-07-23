using PlantsVsZombies.Entities.Bullets;

namespace PlantsVsZombies.Interfaces;

internal interface IBulletFactory
{
    Bullet CreateNewBullet();
}
