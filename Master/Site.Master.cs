using e_ration_card.Models;
using e_ration_card.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;

namespace e_ration_card.Master
{
    public partial class Site : System.Web.UI.MasterPage
    {
        clsuserlogin_logic objclsuserlogin_logic = new clsuserlogin_logic();
        users objusers = new users();
        clsDbConnector objclsDbConnector = new clsDbConnector();
        clsUsers_logic objclsUsers_logic = new clsUsers_logic();
        protected void Page_Load(object sender, EventArgs e)
        {

            //btnlogin.Attributes.Add("onclick", "if(Validation()==false){return false;}");
            //string name = IdText.Value;
            //txtUserName.Focus();

            //if (!Page.IsPostBack)
            //{

            //}

            //txtPassword.Attributes.Add("value", txtPassword.Text);

            if (!IsPostBack)
            {
                SessionIDManager Manager = new SessionIDManager();
                string NewID = Manager.CreateSessionID(Context);
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", NewID));
            }

            HttpSessionState ssObj = HttpContext.Current.Session;

            objclsDbConnector.SetValueType(clsDbConnector.TextType.RemarksFixedLength,txtname, 10);

            DisplayError();


        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {

            objusers.user_name = uname.Value.Trim();
            objusers.user_password = pwd.Value.Trim();
            DataSet dsTemp = objclsuserlogin_logic.CheckLogin(objusers.user_name, objusers.user_password);
            DataTable dtTemp = dsTemp.Tables[0];
           
            
            //string userid = Session["user_id"].ToString();
            //string strSQL;
            //strSQL = "Select Count(1) from tbl_kotedar_registration where user_id ='" + userid + "'";
            //DataSet ds = objclsDbConnector.GetDataSet(strSQL);
            //DataTable dt = ds.Tables[0];
            if (dtTemp.Rows.Count > 0)

                if (uname.Value.Trim() == "" || pwd.Value.Trim() == "")
               {
                //Response.Write("<script>alert('Please Enter UserName or Password');</script>");

                if (uname.Value.Trim() == "" && pwd.Value.Trim() == "")
                {

                    Response.Write("<script>alert('Please Enter UserName & Password');</script>");
                }
                else if(uname.Value.Trim() == "")
                {
                    Response.Write("<script>alert('Please Enter UserName');</script>");
                }
                else if (pwd.Value.Trim() == "")
                {

                    Response.Write("<script>alert('Please Enter Password');</script>");
                }
                

            }

            else if (dtTemp.Rows.Count > 0)
            {
                string usertype = dtTemp.Rows[0]["user_type"].ToString();

                if (dtTemp.Rows.Count > 0 && usertype == "GOVT")
                {
                    Session["username"] = dtTemp.Rows[0]["user_name"].ToString();
                    Session["user_id"] = dtTemp.Rows[0]["user_id"].ToString();
                    Session["name"]= dtTemp.Rows[0]["name"].ToString();
                    if (Session["username"].ToString()!= null && Session["user_id"].ToString() !=null)
                    {
                        Response.Redirect("GovtDashboard.aspx");
                    }
                    else
                    {
                        Response.Redirect("index.aspx");
                    }
                }
                else if (dtTemp.Rows.Count > 0 && usertype == "GENERAL")
                {
                    string un= dtTemp.Rows[0]["user_name"].ToString();

                    Session["username"] = dtTemp.Rows[0]["user_name"].ToString();
                    Session["user_id"] = dtTemp.Rows[0]["user_id"].ToString();
                    Session["name"] = dtTemp.Rows[0]["name"].ToString();

                        clsuserlogin_logic objclsuserlogin_logic = new clsuserlogin_logic();
                        users objusers = new users();
                        clsDbConnector objclsDbConnector = new clsDbConnector();
                        clsUsers_logic objclsUsers_logic = new clsUsers_logic();
                        string userid = Session["user_id"].ToString();
                        string strSQL;
                        strSQL = "Select * from tbl_general_registration where user_id ='" + userid + "'";
                        DataSet ds = objclsDbConnector.GetDataSet(strSQL);
                        DataTable dt = ds.Tables[0];
                        if (Session["user_id"] == null)
                        {
                            Session["cardholdername"] = dt.Rows[0]["card_holder_name"].ToString();
                            Session["constituency"] = dt.Rows[0]["constituency"].ToString();
                        }


                        if (Session["username"].ToString() != null && Session["user_id"].ToString() != null)
                    {
                        Response.Redirect("GeneralScreen.aspx");
                    }
                    else
                    {
                        Response.Redirect("index.aspx");
                    }
                }
                else if (dtTemp.Rows.Count > 0 && usertype == "DISTRIBUTOR")
                {
                    Session["username"] = dtTemp.Rows[0]["user_name"].ToString();
                    Session["user_id"] = dtTemp.Rows[0]["user_id"].ToString();
                    Session["name"] = dtTemp.Rows[0]["name"].ToString();

                        clsuserlogin_logic objclsuserlogin_logic = new clsuserlogin_logic();
                        users objusers = new users();
                        clsDbConnector objclsDbConnector = new clsDbConnector();
                        clsUsers_logic objclsUsers_logic = new clsUsers_logic();
                        string userid = Session["user_id"].ToString();
                        string strSQL;
                        strSQL = "Select * from tbl_kotedar_registration where user_id ='" + userid + "'";
                        DataSet ds = objclsDbConnector.GetDataSet(strSQL);
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            if (Session["user_id"] == null)
                            {
                                Session["kotedarid"] = dt.Rows[0]["kotedar_no"].ToString();
                                Session["constituency"] = dt.Rows[0]["contituency"].ToString();
                            }
                        }

                        if (Session["username"].ToString() != null && Session["user_id"].ToString() != null)
                    {
                            if (dt.Rows.Count > 0)
                            {
                                Response.Redirect("DistributorScreen.aspx");
                            }
                            else
                            {
                                Response.Redirect("DistributorProfile.aspx");
                            }
                        
                    }
                    else
                    {
                        Response.Redirect("index.aspx");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid User Name or Password');</script>");
                uname.Value = "";
                pwd.Value = "";
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Only alert Message');", true);
            }

        }

        protected void btnsignup_Click(object sender, EventArgs e)
        {
            objusers.name = txtname.Value;
            objusers.user_name = txtusername.Value;
            objusers.mobile_no = txtmobile.Value;
            objusers.user_password = txtpassword.Value;
            objusers.user_type = ddlusertype.SelectedValue;
            objusers.email = txtemail.Value;

           int intRecCount= objclsUsers_logic.UserSignUp(objusers);
            if (intRecCount > 0)
            {
                Response.Write("<script>alert('User Registration Successfull...');</script>");
                Initializefieldvalue();
            }
            else
            {
                Response.Write("<script>alert('Error while Signup...');</script>");
                Initializefieldvalue();
            }

        }

        public void Initializefieldvalue()
        {
            txtname.Value = "";
            txtusername.Value = "";
            txtmobile.Value = "";
            txtpassword.Value = "";
            ddlusertype.SelectedIndex = 0;
            txtemail.Value = "";
        }

        public void DisplayError()
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Javascript", "javascript:displayErrorMessage('this test');", true);
        }
    }
}
