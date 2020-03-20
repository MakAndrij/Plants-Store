using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlantsStore.Models
{
    public class Plant
    {
        public int Id { get; set; }

        public string NameOfSort { get; set; }

        public string Variety { get; set; }

        public  int Price { get; set; }
    }
}