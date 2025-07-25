namespace PlantsVsZombies.CoolDown
{
    internal class SimpleCoolDown: ICoolDown
    {
        private int _deltaTicks;
        private readonly int _coolDown;

        public SimpleCoolDown(int coolDown)
        {
            _coolDown = coolDown;
        }

        public void Update()
        {
            _deltaTicks++;
        }

        public bool IsReady()
        {
            if(_deltaTicks >= _coolDown) { _deltaTicks = 0; return true; }
            else { return false; }
        }
    }
}
