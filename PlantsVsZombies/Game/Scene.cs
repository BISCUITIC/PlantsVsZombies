using PlantsVsZombies.Interfaces;
using PlantsVsZombies.Player;

namespace PlantsVsZombies.Game;

internal class Scene : IUpdatable, IDrawable
{
    private SceneContext _sceneContext;
    private Cursor _cursor;
    private PlayerInput _playerInput;

    /* private Map _map;
       private Plants _plants;
       private BulletsPoll _bulletsPoll;
       private ZombiesWave _zombiesWave;

       private ScorePanel _scorePanle;*/

    public bool IsActive { get; set; }

    public Scene()
    {
        IsActive = true;
        _sceneContext = new SceneContext();
        _playerInput = new PlayerInput();
        _cursor = new Cursor(_sceneContext, _playerInput);
    }

    public void Update()
    {
        _playerInput.Update();
        _cursor.Update();
    }
    public void Draw()
    {
        //DrawUICommponents();
        //DrawGameCommponents();
        _cursor.Draw();
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
