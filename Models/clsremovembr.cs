using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_ration_card.Models
{
    public class clsremovembr
    {
        public string new_membername { get; set; }
        public string relation { get; set; }
        public string user_name { get; set; }
        public string removembr_doc1_name { get; set; }
        public string removembr_doc2_name { get; set; }
        public DateTime creatredate { get; set; }
        public string createdby { get; set; }

        public string contcontenttype { get; set; }
        public int user_id { get; set; }
        public int removembr_doc1_size { get; set; }
        public int removembr_doc2_size { get; set; }

        public byte[] removembr_doc1_data { get; set; }

        public byte[] removembr_doc2_data { get; set; }
    }
}