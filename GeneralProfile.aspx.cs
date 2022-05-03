using e_ration_card.Models;
using e_ration_card.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace e_ration_card
{
    public partial class GeneralProfile : System.Web.UI.Page
    {
        general_registration objgeneral_registration = new general_registration();

        clsGeneral_Logic objclsGeneral_Logic = new clsGeneral_Logic();
        kotedar_registration objkotedar_registration = new kotedar_registration();
        clsDbConnector objclsDbConnector = new clsDbConnector();
        clsKotedarUpdation_logic objclsKotedarUpdation_Logic = new clsKotedarUpdation_logic();
        //public static GeneralProfile objGeneralProfile = new GeneralProfile();

        protected void Page_Load(object sender, EventArgs e)
        {
            clsDbConnector objclsDbConnector = new clsDbConnector();
            string strSQ = "SELECT state_id,state_name from tbl_state";
            DataSet ds = new DataSet();
            ds=objclsDbConnector.GetDataSet(strSQ);

           
            string strSQ1 = "SELECT consitiuency_name from tbl_consitiuency";
            DataSet ds1 = new DataSet();
            ds1 = objclsDbConnector.GetDataSet(strSQ1);


            if (Session["user_id"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {

            }

            if (!IsPostBack)
            {
             
                ddlstate.DataSource = ds.Tables[0];
                ddlstate.DataBind();
                ddlstate.Items.Insert(0, "**SELECT**");
                ddldistrict.Items.Insert(0, "**SELECT**");
                ddlconstituency.DataSource = ds1.Tables[0];
                ddlconstituency.DataBind();
                ddlconstituency.Items.Insert(0, "**SELECT**");      
                //CheckData();

            }

            Label lblhname = this.Master.FindControl("lblhname") as Label;
            lblhname.Text = Session["cardholdername"].ToString();
            Label lblconstiuency = this.Master.FindControl("lblconstiuency") as Label;
            lblconstiuency.Text = Session["constituency"].ToString();

        }

        protected void btnsubmit_Click(object sender, EventArgs e)

        {
            if (Session["user_id"] != null)
            {
                string user_id1 = Session["user_id"].ToString();
                objgeneral_registration.user_id = Convert.ToInt32(user_id1);
            }

            objgeneral_registration.card_holdername = txtcardholdername.Value;
            objgeneral_registration.rationcard_no = Convert.ToInt32(txtrationcardno.Value);          
            objgeneral_registration.aadharcard_no = (txtaadharcardno.Value);
            objgeneral_registration.pancard_no = txtpanno.Value;
            objgeneral_registration.card_holdername = txtcardholdername.Value;
            objgeneral_registration.annual_income = Convert.ToInt32(txtannualincome.Value);
            objgeneral_registration.states = ddlstate.SelectedValue;
            objgeneral_registration.district = ddldistrict.SelectedValue;
            objgeneral_registration.addresss = txtaddress.Value;
            objgeneral_registration.constituency = ddlconstituency.SelectedValue;
            objgeneral_registration.typeof_rationcard = txttypeofrationcard.Value;


            objclsGeneral_Logic.InsertGeneral(objgeneral_registration);

            Response.Write("<script>alert('General Detail Updated Successfull');</script>");

        }

        public void Validation()
        {
            Response.Write("<script>alert('Please Fill All Fields');</script>");
        }

        public void InitializeField()
        {
            txtaadharcardno.Value = "";
            txtaddress.Value = "";
            txtannualincome.Value = "";
            txtcardholdername.Value = "";
            txtemail.Value = "";
            txtmobileno.Value = "";
            txtpincode.Value = "";
            txtpanno.Value = "";
            txtpincode.Value = "";
            txtrationcardno.Value = "";
            txttypeofrationcard.Value = "";
            ddlstate.SelectedIndex = 0;
            ddldistrict.SelectedIndex = 0;
            ddlconstituency.SelectedIndex = 0;


        }

        public void CheckData()
        {

            string userid = Session["user_id"].ToString();
            string strSQL;
            strSQL = "SELECT * from tbl_general_registration where user_id='" + userid + "'";
            DataSet dsTemp = objclsDbConnector.GetDataSet(strSQL);
            DataTable dtTemp = dsTemp.Tables[0];
            if (dtTemp.Rows.Count > 0)
            {
                btnsubmit.Visible = false;
                btnupdate.Visible = true;
                txtrationcardno.Value = dtTemp.Rows[0]["rationcard_no"].ToString();
                txtaddress.Value = dtTemp.Rows[0]["addresss"].ToString();
                txtaadharcardno.Value = dtTemp.Rows[0]["aadharcard_no"].ToString();
                txtpanno.Value = dtTemp.Rows[0]["pancard_no"].ToString();
                txtpincode.Value = dtTemp.Rows[0]["pincode_no"].ToString();
                ddlstate.SelectedItem.Text = dtTemp.Rows[0]["states"].ToString();
                ddldistrict.SelectedItem.Text = dtTemp.Rows[0]["district"].ToString();
                ddlconstituency.SelectedItem.Text = dtTemp.Rows[0]["constituency"].ToString();
                txttypeofrationcard.Value = dtTemp.Rows[0]["typeof_rationcard"].ToString();
            }
            else
            {
                btnsubmit.Visible = true;
                btnupdate.Visible = false;

            }
            string strSQLU;
            strSQLU = "SELECT * from users where user_id='" + userid + "'";
            DataSet dsTempU = objclsDbConnector.GetDataSet(strSQLU);
            DataTable dtTempU = dsTempU.Tables[0];
            if (dtTempU.Rows.Count > 0)
            {
                btnsubmit.Visible = false;
                btnupdate.Visible = true;
                txtcardholdername.Value = dtTempU.Rows[0]["name"].ToString();
                txtmobileno.Value = dtTempU.Rows[0]["mobile"].ToString();
                txtemail.Value = dtTempU.Rows[0]["email"].ToString();
            }
            else
            {
                btnsubmit.Visible = true;
                btnupdate.Visible = false;

            }
        }

 

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {

            clsDbConnector objclsDbConnector = new clsDbConnector();
            string strSQ = "SELECT district_name from tbl_district where state_id='" + ddlstate.SelectedValue.Trim() + "'";
            DataSet ds = new DataSet();
            ds = objclsDbConnector.GetDataSet(strSQ);
            ddldistrict.DataSource = ds.Tables[0];
            ddldistrict.DataBind();
           
        }


        public static string Constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        [WebMethod]
        public static string SaveData(string empdata)//WebMethod to Save the data  
        {
            var serializeData = JsonConvert.DeserializeObject<List<MemberList>>(empdata);
            if (serializeData==null)
            {
                //objGeneralProfile.Validation();
            }
                
            else
            {
                using (var con = new SqlConnection(Constr))
                {
                    foreach (var data in serializeData)
                    {
                        using (var cmd = new SqlCommand("INSERT INTO tbl_member_list([mbr_name],[relation],[age],[creatredate],[createdby],[general_id],[Status],[user_id],[aadharno],[dob]) VALUES(@mbr_name, @relation, @age, @creatredate, @createdby, @general_id, @Status, @user_id, @aadharno, @dob);"))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@mbr_name", data.Name);
                            cmd.Parameters.AddWithValue("@relation", data.relation);
                            cmd.Parameters.AddWithValue("@age", data.age);
                            cmd.Parameters.AddWithValue("@creatredate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@createdby", data.Name);
                            cmd.Parameters.AddWithValue("@general_id", 1);
                            cmd.Parameters.AddWithValue("@Status", "Active");
                            cmd.Parameters.AddWithValue("@user_id", '1');
                            cmd.Parameters.AddWithValue("@aadharno", data.aadharno);
                            cmd.Parameters.AddWithValue("@dob", data.dob);
                            cmd.Connection = con;
                            if (con.State == ConnectionState.Closed)
                            {
                                con.Open();
                            }
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
               
            }
            return null;
        }

        [WebMethod]
        public void CleareData()//WebMethod to Clear the data  
        {
            Response.Redirect("GeneralProfile.aspx");
            //Server.Transfer("UserDetail.aspx");
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["user_id"] != null)
                {
                    string user_id = Session["user_id"].ToString();
                    objgeneral_registration.user_id = Convert.ToInt32(user_id);
                }

                objgeneral_registration.rationcard_no = Convert.ToInt32(txtrationcardno.Value);
                objgeneral_registration.addresss = txtaddress.Value;
                objgeneral_registration.aadharcard_no = txtaadharcardno.Value;
                objgeneral_registration.pancard_no = txtpanno.Value;
                objgeneral_registration.pincode_no = Convert.ToInt32(txtpincode.Value);
                objgeneral_registration.states = ddlstate.SelectedValue;
                objgeneral_registration.district = ddldistrict.SelectedValue;
                objgeneral_registration.constituency = ddlconstituency.SelectedValue;
                objgeneral_registration.typeof_rationcard = txttypeofrationcard.Value;


                objclsGeneral_Logic.UpdatedGeneral(objgeneral_registration);


                InitializeField();
                CheckData();
                Response.Write("<script>alert('General Detail Updated Successfull');</script>");





            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error Occure Contact Admin');</script>");
                Response.Write(ex.Message);
            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            txtaadharcardno.Value = "";
        }
    }
}