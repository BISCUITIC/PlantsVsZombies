using PlantsVsZombies.Entities.Bullets;
using PlantsVsZombies.Entities.Unites.Plants;
using PlantsVsZombies.Entities.Unites.Plants.Types;
using PlantsVsZombies.Entities.Unites.Zombies;
using PlantsVsZombies.Entities.Unites.Zombies.Types;
using PlantsVsZombies.Factories;
using PlantsVsZombies.GameObjects;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.User;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Game;

internal class Scene : IUpdatable, IDrawable, IBoundsProvider
{
    private Cursor _cursor;
    private PlayerInput _playerInput;

    private Vector2i _position;
    private Vector2i _size;

    private Map _map;
    private PlacedPlants _plants;
    private BulletsPool _bullets;
    private ZombiesPool _zombies;
    private WaveGenerator _waveGenerator;

    //private ScorePanel _scorePanle;

    public bool IsActive { get; set; }

    public Scene()
    {
        IsActive = true;
        _position = new Vector2i(0, 0);
        _size = new Vector2i(Console.WindowWidth, Console.WindowHeight);
        
        _map = new Map(this, new Vector2i(4, 2), new Vector2i(24, 3));
        _plants = new PlacedPlants();
        _bullets = new BulletsPool();
        _zombies = new ZombiesPool();
        _waveGenerator = new WaveGenerator(_map, new SimpleZombieFactory(_plants), _zombies); 

        _playerInput = new PlayerInput();
        _cursor = new Cursor(_map, Vector2i.Zero, _playerInput);

        _plants.Add(new PearShooter(_map, _bullets, _zombies, new Vector2i(5, 1)));
        //_zombies.Add(new SimpleZombie(_map, _plants, new Vector2i(14, 1)));
    }

    public void Update()
    {
        _playerInput.Update();
        _cursor.Update();

        _map.Update();
        _plants.Update();
        _bullets.Update();
        _zombies.Update();     
        
        _waveGenerator.Update();
        //_sceneContext.Update();        
    }
    public void Draw()
    {
        //DrawUICommponents();
        //DrawGameCommponents();
        Console.SetCursorPosition(0, 0);
        Console.Write($"Zombies Count: {_zombies.Data.Count}");

        _map.Draw();
        _plants.Draw();
        _bullets.Draw();
        _zombies.Draw();

        _cursor.Draw();
        //_sceneContext.Draw();        
    }

    public Rect GetRect()
    {
        return new Rect(_position, _size);
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
