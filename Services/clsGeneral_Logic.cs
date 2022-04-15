using e_ration_card.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace e_ration_card.Services
{
    public class clsGeneral_Logic
    {
        general_registration objgeneral_registration = new general_registration();
        public string InsertGeneral(general_registration objgeneral_registration)
        {

            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("usp_insert_generaldetails"))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@user_id", objgeneral_registration.user_id);
                            cmd.Parameters.AddWithValue("@card_holdername", objgeneral_registration.card_holdername);
                            cmd.Parameters.AddWithValue("@rationcard_no", objgeneral_registration.rationcard_no);
                            cmd.Parameters.AddWithValue("@aadharcard_no", objgeneral_registration.aadharcard_no);
                            cmd.Parameters.AddWithValue("@pancard_no", objgeneral_registration.pancard_no);
                            cmd.Parameters.AddWithValue("@addresss", objgeneral_registration.addresss);
                            cmd.Parameters.AddWithValue("@pincode_no", objgeneral_registration.pincode_no);
                            cmd.Parameters.AddWithValue("@annual_income", objgeneral_registration.annual_income);
                            cmd.Parameters.AddWithValue("@typeof_rationcard", objgeneral_registration.typeof_rationcard);
                            cmd.Parameters.AddWithValue("@states", objgeneral_registration.states);
                            cmd.Parameters.AddWithValue("@district", objgeneral_registration.district);
                            cmd.Parameters.AddWithValue("@constituency", objgeneral_registration.constituency);
                            cmd.Parameters.AddWithValue("@creatredate", "");
                            cmd.Parameters.AddWithValue("@createdby", "");
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

        public string UpdatedGeneral(general_registration objgeneral_registration)
        {

            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("usp_update_generaldetails"))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@user_id", objgeneral_registration.user_id);                           
                            cmd.Parameters.AddWithValue("@rationcard_no", objgeneral_registration.rationcard_no);
                            cmd.Parameters.AddWithValue("@aadharcard_no", objgeneral_registration.aadharcard_no);
                            cmd.Parameters.AddWithValue("@pancard_no", objgeneral_registration.pancard_no);
                            cmd.Parameters.AddWithValue("@addresss", objgeneral_registration.addresss);
                            cmd.Parameters.AddWithValue("@pincode_no", objgeneral_registration.pincode_no);
                            cmd.Parameters.AddWithValue("@annual_income", objgeneral_registration.annual_income);
                            cmd.Parameters.AddWithValue("@typeof_rationcard", objgeneral_registration.typeof_rationcard);
                            cmd.Parameters.AddWithValue("@states", objgeneral_registration.states);
                            cmd.Parameters.AddWithValue("@district", objgeneral_registration.district);
                            cmd.Parameters.AddWithValue("@constituency", objgeneral_registration.constituency);
                            cmd.Parameters.AddWithValue("@creatredate", "");
                            cmd.Parameters.AddWithValue("@createdby", "");
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();


                        }

                    }
                    return ("<script>alert('Data Updated Successfully');</script>");
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