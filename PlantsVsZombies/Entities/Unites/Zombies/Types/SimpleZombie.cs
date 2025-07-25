using PlantsVsZombies.CoolDown;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Unites.Zombies.Types
{
    internal class SimpleZombie : Zombie
    {
        public SimpleZombie(IBoundsProvider bounds, IPlantsPoolProvider plants, Vector2i position) 
             : base(bounds, plants, new SimpleCoolDown(4), position, '$', 100, 10)
        {

        }
    }
}
