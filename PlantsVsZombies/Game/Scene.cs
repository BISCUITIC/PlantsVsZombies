using PlantsVsZombies.Interfaces;
using PlantsVsZombies.User;
using PlantsVsZombies.СoordinateSystem;
using PlantsVsZombies.Entities.Unites.Plants;
using PlantsVsZombies.Entities.Unites.Plants.Types;

namespace PlantsVsZombies.Game;

internal class Scene : IUpdatable, IDrawable
{
    private SceneContext _sceneContext;

    private Cursor _cursor;
    private PlayerInput _playerInput;


    //private Map _map;

    //private BulletsPoll _bulletsPoll;
    //private ZombiesWave _zombiesWave;
    //private PlacedPlants _plants;

    //private ScorePanel _scorePanle;

    public bool IsActive { get; set; }

    public Scene()
    {
        IsActive = true;

        _sceneContext = new SceneContext();
        _playerInput = new PlayerInput();
        _cursor = new Cursor(_sceneContext, Vector2i.Zero, _playerInput);

        _sceneContext.Plants.Add(new PeasShooter(_sceneContext, new Vector2i(5, 5)));        
    }

    public void Update()
    {
        _playerInput.Update();
        _cursor.Update();

        _sceneContext.Update();        
    }
    public void Draw()
    {
        //DrawUICommponents();
        //DrawGameCommponents();
        _cursor.Draw();

        _sceneContext.Draw();        
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
