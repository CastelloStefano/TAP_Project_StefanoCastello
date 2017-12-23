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

                City Genova = new City() { Name = "Genova", Arrivals = new List<Leg>(), Departures = new List<Leg>() };
                City Sestri = new City() { Name = "Sestri", Arrivals = new List<Leg>(), Departures = new List<Leg>() };
                City Multedo = new City() { Name = "Multedo", Arrivals = new List<Leg>(), Departures = new List<Leg>() };

                Leg GeSe = new Leg() { Length = 55, Price = 5 };
                Leg SeMu = new Leg() { Length = 65, Price = 12 };
                Genova.Departures.Add(GeSe);
                Sestri.Departures.Add(SeMu);
                Sestri.Arrivals.Add(GeSe);
                Multedo.Arrivals.Add(SeMu);
                GeSe.From = Genova;
                GeSe.To = Sestri;
                SeMu.From = Sestri;
                SeMu.To = Multedo;
                db.Cities.Add(Genova);
                db.Cities.Add(Sestri);
                db.Cities.Add(Multedo);
                db.Legs.Add(GeSe);
                db.Legs.Add(SeMu);

                db.SaveChanges();

                var query1 = from b in db.Cities select new { b.Name, b.Arrivals};
                System.Console.WriteLine(query1.ToString());
                foreach (var q in query1)
                {
                    System.Console.WriteLine(q);
                    foreach (var arr in q.Arrivals)
                    {
                        System.Console.WriteLine(arr.Id + " " + arr.From);
                    }
                    System.Console.ReadKey();
                }

                var query = from b in db.Legs select new {b.Length, b.From, b.To, b.Id, b.Price};
                System.Console.WriteLine(query.ToString());
                foreach (var q in query)
                {
                    System.Console.WriteLine(q);
                    System.Console.ReadKey();
                }

            }
            
        }
    }
}
