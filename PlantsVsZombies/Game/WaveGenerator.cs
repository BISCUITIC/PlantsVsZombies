using PlantsVsZombies.Entities.Unites.Zombies;
using PlantsVsZombies.Factories;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.Game;

internal class WaveGenerator : IUpdatable
{
    private readonly ZombieFactory _zombieFactory;
    private readonly IBoundsProvider _bounds;
    private readonly ZombiesPool _pool;
    private readonly Random _random;

    private int _wavesCount;
    private int _zombieCountInWave;
    private int _zombiesCountInChank;

    private const int _maxZombiesCountInWave = 32;
    private const int _minZombiesCountInWave = 16;
    private readonly int _maxZombiesCountInChank;
    private readonly int _minZombiesCountInChank;

    private const int _spawnCoolDown = 16;
    private int _deltaTicks;

    public WaveGenerator(IBoundsProvider bounds, ZombieFactory factory, ZombiesPool zombies)
    {
        _bounds = bounds;
        _zombieFactory = factory;
        _pool = zombies;

        _random = new Random();

        _wavesCount = 3;
        _maxZombiesCountInChank = _bounds.GetRect().Size.Y / 2;
        _minZombiesCountInChank = _maxZombiesCountInChank / 5;
        _maxZombiesCountInChank = _bounds.GetRect().Size.Y - 2;
        _minZombiesCountInChank = _maxZombiesCountInChank;
    }

    public void Update()
    {
        _deltaTicks++;
        if (PoolIsEmpty() && _wavesCount > 0)
        {
            CreateNewWave();
        }

        if (SpawnCoolDawnIsReady() && _zombiesCountInChank < _zombieCountInWave)
        {
            CreateNewChank();
        }
    }

    private void CreateNewWave()
    {
        _zombieCountInWave = _random.Next(_minZombiesCountInWave, _maxZombiesCountInWave);
        _zombiesCountInChank = _random.Next(_minZombiesCountInChank, _maxZombiesCountInChank);
        _wavesCount--;
    }

    private void CreateNewChank()
    {
        for (int i = 0; i < _zombiesCountInChank; i++)
        {
            Vector2i position = new Vector2i(_bounds.GetRect().Size.X - 2,
                                             _random.Next(1, _bounds.GetRect().Size.Y - 2));
            _zombieFactory.CreateNew(position);
        }
        _zombieCountInWave -= _zombiesCountInChank;
    }

    private bool PoolIsEmpty()
    {
        return _pool.Data.Count == 0;
    }

    private bool SpawnCoolDawnIsReady()
    {
        if (_deltaTicks >= _spawnCoolDown) { _deltaTicks = 0; return true; }
        return false;
    }
}
