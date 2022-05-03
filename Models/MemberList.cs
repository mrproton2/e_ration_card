using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_ration_card.Models
{
    public class MemberList
    {
        public int mbrlist_id { get; set; }
        public string Name { get; set; }
        public string relation { get; set; }
        public int age { get; set; }
        public DateTime creatredate { get; set; }
        public string createdby { get; set; }
        public string Status { get; set; }
        public int user_id { get; set; }
        public string aadharno { get; set; }
        public DateTime dob { get; set; }


    }
}