using PlantsVsZombies.Interfaces.Providers;
using PlantsVsZombies.СoordinateSystem;

namespace PlantsVsZombies.UI
{
    internal class ZombiesCountPanel : UIObject<int>
    {
        private int _count;

        public ZombiesCountPanel(IBoundsProvider boundsProvider, Vector2i position)
             : base(boundsProvider, position)
        {

        }

        public override void ChangeValue(int newValue)
        {
            _count = newValue;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write($"Количество зомби : {_count.ToString("000")}");
        }

    }
}
