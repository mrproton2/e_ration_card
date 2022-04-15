using e_ration_card.Models;
using System;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace e_ration_card.Services
{
    //public class clsregistration_logic
    //{
    //    public void registration(general_registration objgeneral_registration)
    //    {
    //        try
    //        {
    //            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
    //            using (SqlConnection con = new SqlConnection(constr))
    //            {
    //                using (SqlCommand cmd = new SqlCommand("sp_appointmenthistory"))
    //                {
    //                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

    //                    cmd.Parameters.AddWithValue("@date", appointmentHistoryModelOBJ.date);
    //                    cmd.Parameters.AddWithValue("@doctor", appointmentHistoryModelOBJ.doctor);
    //                    cmd.Parameters.AddWithValue("@time", appointmentHistoryModelOBJ.time);
    //                    cmd.Parameters.AddWithValue("@fname", appointmentHistoryModelOBJ.fname);
    //                    cmd.Parameters.AddWithValue("@mname", appointmentHistoryModelOBJ.mname);
    //                    cmd.Parameters.AddWithValue("@lname", appointmentHistoryModelOBJ.lname);
    //                    cmd.Parameters.AddWithValue("@mobile", appointmentHistoryModelOBJ.mobile);
    //                    cmd.Parameters.AddWithValue("@email", appointmentHistoryModelOBJ.email);
    //                    cmd.Parameters.AddWithValue("@address", appointmentHistoryModelOBJ.address);
    //                    cmd.Parameters.AddWithValue("@age", appointmentHistoryModelOBJ.age);
    //                    cmd.Parameters.AddWithValue("@gender", appointmentHistoryModelOBJ.gender);
    //                    cmd.Parameters.AddWithValue("@righteyetest", appointmentHistoryModelOBJ.righteyetest);
    //                    cmd.Parameters.AddWithValue("@lefteyetest", appointmentHistoryModelOBJ.lefteyetest);
    //                    cmd.Parameters.AddWithValue("@botheye", appointmentHistoryModelOBJ.botheye);
    //                    cmd.Parameters.AddWithValue("@sysdisease", appointmentHistoryModelOBJ.sysdisease);
    //                    cmd.Parameters.AddWithValue("@pasteyehistory", appointmentHistoryModelOBJ.pasteyehistory);
    //                    cmd.Parameters.AddWithValue("@familyeyehistory", appointmentHistoryModelOBJ.familyeyehistory);
    //                    cmd.Parameters.AddWithValue("@createddate", DateTime.Now);
    //                    cmd.Parameters.AddWithValue("@modifieddate", DateTime.Now);
    //                    cmd.Parameters.AddWithValue("@isactive", 1);
    //                    cmd.Parameters.AddWithValue("@aptduplicate_id", appointmentHistoryModelOBJ.aptduplicate_id);

    //                    cmd.Connection = con;
    //                    con.Open();
    //                    cmd.ExecuteNonQuery();
    //                    con.Close();


    //                }

    //            }
    //            return "Appintment Confirm";
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }


    //}


}