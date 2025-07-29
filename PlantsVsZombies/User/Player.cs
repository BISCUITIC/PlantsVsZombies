using PlantsVsZombies.СoordinateSystem;
using PlantsVsZombies.Interfaces;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.Factories;

namespace PlantsVsZombies.User;

internal class Player: IUpdatable, IDrawable
{
    private List<PlantFactory> _plantsFactories;
    private int _energy;
    private int _score;

    private Cursor _cursor;
    private PlayerInput _input;

    public Player(IBoundsProvider bounds, List<PlantFactory> plantsFactories)
    {
        _input = new PlayerInput();
        _cursor = new Cursor(bounds, new Vector2i(0, 0), _input);
        _plantsFactories = plantsFactories;
    }
    public void Update()
    {        
        _cursor.Update();
        _input.Update();

        if (IsKeyInputValid())
        {
            int index = GetIndex();            
            _plantsFactories[index].AddNewObjectAtPool(_cursor.Position.ToLocalCoordinates());
        }
    }

    private bool IsKeyInputValid()
    {
        return _input.GetLastPressedKey() is not null && 
               (int)_input.GetLastPressedKey()?.Key >= (int)ConsoleKey.D1 && 
               (int)_input.GetLastPressedKey()?.Key <= (int)ConsoleKey.D9;
    }
    private int GetIndex()
    {
        return (int)_input.GetLastPressedKey()?.Key - (int)ConsoleKey.D1;
    }

    public void Draw()
    {
        _cursor.Draw();
    }

}
