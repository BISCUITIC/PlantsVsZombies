using PlantsVsZombies.Interfaces;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Unites.Zombies.Types
{
    internal class SimpleZombie : Zombie
    {
        public SimpleZombie(IBoundsProvider bounds, IPlantsPoolProvider plants, Vector2i position) 
             : base(bounds, plants, position, '$', 100, 10)
        {

        }
    }
}
