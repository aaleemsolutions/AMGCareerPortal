using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
   internal interface IJobPositions<T>
    {




        List<T> GetAllPositions();
        T GetPosition(int PositionId);
        bool AddPositions(T JPosition);
        bool UpdatePosition(T JPosition);
        bool DeletePosition(T JPosition);


    }
}
