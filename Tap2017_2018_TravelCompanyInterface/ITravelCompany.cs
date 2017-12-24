using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tap2017_2018_TravelCompanyInterface
{
    interface ITravelCompany
    {
        int CreateLeg(string from, string to, int cost, int distance, TransportType transportType);
        void DeleteLeg(int legToBeRemovedId);
        ILegDTO GetLegDTOFromId(int legId);
    }
    
}
