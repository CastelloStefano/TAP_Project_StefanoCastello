﻿using System;
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
                
            }

        }
    }
}
