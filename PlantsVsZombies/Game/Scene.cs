using PlantsVsZombies.Interfaces;
using PlantsVsZombies.User;
using PlantsVsZombies.СoordinateSystem;
using PlantsVsZombies.Entities.Unites.Plants;

namespace PlantsVsZombies.Game;

internal class Scene : IUpdatable, IDrawable
{
    private SceneContext _sceneContext;
    private Cursor _cursor;
    private PlayerInput _playerInput;

    private PlacedPlants _plants;
    //private Map _map;
    //private BulletsPoll _bulletsPoll;
    //private ZombiesWave _zombiesWave;

    //private ScorePanel _scorePanle;

    public bool IsActive { get; set; }

    public Scene()
    {
        IsActive = true;

        _sceneContext = new SceneContext();
        _playerInput = new PlayerInput();
        _cursor = new Cursor(_sceneContext, Vector2i.Zero, _playerInput);

        _plants = new PlacedPlants();
        _plants.Add(new PeasShooter(_sceneContext, new Vector2i(5, 5)));
    }

    public void Update()
    {
        _playerInput.Update();
        _cursor.Update();

        _plants.Update();
    }
    public void Draw()
    {
        //DrawUICommponents();
        //DrawGameCommponents();
        _cursor.Draw();

        _plants.Draw();
    }

    /*private void DrawUICommponents()
    {
        _scorePanle.Draw();
    }
    private void DrawGameCommponents()
    {
        _map.Draw();
        _zombiesWave.Draw();
        _plants.Draw();
    }*/
}
