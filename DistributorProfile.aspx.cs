﻿using e_ration_card.Models;
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

            if (!IsPostBack)
            {
               

                ddlstate.DataSource = ds.Tables[0];
                ddlstate.DataBind();
                ddlstate.Items.Insert(0, "**SELECT**");
                ddldistrict.Items.Insert(0, "**SELECT**");
                CheckData();
                

            }
           
           //Label lbl = this.Master.FindControl("lblkname") as Label;
           // lbl.Text = Session["name"].ToString();
           // TextBox txtlblkname = this.Master.FindControl("txtlblkname") as TextBox;
           // txtlblkname.Text = Session["name"].ToString();
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

                objkotedar_registration.kotedar_name = txtkotedar.Value;
                objkotedar_registration.addresss = txtaddress.Value;
                objkotedar_registration.states = ddlstate.SelectedValue;
                objkotedar_registration.district = ddldistrict.SelectedValue;
                objkotedar_registration.Constituency = ddlconstituency.SelectedValue;
                objkotedar_registration.kotedar_no = txtkotedarid.Value;
                objkotedar_registration.aadhar_no =txtaadharno.Value.Trim(); 
                objkotedar_registration.pan_no = txtpanno.Value;
                objkotedar_registration.pincode_no = Int32.Parse(txtpincode.Value.Trim());

                string x=UploadPhoto();
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
            catch(Exception ex)
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
                    }
                }

                else
                {
                    return;
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
    }
}