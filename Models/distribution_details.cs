using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_ration_card.Models
{
    public class distribution_details
    {
        public int dd_id { get; set; }   
        public int kotedar_id { get; set; }
        public string kotedar_name { get; set; }
        public string Area { get; set; }
        public int rationcard_no { get; set; }
        public string cardholdernme { get; set; }
        public string Active_mbr { get; set; }
        public string Authenticated_mbr { get; set; }
        public string total_weight { get; set; }
        public int total_price { get; set; }
        public DateTime date_time { get; set; }
        public int general_id { get; set; }

    }
}
