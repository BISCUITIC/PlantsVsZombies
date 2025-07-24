using PlantsVsZombies.Entities.Unites.Plants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantsVsZombies.Interfaces.Providers
{
    internal interface IPoolProvider<T>
    {
        IReadOnlyCollection<T> Get();
        void Add(T item);
    }
}
