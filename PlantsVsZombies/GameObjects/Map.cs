using PlantsVsZombies.Abstractions;
using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;
using System.Drawing;

namespace PlantsVsZombies.GameObjects
{
    internal class Map : GameObject, IBoundsProvider
    {
        private readonly char[,] _data;
        private readonly Vector2i _size;

        public Map(IBoundsProvider bounds, Vector2i position, Vector2i size) : base(bounds, position)
        {
            _size = size;
            _data = new char[_size.Y, _size.X];
            InitField();
        }

        private void InitField()
        {            
            for (int i = 0; i < _size.Y; i++)
            {
                for (int j = 0; j < _size.X; j++)
                {
                    _data[i, j] = '.';
                }
            }
            for (int i = 0; i < _size.Y; i++)
            {
                _data[i, 0] = '|';
                _data[i, _size.X - 1] = '|';
            }
            for (int j = 0; j < _size.X; j++)
            {
                _data[0, j] = '-';
                _data[_size.Y - 1, j] = '-';
            }
        }

        public Rect GetRect()
        {
            return new Rect(Position, _size);
        }

        public override void Update()
        {
            
        }

        public override void Draw()
        {
            for (int i = 0; i < _size.Y; i++)
            {
                Console.SetCursorPosition(Position.X, Position.Y + i);
                for (int j = 0; j < _size.X; j++)
                {
                    Console.Write(_data[i, j]);
                }
            }
        }
    }
}
