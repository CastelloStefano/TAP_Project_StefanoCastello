﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyFakeComponent
{
    public class TravelCompanyDatabaseContext: DbContext
    {
        static TravelCompanyDatabaseContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<TravelCompanyDatabaseContext>());
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Leg> Legs { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //base.OnModelCreating(modelBuilder);


        //}
    }

    public class City
    {
        [Key]
        public string Name { get; set; }
        public virtual ICollection<Leg> Departures { get; set; }
        public virtual ICollection<Leg> Arrivals { get; set; }
    }

    public class Leg
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual City From { get; set; }
        public virtual City To { get; set; }
        public int Length { get; set; }
        public int Price { get; set; }
    }
}
