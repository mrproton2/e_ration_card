using e_ration_card.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace e_ration_card.Services
{
    public class clsDistribution
    {
        public string InsertDistributionDetails(distribution_details objdistribution_Details)
        {

            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("usp_insert_distributiondetails"))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;                           
                            cmd.Parameters.AddWithValue("@kotedar_id", objdistribution_Details.kotedar_id);
                            cmd.Parameters.AddWithValue("@kotedar_name", objdistribution_Details.kotedar_name);
                            cmd.Parameters.AddWithValue("@Area", objdistribution_Details.Area);
                            cmd.Parameters.AddWithValue("@rationcard_no", objdistribution_Details.rationcard_no);
                            cmd.Parameters.AddWithValue("@cardholdernme", objdistribution_Details.cardholdernme);
                            cmd.Parameters.AddWithValue("@Active_mbr", objdistribution_Details.Active_mbr);
                            cmd.Parameters.AddWithValue("@Authenticated_mbr", objdistribution_Details.Authenticated_mbr);
                            cmd.Parameters.AddWithValue("@total_weight","50KG");
                            cmd.Parameters.AddWithValue("@total_price", objdistribution_Details.total_price);
                            cmd.Parameters.AddWithValue("@date_time", objdistribution_Details.date_time);
                            cmd.Parameters.AddWithValue("@general_id", objdistribution_Details.general_id);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();


                        }

                    }
                    return ("<script>alert('Data Uploaded Successfully');</script>");
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Only alert Message'
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        }
    }
}