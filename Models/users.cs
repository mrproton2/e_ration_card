using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_ration_card.Models
{
    public class users
    {
        public int user_id { get; set; }      
        public string mobile_no { get; set; }    
        public string user_name { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string user_password { get; set; }
        public string user_type { get; set; }
    }
}