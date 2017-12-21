using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ITravelCompany
{
    public interface ITravelCompany
    {
        string Name { get; }

        int CreateLeg(string from, string to, int cost, int distance, TransportType transportType);
        void DeleteLeg(int legToBeRemoved);
        // ILedDTO GetLegDTOFromId(int legId);
    }

    public enum TransportType
    {
        None = 0,
        Plane = 1,
        Train = 2,
        Bus = 3,
        Ship = 8 //TODO 8 not 5 ?
    }
}
