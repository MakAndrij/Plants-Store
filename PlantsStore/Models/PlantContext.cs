using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PlantsStore.Models
{
    public class PlantContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }

        public DbSet<Purchase> Purchases { get; set; }
    }
    public class PlantDbInitializer : DropCreateDatabaseAlways<PlantContext>
    {
        protected override void Seed(PlantContext db)
        {
            db.Plants.Add(new Plant { NameOfSort = "Haworthia", Variety = "Bayeri", Price = 550 });
            db.Plants.Add(new Plant { NameOfSort = "Gasteria", Variety = "Armstrongii", Price = 280 });
            db.Plants.Add(new Plant { NameOfSort = "Aloe", Variety = "Snow White", Price = 350 });

            base.Seed(db);
        }
    }
}