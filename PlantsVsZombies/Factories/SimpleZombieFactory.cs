using PlantsVsZombies.Entities.Bullets;
using PlantsVsZombies.Entities.Bullets.Types;
using PlantsVsZombies.Entities.Unites.Zombies;
using PlantsVsZombies.Entities.Unites.Zombies.Types;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.СoordinateSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantsVsZombies.Factories
{
    internal class SimpleZombieFactory : IZombieFactory
    {       
        private readonly IPlantsPoolProvider _plant;

        public SimpleZombieFactory(IPlantsPoolProvider plant)
        {
            _plant = plant;
        }
        public Zombie CreateNewZombie(IBoundsProvider bounds, Vector2i position)
        {
            return new SimpleZombie(bounds, _plant, position);
        }
    }
}
