using PlantsVsZombies.Entities.Unites.Zombies;
using PlantsVsZombies.Entities.Unites.Zombies.Types;
using PlantsVsZombies.Factories;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.СoordinateSystem;
using System.Data;

namespace PlantsVsZombies.Game;

internal class WaveGenerator: IUpdatable
{
    ZombiesPool _pool;
    IZombieFactory _zombieFactory;
    IBoundsProvider _bounds;
    private int _wavesCount = 3;
    private readonly Random _random;

    public WaveGenerator(IBoundsProvider bounds, IZombieFactory factory, ZombiesPool zombies)
    {
        _bounds = bounds;
        _zombieFactory = factory;
        _pool = zombies;
        _random = new Random();       
    }

    public void Update()
    {
        if (_pool.Data.Count == 0 && _wavesCount > 0){
            CreateNewWave(); 
            _wavesCount--;
        }
    }

    private void CreateNewWave()
    {
        Vector2i position = new Vector2i(_bounds.GetRect().Size.X - 2,
                                         _random.Next(1, _bounds.GetRect().Size.Y - 2));
        _pool.Add(_zombieFactory.CreateNewZombie(_bounds, position));
    }
}
