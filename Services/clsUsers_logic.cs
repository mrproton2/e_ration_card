using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using e_ration_card.Services;
using static e_ration_card.Services.clsSpold;
using e_ration_card.Models;
using System.Configuration;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_ration_card.Services
{
    public class clsUsers_logic
    {

        public int UserSignUp(users objusers)
        {

            {
                try
                {
                    int intRecCount = 0;
                    string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("usp_insert_users"))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@name", objusers.name);
                            cmd.Parameters.AddWithValue("@username", objusers.user_name);
                            cmd.Parameters.AddWithValue("@password", objusers.user_password);
                            cmd.Parameters.AddWithValue("@usertype", objusers.user_type);
                            cmd.Parameters.AddWithValue("@email", objusers.email);
                            cmd.Parameters.AddWithValue("@mobile", objusers.mobile_no);
                            //cmd.Parameters.AddWithValue("@creatredate", "");
                            //cmd.Parameters.AddWithValue("@createdby", "");
                            cmd.Parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int));
                            cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;

                            

                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                             intRecCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                            
                            con.Close();

                            return intRecCount;
                        }

                    }
                   
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