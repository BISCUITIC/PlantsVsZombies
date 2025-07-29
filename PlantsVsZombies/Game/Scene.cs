using PlantsVsZombies.Entities.Bullets;
using PlantsVsZombies.Entities.Unites.Plants;
using PlantsVsZombies.Entities.Unites.Plants.Types;
using PlantsVsZombies.Entities.Unites.Zombies;
using PlantsVsZombies.Entities.Unites.Zombies.Types;
using PlantsVsZombies.Factories;
using PlantsVsZombies.GameObjects;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.UI;
using PlantsVsZombies.User;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Game;

internal class Scene : IUpdatable, IDrawable, IBoundsProvider
{
    private Player _player;

    private Vector2i _position;
    private Vector2i _size;

    private Map _map;
    private PlacedPlants _plants;
    private BulletsPool _bullets;
    private ZombiesPool _zombies;
    private WaveGenerator _waveGenerator;

    //private ScorePanel _scorePanle;
    private ZombiesCountPanel _zombiesCountPanel;

    public bool IsActive { get; set; }

    public Scene()
    {
        IsActive = true;
        _position = new Vector2i(0, 0);
        _size = new Vector2i(Console.WindowWidth, Console.WindowHeight);
        
        _map = new Map(this, new Vector2i(4, 2), new Vector2i(24, 16));
        _plants = new PlacedPlants();
        _bullets = new BulletsPool();
        _zombies = new ZombiesPool();
        _waveGenerator = new WaveGenerator(_map, new SimpleZombieFactory(_map, _plants, _zombies, GameOver), _zombies);

        _player = new Player(_map, new List<PlantFactory> { new PearShooterFactory(_map, _bullets, _zombies, _plants)});

        //new PearShooterFactory(_map, _bullets, _zombies, _plants).AddNewObjectAtPool(new Vector2i(1,1));
        _zombiesCountPanel = new ZombiesCountPanel(this, new Vector2i(0, 0));

        OnEnable();
    }

    private void OnEnable()
    {
        _zombies.ChangeCount += _zombiesCountPanel.ChangeValue;
    }

    public void Update()
    {
        _player.Update();        

        _map.Update();
        _plants.Update();
        _bullets.Update();
        _zombies.Update();     
        
        _waveGenerator.Update();           
    }
    public void Draw()
    {
        _zombiesCountPanel.Draw();

        _map.Draw();
        _plants.Draw();
        _bullets.Draw();
        _zombies.Draw();

        _player.Draw();            
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

    private void GameOver()
    {
        IsActive = false;
        Console.SetCursorPosition(0, 20);
        Console.WriteLine("Game Over");
    }
}
