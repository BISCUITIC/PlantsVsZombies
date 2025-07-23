namespace PlantsVsZombies.СoordinateSystem
{
    internal class Rect
    {
        private Vector2i _position;
        public Vector2i Position => _position;

        private Vector2i _size;
        public Vector2i Size => _size;

        public Vector2i LeftTopCorner => _position;
        public Vector2i RightBottomCorner => _position + _size;

        public Rect(Vector2i position, Vector2i size)
        {
            _position = position;
            _size = size;
        }        
    }
}
