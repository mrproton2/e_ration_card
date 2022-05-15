using e_ration_card.Models;
using e_ration_card.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace e_ration_card
{
    public partial class DistributorProfile : System.Web.UI.Page
    {
        kotedar_registration objkotedar_registration = new kotedar_registration();
        clsDbConnector objclsDbConnector = new clsDbConnector();
        clsKotedarUpdation_logic objclsKotedarUpdation_Logic = new clsKotedarUpdation_logic();

        protected void Page_Load(object sender, EventArgs e)
        {
            clsDbConnector objclsDbConnector = new clsDbConnector();
            string strSQ = "SELECT state_id,state_name from tbl_state";
            DataSet ds = new DataSet();
            ds = objclsDbConnector.GetDataSet(strSQ);
            if (Session["user_id"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
               
            }


            string strSQ1 = "SELECT consitiuency_name from tbl_consitiuency";
            DataSet ds1 = new DataSet();
            ds1 = objclsDbConnector.GetDataSet(strSQ1);

            if (!IsPostBack)
            {
               

                ddlstate.DataSource = ds.Tables[0];
                ddlstate.DataBind();
                ddlstate.Items.Insert(0, "**SELECT**");
                ddldistrict.Items.Insert(0, "**SELECT**");
                ddlconstituency.DataSource = ds1.Tables[0];
                ddlconstituency.DataBind();
                ddlconstituency.Items.Insert(0, "**SELECT**");
                CheckData();
               

               
            }

            FetchData();
            
 
            //((Distributor)Master).TextBoxOnMasterPage.Text = txtkotedar.Value;
            //Master.TextBoxOnMasterPage.Text = txtkotedar.Value;


        }


        protected void btnsubmit_Click(object sender, EventArgs e)

        {
            try
            {
                if (Session["user_id"] != null)
                {
                    string user_id = Session["user_id"].ToString();
                    objkotedar_registration.user_id = Convert.ToInt32(user_id);
                }
                if (string.IsNullOrEmpty(txtaadharno.Value) || string.IsNullOrEmpty(txtaddress.Value) || string.IsNullOrEmpty(txtemail.Value) || string.IsNullOrEmpty(txtkotedar.Value) || string.IsNullOrEmpty(txtkotedarid.Value) || string.IsNullOrEmpty(txtpincode.Value) || string.IsNullOrEmpty(txtmobile.Value) || string.IsNullOrEmpty(txtpanno.Value) || (ddlstate.SelectedItem.Text == "**SELECT**") || ddldistrict.SelectedItem.Text == "**SELECT**" || ddlconstituency.SelectedItem.Text == "**SELECT**")
                {
                    ValidateForm();
                }
                else
                {
                    objkotedar_registration.kotedar_name = txtkotedar.Value;
                    objkotedar_registration.addresss = txtaddress.Value;
                    objkotedar_registration.states = ddlstate.SelectedValue;
                    objkotedar_registration.district = ddldistrict.SelectedValue;
                    objkotedar_registration.Constituency = ddlconstituency.SelectedValue;
                    objkotedar_registration.kotedar_no = txtkotedarid.Value;
                    objkotedar_registration.aadhar_no = txtaadharno.Value.Trim();
                    objkotedar_registration.pan_no = txtpanno.Value;
                    objkotedar_registration.pincode_no = Int32.Parse(txtpincode.Value.Trim());

                    string x = UploadPhoto();
                    if (x == "YES")
                    {
                        string y = UploadSignature();
                        if (y == "YES")
                        {
                            objclsKotedarUpdation_Logic.InsertKotedar(objkotedar_registration);

                            InitializeField();
                            CheckData();
                            Response.Write("<script>alert('Kotedar Detail Save Successfull');</script>");
                        }
                    }
                    else
                    {
                        return;
                    }
                }

            }


            catch (Exception ex)
            {
                Response.Write("<script>alert('Error Occure Contact Admin');</script>");
                Response.Write(ex.Message);
            }

        }


        public void InitializeField()
        {
            txtaadharno.Value = "";
            txtaddress.Value = "";
            txtemail.Value = "";
            txtkotedar.Value = "";
            txtkotedarid.Value = "";
            txtmobile.Value = "";
            txtpanno.Value = "";
            txtpincode.Value = "";
            ddlstate.SelectedIndex = 0;
            ddldistrict.SelectedIndex = 0;
            ddlconstituency.SelectedIndex = 0;


        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["user_id"] != null)
                {
                    string user_id = Session["user_id"].ToString();
                    objkotedar_registration.user_id = Convert.ToInt32(user_id);
                }
                if (string.IsNullOrEmpty(txtaadharno.Value) || string.IsNullOrEmpty(txtaddress.Value) || string.IsNullOrEmpty(txtemail.Value) || string.IsNullOrEmpty(txtkotedar.Value) || string.IsNullOrEmpty(txtkotedarid.Value) || string.IsNullOrEmpty(txtpincode.Value) || string.IsNullOrEmpty(txtmobile.Value) || string.IsNullOrEmpty(txtpanno.Value) || (ddlstate.SelectedItem.Text == "**SELECT**") || ddldistrict.SelectedItem.Text == "**SELECT**" || ddlconstituency.SelectedItem.Text == "**SELECT**")
                {
                    ValidateForm();
                }
                else
                {
                    objkotedar_registration.kotedar_name = txtkotedar.Value;
                    objkotedar_registration.addresss = txtaddress.Value;
                    objkotedar_registration.states = ddlstate.SelectedValue;
                    objkotedar_registration.district = ddldistrict.SelectedValue;
                    objkotedar_registration.Constituency = ddlconstituency.SelectedValue;
                    objkotedar_registration.kotedar_no = txtkotedarid.Value;
                    objkotedar_registration.aadhar_no = txtaadharno.Value.Trim();
                    objkotedar_registration.pan_no = txtpanno.Value;
                    objkotedar_registration.pincode_no = Int32.Parse(txtpincode.Value.Trim());

                    string x = UploadPhotoUpdate();
                    if (x == "YES")
                    {
                        string y = UploadSignatureUpdate();
                        if (y == "YES")
                        {
                            objclsKotedarUpdation_Logic.UpdateKotedar(objkotedar_registration);

                            InitializeField();
                            CheckData();
                            Response.Write("<script>alert('Kotedar Detail Updated Successfull');</script>");
                            this.Page_Load(null, null);

                        }
                    }


                    else
                    {
                        return;
                    }

                }
            }


            catch (Exception ex)
            {
                Response.Write("<script>alert('Error Occure Contact Admin');</script>");
                Response.Write(ex.Message);
            }
        }

        public void CheckData()
        {

            string userid = Session["user_id"].ToString();
            string strSQL;
            strSQL = "SELECT * from tbl_kotedar_registration where user_id='" + userid + "'";
            DataSet dsTemp = objclsDbConnector.GetDataSet(strSQL);
            DataTable dtTemp= dsTemp.Tables[0];
            if (dtTemp.Rows.Count > 0)
            {
                btnsubmit.Visible = false;
                btnupdate.Visible = true;
                txtaadharno.Value= dtTemp.Rows[0]["aadhar_no"].ToString();
                txtaddress.Value= dtTemp.Rows[0]["addresss"].ToString();
                txtkotedarid.Value = dtTemp.Rows[0]["kotedar_no"].ToString();
                txtpanno.Value= dtTemp.Rows[0]["pan_no"].ToString();
                txtpincode.Value = dtTemp.Rows[0]["pincode_no"].ToString();
                ddlstate.SelectedValue= dtTemp.Rows[0]["states"].ToString();
                ddldistrict.SelectedValue= dtTemp.Rows[0]["district"].ToString();
                ddlconstituency.SelectedValue = dtTemp.Rows[0]["contituency"].ToString();
                lblphotoname.Text= dtTemp.Rows[0]["photo_name"].ToString();
                lblsignature.Text = dtTemp.Rows[0]["signature_name"].ToString();
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
                txtkotedar.Value= dtTempU.Rows[0]["name"].ToString();
                txtmobile.Value = dtTempU.Rows[0]["mobile"].ToString();
                txtemail.Value = dtTempU.Rows[0]["email"].ToString();                           
            }
            else
            {
                btnsubmit.Visible = true;
                btnupdate.Visible = false;

            }
        }

        public void FetchData()
        {

            string userid = Session["user_id"].ToString();
            string strSQL;
            strSQL = "select * from tbl_kotedar_registration where user_id='" + userid + "'";
            DataSet dsTemp = objclsDbConnector.GetDataSet(strSQL);
            DataTable dtTemp = dsTemp.Tables[0];
            if (dtTemp.Rows.Count > 0)
            {
                          

                Label lblname = this.Master.FindControl("lblkname") as Label;
                lblname.Text = Session["name"].ToString();

                Label lblkid = this.Master.FindControl("lblkid") as Label;            
                lblkid.Text = dtTemp.Rows[0]["kotedar_no"].ToString();  
                
                Label lblconstiuency = this.Master.FindControl("lblconstiuency") as Label;
                lblconstiuency.Text = dtTemp.Rows[0]["contituency"].ToString();

            }
         
        }

        public string UploadPhoto()
        {
            string x;
            if (!fusignature.HasFile)
            {
                Response.Write("<script>alert('Please Select File.');</script>");
                x = "NO";
                return x;
            }
            //else if (!fusignature.FileName.ToUpper().EndsWith(".XML"))
            //{

            //    Response.Write("<script>alert('Only Xml file(.XML) allowed.);</script>");
            //}
            else if (fusignature.FileName.Split('.').Count() != 2)
            {
                Response.Write("<script>alert('Invalid file Format.');</script>");
                x = "NO";
                return x;
            }
            else
            {
                HttpPostedFile postedFile = fuphoto.PostedFile;

                //string filename = Path.GetFileName(postedFile.FileName);
                //string fileExtension = Path.GetExtension(filename);
                //int fileSize = postedFile.ContentLength;

                objkotedar_registration.photo_contenttype = fuphoto.PostedFile.ContentType;
                objkotedar_registration.photo_name = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(objkotedar_registration.photo_name);
                objkotedar_registration.photo_size = postedFile.ContentLength;

                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                objkotedar_registration.photo_data = binaryReader.ReadBytes((int)stream.Length);
                return x = "YES";
            }

        }


        public string UploadSignature()
        {
            string y;
            if (!fusignature.HasFile)
            {               
                Response.Write("<script>alert('Please Select File.');</script>");
                y= "NO";
                return y;
            }
            //else if (!fusignature.FileName.ToUpper().EndsWith(".XML"))
            //{
               
            //    Response.Write("<script>alert('Only Xml file(.XML) allowed.);</script>");
            //}
            else if (fusignature.FileName.Split('.').Count() != 2)
            {            
                Response.Write("<script>alert('Invalid file Format.');</script>");
                y = "NO";
                return y;
            }
            else { 
            HttpPostedFile postedFile = fusignature.PostedFile;

            //string filename = Path.GetFileName(postedFile.FileName);
            //string fileExtension = Path.GetExtension(filename);
            //int fileSize = postedFile.ContentLength;

            objkotedar_registration.signature_contenttype = fusignature.PostedFile.ContentType;
            objkotedar_registration.signature_name = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(objkotedar_registration.photo_name);
            objkotedar_registration.signature_size = postedFile.ContentLength;

            Stream stream = postedFile.InputStream;
            BinaryReader binaryReader = new BinaryReader(stream);
            objkotedar_registration.signature_data = binaryReader.ReadBytes((int)stream.Length);
                return y="YES";
            }

        }


        public string UploadPhotoUpdate()
        {
            string x;
        
                HttpPostedFile postedFile = fuphoto.PostedFile;

                //string filename = Path.GetFileName(postedFile.FileName);
                //string fileExtension = Path.GetExtension(filename);
                //int fileSize = postedFile.ContentLength;

                objkotedar_registration.photo_contenttype = fuphoto.PostedFile.ContentType;
                objkotedar_registration.photo_name = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(objkotedar_registration.photo_name);
                objkotedar_registration.photo_size = postedFile.ContentLength;

                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                objkotedar_registration.photo_data = binaryReader.ReadBytes((int)stream.Length);
                return x = "YES";
            }

        public string UploadSignatureUpdate()
        {
            string y;

                HttpPostedFile postedFile = fusignature.PostedFile;

                //string filename = Path.GetFileName(postedFile.FileName);
                //string fileExtension = Path.GetExtension(filename);
                //int fileSize = postedFile.ContentLength;

                objkotedar_registration.signature_contenttype = fusignature.PostedFile.ContentType;
                objkotedar_registration.signature_name = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(objkotedar_registration.photo_name);
                objkotedar_registration.signature_size = postedFile.ContentLength;

                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                objkotedar_registration.signature_data = binaryReader.ReadBytes((int)stream.Length);
                return y = "YES";
            

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

        public void ValidateForm()
        {
            if (string.IsNullOrEmpty(txtaadharno.Value))
            {
                Response.Write("<script>alert('Please Enter Aadhar Card No..');</script>");
                return;
            }
            if (string.IsNullOrEmpty(txtaddress.Value))
            {
                Response.Write("<script>alert('Please Enter Address..');</script>");
                return;
            }
            if (string.IsNullOrEmpty(txtemail.Value))
            {
                Response.Write("<script>alert('Please Enter Email..');</script>");
                return;
            }
            if (string.IsNullOrEmpty(txtkotedar.Value))
            {
                Response.Write("<script>alert('Please Enter KotedarName..');</script>");
                return;
            }           
            if (string.IsNullOrEmpty(txtkotedarid.Value))
            {
                Response.Write("<script>alert('Please Enter KotedarNo..');</script>");
                return;
            }
            if (string.IsNullOrEmpty(txtmobile.Value))
            {
                Response.Write("<script>alert('Please Enter MobileNo..');</script>");
                return;
            }
            if (string.IsNullOrEmpty(txtpanno.Value))
            {
                Response.Write("<script>alert('Please Enter Pan..');</script>");
                return;
            }
            if (string.IsNullOrEmpty(txtpincode.Value))
            {
                Response.Write("<script>alert('Please Enter Pincode..');</script>");
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

        }
    }
}