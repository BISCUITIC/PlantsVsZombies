using PlantsVsZombies.Interfaces;

namespace PlantsVsZombies.Entities.Unites.Plants
{
    internal class PlacedPlants : IUpdatable, IDrawable
    {
        private List<Plant> _data;
        public PlacedPlants()
        {
            _data = new List<Plant>();
        }

        public void Add(Plant plant)
        {
            _data.Add(plant);
        }
        public void Remove(List<Plant> removeList)
        {
            foreach (Plant item in removeList)
            {
                _data.Remove(item); 
            }
        }


        public void Update()
        {
            List<Plant> removeList = new List<Plant>();
            foreach (Plant? plant in _data)
            {
                if (plant.IsAlive)
                {
                    plant.Update();
                }
                else
                {
                    removeList.Add(plant);
                }
            }
            Remove(removeList);
        }

       
        public void Draw()
        {
            foreach (Plant plant in _data)
            {
                plant.Draw();
            }
        }
    }
}
