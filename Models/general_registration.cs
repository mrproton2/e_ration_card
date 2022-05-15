using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_ration_card.Models
{
    public class general_registration
    {
        public int general_id { get; set; }
        public string card_holdername { get; set; }
        public int rationcard_no { get; set; }
        public string aadharcard_no { get; set; }
        public string pancard_no { get; set; }
        public string states { get; set; }
        public string district { get; set; }
        public string constituency { get; set; }
        public string annual_income { get; set; }
        public string typeof_rationcard { get; set; }
        public string addresss { get; set; }
        public int pincode_no { get; set; }                  
        public int user_id { get; set; }
        

    }
}