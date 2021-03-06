using e_ration_card.Models;
using e_ration_card.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;

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
            string strSQ = "SELECT state_name,state_id from tbl_state";
            DataSet ds = new DataSet();
            ds=objclsDbConnector.GetDataSet(strSQ);

           
            string strSQ1 = "SELECT consitiuency_name from tbl_consitiuency";
            DataSet ds1 = new DataSet();
            ds1 = objclsDbConnector.GetDataSet(strSQ1);

            
            string strSQ2 = "Select annual_income,typeof_rationcard from tbl_annual_income";
            DataTable ds2 = new DataTable();
            ds2 = objclsDbConnector.GetData(strSQ2);

            txtuserid.Text = Session["user_id"].ToString();
            string userid1 = txtuserid.Text;

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
                ddlannualincome.DataSource = ds2;
                ddlannualincome.DataBind();
                ddlannualincome.Items.Insert(0, "SELECT");
                CheckData();


            }
            if (Session["name"] != null)
            {
                Label lblhname = this.Master.FindControl("lblhname") as Label;
                lblhname.Text = Session["name"].ToString();
            }
                if (Session["constituency"] != null)
                {
                    Label lblconstiuency = this.Master.FindControl("lblconstiuency") as Label;
                    lblconstiuency.Text = Session["constituency"].ToString();
                }
            
        }

        protected void btnsubmit_Click(object sender, EventArgs e)

        {
            if (Session["user_id"] != null)
            {
                string user_id1 = Session["user_id"].ToString();
                objgeneral_registration.user_id = Convert.ToInt32(user_id1);
            }
            if (string.IsNullOrEmpty(txtaadharcardno.Value) || ddlannualincome.SelectedItem.Text == "**SELECT**" || string.IsNullOrEmpty(txtpincode.Value) || string.IsNullOrEmpty(txtrationcardno.Value) || string.IsNullOrEmpty(txttypeofrationcard.Value) || (ddlstate.SelectedItem.Text == "SELECT") || ddldistrict.SelectedItem.Text == "SELECT" || ddlconstituency.SelectedItem.Text == "SELECT")
            {
                ValidateForm();
            }
            else {
                objgeneral_registration.card_holdername = txtcardholdername.Value;
                objgeneral_registration.rationcard_no = Convert.ToInt32(txtrationcardno.Value);
                objgeneral_registration.aadharcard_no = (txtaadharcardno.Value);
                objgeneral_registration.pancard_no = txtpanno.Value;
                objgeneral_registration.card_holdername = txtcardholdername.Value;
                objgeneral_registration.annual_income =ddlannualincome.SelectedItem.Text;
                objgeneral_registration.states = ddlstate.SelectedItem.Text;
                objgeneral_registration.district = ddldistrict.SelectedValue;
                objgeneral_registration.addresss = txtaddress.Value;
                objgeneral_registration.constituency = ddlconstituency.SelectedValue;
                objgeneral_registration.typeof_rationcard = txttypeofrationcard.Value;


                objclsGeneral_Logic.InsertGeneral(objgeneral_registration);

                Response.Write("<script>alert('General Detail Updated Successfull');</script>");
            }
        }

        public void Validation()
        {
            Response.Write("<script>alert('Please Fill All Fields');</script>");
        }

        public void InitializeField()
        {
            txtaadharcardno.Value = "";
            txtaddress.Value = "";
            ddlannualincome.SelectedIndex = 0;
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
                ddlannualincome.SelectedItem.Text = dtTemp.Rows[0]["annual_income"].ToString();
                Session["general_id"]= dtTemp.Rows[0]["general_id"].ToString();
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
                //btnsubmit.Visible = false;
                //btnupdate.Visible = true;
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
            string userid1 = (string)HttpContext.Current.Session["user_id"];

            string generalid1 = (string)HttpContext.Current.Session["general_id"];


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
                        using (var cmd = new SqlCommand("INSERT INTO tbl_member_list([mbr_name],[relation],[age],[creatredate],[createdby],[general_id],[Status],[user_id],[aadharno],[dob]) VALUES(@mbr_name, @relation, @age, @creatredate, @createdby, @general_id, @Status,@user_id, @aadharno, @dob);"))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@mbr_name", data.Name);
                            cmd.Parameters.AddWithValue("@relation", data.relation);
                            cmd.Parameters.AddWithValue("@age", data.age);
                            cmd.Parameters.AddWithValue("@creatredate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@createdby", data.Name);
                            cmd.Parameters.AddWithValue("@general_id",generalid1);
                            cmd.Parameters.AddWithValue("@Status", "Active");
                            cmd.Parameters.AddWithValue("@user_id",userid1);
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
                if (string.IsNullOrEmpty(txtaadharcardno.Value) || string.IsNullOrEmpty(txtrationcardno.Value) || ddlannualincome.SelectedValue == "SELECT" || string.IsNullOrEmpty(txtpincode.Value) || string.IsNullOrEmpty(txttypeofrationcard.Value) || (ddlstate.SelectedItem.Text == "SELECT") || ddldistrict.SelectedItem.Text == "SELECT" || ddlconstituency.SelectedItem.Text == "SELECT")
                {
                    ValidateForm();
                }
                else
                {
                    objgeneral_registration.rationcard_no = Convert.ToInt32(txtrationcardno.Value);
                    objgeneral_registration.addresss = txtaddress.Value;
                    objgeneral_registration.aadharcard_no = txtaadharcardno.Value;
                    objgeneral_registration.pancard_no = txtpanno.Value;
                    objgeneral_registration.pincode_no = Convert.ToInt32(txtpincode.Value);
                    objgeneral_registration.states = ddlstate.SelectedItem.Text;
                    objgeneral_registration.district = ddldistrict.SelectedValue;
                    objgeneral_registration.constituency = ddlconstituency.SelectedValue;
                    objgeneral_registration.typeof_rationcard = txttypeofrationcard.Value;
                    objgeneral_registration.annual_income = ddlannualincome.SelectedItem.Text;


                    objclsGeneral_Logic.UpdatedGeneral(objgeneral_registration);


                    //InitializeField();
                    //CheckData();
                    Response.Write("<script>alert('General Detail Updated Successfull');</script>");


                }


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
        
        public void ValidateForm()
        {
            if (string.IsNullOrEmpty(txtrationcardno.Value))
            {
                Response.Write("<script>alert('Please Enter RationCardNo..');</script>");
                return;
            }
            if (string.IsNullOrEmpty(txtaadharcardno.Value))
            {
                Response.Write("<script>alert('Please Enter Aadhar Card No..');</script>");
                return;
            }
            if (string.IsNullOrEmpty(txtpanno.Value))
            {
                Response.Write("<script>alert('Please Enter Panno..');</script>");
                return;
            }
            if (string.IsNullOrEmpty(txtaddress.Value))
            {
                Response.Write("<script>alert('Please Enter Address..');</script>");
                return;
            }
            if (string.IsNullOrEmpty(txtpincode.Value))
            {
                Response.Write("<script>alert('Please Enter Pincode..');</script>");
                return;
            }
            if (ddlannualincome.SelectedValue == "SELECT")
            {
                Response.Write("<script>alert('Please Select Anual Income..');</script>");
                return;
            }                                            
           
            if (ddlstate.SelectedItem.Text == "SELECT")
            {
                Response.Write("<script>alert('Please Select State..');</script>");
                return;
            }
            if (ddldistrict.SelectedItem.Text == "SELECT")
            {
                Response.Write("<script>alert('Please Select District..');</script>");
                return;
            }
            if (ddlconstituency.SelectedItem.Text == "SELECT")
            {
                Response.Write("<script>alert('Please Select Constituency..');</script>");
                return;
            }
            if (string.IsNullOrEmpty(txttypeofrationcard.Value))
            {
                Response.Write("<script>alert('Please Enter Type Of RationCard..');</script>");
                return;
            }

        }

        protected void ddlannualincome_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlannualincome.SelectedValue == "SELECT")
            {
                Response.Write("<script>alert('Please Select Annual Income..');</script>");
            }
            else
            {
                txttypeofrationcard.Value = ddlannualincome.SelectedValue;
            }
        }
    }
}