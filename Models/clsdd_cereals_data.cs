using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_ration_card.Models
{
    public class clsdd_cereals_data
    {
        public int dd_cereals_dataid { get; set; }
        public string cereals_name { get; set; }
        public int per_personunit { get; set; }
        public float weight_individual { get; set; }
        public float price_individual { get; set; }
    }
}