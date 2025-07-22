using PlantsVsZombies.Entities.Bullets;
using PlantsVsZombies.Entities.Unites.Plants;
using PlantsVsZombies.Entities.Unites.Zombies;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Game;

internal class SceneContext: IUpdatable, IDrawable
{
    private Vector2i _size = new Vector2i(120, 30);
    public Vector2i Size => _size;

    private PlacedPlants _plants = new PlacedPlants();
    public PlacedPlants Plants => _plants;

    private BulletsPool _bulletsPool = new BulletsPool();
    public BulletsPool BulletsPool => _bulletsPool; 

    private ZombiesPool _zombiesPool = new ZombiesPool();
    public ZombiesPool ZombiesPool => _zombiesPool;

    public void Update()
    {
        _plants.Update();
        _bulletsPool.Update();        
        _zombiesPool.Update();
    }

    public void Draw()
    {
        _plants.Update();
        _zombiesPool.Draw();
        _bulletsPool.Draw();
    }
}
