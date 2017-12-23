using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyFakeComponent;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TravelCompanyDatabaseContext())
            {
                db.Database.Connection.Close();
                db.Database.Delete();
                db.Database.Create();

                City Genova = new City(){Name = "Genova", Arrivals = new List<Leg>(), Departures = new List<Leg>()};
                City Sestri = new City(){Name = "Sestri", Arrivals = new List<Leg>(), Departures = new List<Leg>() };
                City Multedo = new City(){Name = "Multedo", Arrivals = new List<Leg>(), Departures = new List<Leg>() };
                
                Leg GeSe = new Leg(){Length = 55, Price = 5};
                Leg SeMu = new Leg(){Length = 65, Price = 12};
                Genova.Departures.Add(GeSe);
                Sestri.Departures.Add(SeMu);
                Sestri.Arrivals.Add(GeSe);
                Multedo.Arrivals.Add(SeMu);

                db.Cities.Add(Genova);
                db.Cities.Add(Sestri);
                db.Cities.Add(Multedo);
                db.Legs.Add(GeSe);
                db.Legs.Add(SeMu);


                db.SaveChanges();



                var query = from b in db.Legs select new {b.Length, b.From, b.To};

            }

        }
    }
}
