using PlantsVsZombies.Game;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Unites.Zombies;

internal class Zombie : Unit
{
    public Zombie(SceneContext sceneContext, Vector2i position, char symbol, int health) 
         : base(sceneContext, position, symbol, health)
    {
    }

    public override void Update()
    {
        throw new NotImplementedException();
    }
}
