using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_ration_card.Models
{
    public class kotedar_registration
    {
        public int kotedar_id { get; set; }
        public string kotedar_name { get; set; }
        public string username { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string passwords { get; set; }
        public string user_type { get; set; }
        public string kotedar_no { get; set; }
        public string aadhar_no { get; set; }
        public string pan_no { get; set; }
        public string addresss { get; set; }
        public int pincode_no { get; set; }
        public string states { get; set; }
        public string district { get; set; }
        public string Constituency { get; set; }
        public int user_id { get; set; }
        public string signature_name { get; set; }
        public int signature_size { get; set; }
        public byte[] signature_data { get; set; }
        public string signature_contenttype { get; set; }
        public string photo_name { get; set; }
        public int photo_size { get; set; }
        public byte[] photo_data { get; set; }
        public string photo_contenttype { get; set; }

    }
}