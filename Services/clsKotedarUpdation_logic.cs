using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using e_ration_card.Services;
using static e_ration_card.Services.clsSpold;
using e_ration_card.Models;


namespace e_ration_card.Services
{

    public class clsKotedarUpdation_logic
    {
        kotedar_registration objkotedar_registration = new kotedar_registration();
        public string InsertKotedar(kotedar_registration objkotedar_registration)
        {

            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("usp_insert_kotedardetails"))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@kotedar_no", objkotedar_registration.kotedar_no);
                            cmd.Parameters.AddWithValue("@user_id", objkotedar_registration.user_id);
                            cmd.Parameters.AddWithValue("@aadhar_no", objkotedar_registration.aadhar_no);
                            cmd.Parameters.AddWithValue("@pan_no", objkotedar_registration.pan_no);
                            cmd.Parameters.AddWithValue("@addresss", objkotedar_registration.addresss);
                            cmd.Parameters.AddWithValue("@pincode_no", objkotedar_registration.pincode_no);
                            cmd.Parameters.AddWithValue("@states", objkotedar_registration.states);
                            cmd.Parameters.AddWithValue("@district", objkotedar_registration.district);
                            cmd.Parameters.AddWithValue("@constituency", objkotedar_registration.Constituency);
                            cmd.Parameters.AddWithValue("@photo_contenttype", objkotedar_registration.photo_contenttype);
                            cmd.Parameters.AddWithValue("@photo_name", objkotedar_registration.photo_name);
                            cmd.Parameters.AddWithValue("@photo_size", objkotedar_registration.photo_size);
                            cmd.Parameters.AddWithValue("@photo_data", objkotedar_registration.photo_data);
                            cmd.Parameters.AddWithValue("@signature_contenttype", objkotedar_registration.signature_contenttype);
                            cmd.Parameters.AddWithValue("@signature_name", objkotedar_registration.signature_name);
                            cmd.Parameters.AddWithValue("@signature_size", objkotedar_registration.signature_size);
                            cmd.Parameters.AddWithValue("@signature_data", objkotedar_registration.signature_data);
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

        public string UpdateKotedar(kotedar_registration objkotedar_registration)
        {

            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("usp_update_kotedardetails"))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@kotedar_no", objkotedar_registration.kotedar_no);
                            cmd.Parameters.AddWithValue("@user_id", objkotedar_registration.user_id);
                            cmd.Parameters.AddWithValue("@aadhar_no", objkotedar_registration.aadhar_no);
                            cmd.Parameters.AddWithValue("@pan_no", objkotedar_registration.pan_no);
                            cmd.Parameters.AddWithValue("@addresss", objkotedar_registration.addresss);
                            cmd.Parameters.AddWithValue("@pincode_no", objkotedar_registration.pincode_no);
                            cmd.Parameters.AddWithValue("@states", objkotedar_registration.states);
                            cmd.Parameters.AddWithValue("@district", objkotedar_registration.district);
                            cmd.Parameters.AddWithValue("@constituency", objkotedar_registration.Constituency);
                            cmd.Parameters.AddWithValue("@photo_contenttype", objkotedar_registration.photo_contenttype);
                            cmd.Parameters.AddWithValue("@photo_name", objkotedar_registration.photo_name);
                            cmd.Parameters.AddWithValue("@photo_size", objkotedar_registration.photo_size);
                            cmd.Parameters.AddWithValue("@photo_data", objkotedar_registration.photo_data);
                            cmd.Parameters.AddWithValue("@signature_contenttype", objkotedar_registration.signature_contenttype);
                            cmd.Parameters.AddWithValue("@signature_name", objkotedar_registration.signature_name);
                            cmd.Parameters.AddWithValue("@signature_size", objkotedar_registration.signature_size);
                            cmd.Parameters.AddWithValue("@signature_data", objkotedar_registration.signature_data);
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