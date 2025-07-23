using PlantsVsZombies.Entities.Unites.Zombies;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Interfaces;

internal interface IZombieFactory
{
    Zombie CreateNewZombie(IBoundsProvider bounds, Vector2i postion);
}
