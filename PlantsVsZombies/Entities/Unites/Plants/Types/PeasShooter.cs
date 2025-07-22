using PlantsVsZombies.Entities.Unites.Plants;
using PlantsVsZombies.Game;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Entities.Unites.Plants.Types;

internal class PeasShooter : Plant
{
    public PeasShooter(SceneContext sceneContext, Vector2i position) : base(sceneContext, position, 100, '#')
    {
       
    }

    public override void Update()
    {
        Console.WriteLine($" {_health} , {_isAlive}");
        Health -= 20;
    }

    public override void Draw()
    {
        base.Draw();
    }
}
