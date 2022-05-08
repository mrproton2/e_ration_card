using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using e_ration_card.Models;

namespace e_ration_card.Services
{
    public class clsRationCardUpdation
    {
        changename objchangename = new changename();
        clschangeaddress objclschangeaddress = new clschangeaddress();
        clsmembercorrection objclsmembercorrection = new clsmembercorrection();
        clsaddmember objclsaddmember = new clsaddmember();
        clsremovembr objclsremovembr = new clsremovembr();
        public string ChangeName(changename objchangename)
        {

            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("usp_insert_changename"))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@OldName", objchangename.old_name);
                            cmd.Parameters.AddWithValue("@NewName", objchangename.new_name);
                            cmd.Parameters.AddWithValue("@cn_doc1_name", objchangename.cn_doc1_name);
                            cmd.Parameters.AddWithValue("@cn_doc2_name","test");
                            cmd.Parameters.AddWithValue("@user_id",3);
                            cmd.Parameters.AddWithValue("@cn_doc1_size", objchangename.cn_doc1_size);
                            cmd.Parameters.AddWithValue("@cn_doc2_size",3254);
                            cmd.Parameters.AddWithValue("@cn_doc1_data", objchangename.cn_doc1_data);
                            cmd.Parameters.AddWithValue("@cn_doc2_data", 650); 
                            cmd.Parameters.AddWithValue("@contcontenttype", objchangename.contcontenttype);
                            cmd.Parameters.AddWithValue("@Authorize","Pending");
                            //cmd.Parameters.AddWithValue("@creatredate", "");
                            //cmd.Parameters.AddWithValue("@createdby", "");
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

        public string ChangeAddress(clschangeaddress objclschangeaddress)
        {

            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("usp_insert_changeaddress"))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Oldaddress", objclschangeaddress.old_address);
                            cmd.Parameters.AddWithValue("@Newaddress", objclschangeaddress.new_address);
                            cmd.Parameters.AddWithValue("@ac_doc1_name", objclschangeaddress.ac_doc1_name );
                            cmd.Parameters.AddWithValue("@ac_doc2_name", "text");
                            cmd.Parameters.AddWithValue("@user_id", objclschangeaddress.user_id);
                            cmd.Parameters.AddWithValue("@ac_doc1_size", objclschangeaddress.ac_doc1_size);
                            cmd.Parameters.AddWithValue("@ac_doc2_size", 3254);
                            cmd.Parameters.AddWithValue("@ac_doc1_data", objclschangeaddress.ac_doc1_data);
                            cmd.Parameters.AddWithValue("@ac_doc2_data", 650);
                            cmd.Parameters.AddWithValue("@contcontenttype", objclschangeaddress.contcontenttype);
                            cmd.Parameters.AddWithValue("@Authorize", "Pending");
                            //cmd.Parameters.AddWithValue("@creatredate", "");
                            //cmd.Parameters.AddWithValue("@createdby", "");
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

        public string ChangeMbrName(clsmembercorrection objclsmembercorrection)
        {

            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("usp_insert_mbrnamecorrection"))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Oldmbrname", objclsmembercorrection.old_mbrname);
                            cmd.Parameters.AddWithValue("@Newambrname", objclsmembercorrection.new_mbrname);
                            cmd.Parameters.AddWithValue("@mbr_doc1_name", objclsmembercorrection.mbr_doc1_name);
                            cmd.Parameters.AddWithValue("@mbr_doc2_name", "text");
                            cmd.Parameters.AddWithValue("@user_id", objclsmembercorrection.user_id);
                            cmd.Parameters.AddWithValue("@mbr_doc1_size", objclsmembercorrection.mbr_doc1_size);
                            cmd.Parameters.AddWithValue("@mbr_doc2_size", 3254);
                            cmd.Parameters.AddWithValue("@mbr_doc1_data",objclsmembercorrection.mbr_doc1_data);
                            cmd.Parameters.AddWithValue("@mbr_doc2_data", 650);
                            cmd.Parameters.AddWithValue("@contcontenttype", objclsmembercorrection.contcontenttype);
                            cmd.Parameters.AddWithValue("@Authorize", "Pending");
                            //cmd.Parameters.AddWithValue("@creatredate", "");
                            //cmd.Parameters.AddWithValue("@createdby", "");
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

        public string AddMember(clsaddmember objclsaddmember)
        {

            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("usp_insert_newmember"))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Mbrname", objclsaddmember.new_membername);
                            cmd.Parameters.AddWithValue("@Relation", objclsaddmember.relation);
                            cmd.Parameters.AddWithValue("@addmbr_doc1_name", objclsaddmember.addmbr_doc1_name);
                            cmd.Parameters.AddWithValue("@addmbr_doc2_name", "text");
                            cmd.Parameters.AddWithValue("@user_id", objclsaddmember.user_id);
                            cmd.Parameters.AddWithValue("@addmbr_doc1_size", objclsaddmember.addmbr_doc1_size);
                            cmd.Parameters.AddWithValue("@addmbr_doc2_size", 3254);
                            cmd.Parameters.AddWithValue("@addmbr_doc1_data", objclsaddmember.addmbr_doc1_data);
                            cmd.Parameters.AddWithValue("@addmbr_doc2_data", 650);
                            cmd.Parameters.AddWithValue("@contcontenttype", objclsaddmember.contcontenttype);
                            cmd.Parameters.AddWithValue("@Authorize", "Pending");
                            //cmd.Parameters.AddWithValue("@creatredate", "");
                            //cmd.Parameters.AddWithValue("@createdby", "");
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

        public string RemoveMember(clsremovembr objclsremovembr)
        {

            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("usp_insert_removemember"))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Mbrname", objclsremovembr.new_membername);
                            cmd.Parameters.AddWithValue("@Relation", objclsremovembr.relation);
                            cmd.Parameters.AddWithValue("@removembr_doc1_name", objclsremovembr.removembr_doc1_name);
                            cmd.Parameters.AddWithValue("@removembr_doc2_name", "text");
                            cmd.Parameters.AddWithValue("@user_id", objclsremovembr.user_id);
                            cmd.Parameters.AddWithValue("@removembr_doc1_size", objclsremovembr.removembr_doc1_size);
                            cmd.Parameters.AddWithValue("@removembr_doc2_size", 3254);
                            cmd.Parameters.AddWithValue("@removembr_doc1_data", objclsremovembr.removembr_doc1_data);
                            cmd.Parameters.AddWithValue("@removembr_doc2_data", 650);
                            cmd.Parameters.AddWithValue("@contcontenttype", objclsremovembr.contcontenttype);
                            cmd.Parameters.AddWithValue("@Authorize", "Pending");
                            //cmd.Parameters.AddWithValue("@creatredate", "");
                            //cmd.Parameters.AddWithValue("@createdby", "");
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