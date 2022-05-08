using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_ration_card.Models
{
    public class clsmembercorrection
    {
        public string old_mbrname { get; set; }
        public string new_mbrname { get; set; }
        public string user_name { get; set; }
        public string mbr_doc1_name { get; set; }
        public string mbr_doc2_name { get; set; }
        public DateTime creatredate { get; set; }
        public string createdby { get; set; }

        public string contcontenttype { get; set; }
        public int user_id { get; set; }
        public int mbr_doc1_size { get; set; }
        public int mbr_doc2_size { get; set; }

        public byte[] mbr_doc1_data { get; set; }

        public byte[] mbr_doc2_data { get; set; }
    }
}