using e_ration_card.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using e_ration_card.Services;

namespace e_ration_card
{
    public partial class UpdateRationCard : System.Web.UI.Page
    {

        changename objchangename = new changename();
        clschangeaddress objclschangeaddress = new clschangeaddress();
        clsRationCardUpdation objclsRationCardUpdation = new clsRationCardUpdation();
        distribution_details objdistribution_Details = new distribution_details();
        clsDbConnector objclsDbConnector = new clsDbConnector();
        clsDistribution objclsDistribution = new clsDistribution();
        clsmembercorrection objclsmembercorrection = new clsmembercorrection();
        clsaddmember objclsaddmember = new clsaddmember();
        clsremovembr objclsremovembr = new clsremovembr();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["user_id"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {

            }
            
            if(!IsPostBack)
            {
                MemberBind();

            }

            changename.Visible = false;
            changeaddress.Visible = false;
            addmember.Visible = false;
            removemember.Visible = false;
            annualincome.Visible = false;
            changemembernam.Visible = false;
            VisibleDiv();

            GetData();

            BindGridChangeName();
            BindGridAddress();
            BindGridMbrCorrection();
            BindGridMbrCorrectionD();
            BindGridAddMember();
            BindGridAddMemberD();
            BindGridRemoveMember();
            BindGridRemoveMemberD();

            Label lblhname = this.Master.FindControl("lblhname") as Label;
            lblhname.Text = Session["cardholdername"].ToString();
            //txtoldname.Value= Session["cardholdername"].ToString();
            Label lblconstiuency = this.Master.FindControl("lblconstiuency") as Label;           
            lblconstiuency.Text = Session["constituency"].ToString();


        }

        private void VisibleDiv()
        {
            if (chkchangename.Checked == true)
            {
                changename.Visible = true;

            }
            if (chkchangeaddress.Checked == true)
            {
                changeaddress.Visible = true;

            }
            if (chkaddmember.Checked == true)
            {
                addmember.Visible = true;

            }
            if (chkremovemember.Checked == true)
            {
                removemember.Visible = true;

            }
            if (chkannualincome.Checked == true)
            {
                annualincome.Visible = true;

            }
            if (chkchangemembernam.Checked == true)
            {
                changemembernam.Visible = true;

            }

        }

        protected void btnchangename_Click(object sender, EventArgs e)
        {
            objchangename.new_name = txtnewname.Value;
            objchangename.old_name = txtoldname.Value;
            HttpPostedFile postedFile = fu1changename.PostedFile;
            //string filename = Path.GetFileName(postedFile.FileName);
            //string fileExtension = Path.GetExtension(filename);
            //int fileSize = postedFile.ContentLength;
            objchangename.contcontenttype = fu1changename.PostedFile.ContentType;


            objchangename.cn_doc1_name = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(objchangename.cn_doc1_name);
            objchangename.cn_doc1_size = postedFile.ContentLength;

            Stream stream = postedFile.InputStream;
            BinaryReader binaryReader = new BinaryReader(stream);
            objchangename.cn_doc1_data = binaryReader.ReadBytes((int)stream.Length);

            objclsRationCardUpdation.ChangeName(objchangename);


            Response.Write("<script>alert('Request Raise Successfully');</script>");



        }

        protected void lnkDownloadDoc1_Click(object sender, EventArgs e)
        {
           
               
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from tbl_change_name where cn_id=@cn_id";
                    cmd.Parameters.AddWithValue("@cn_id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["cn_doc1_data"];
                        contentType = sdr["contcontenttype"].ToString();
                        fileName = sdr["cn_doc1_name"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        private void BindGridChangeName()
        {

            string strSQ1 = "select * from tbl_change_name";
            DataTable dsGrid = new DataTable();
            dsGrid = objclsDbConnector.GetData(strSQ1);

            gvchangename.DataSource = dsGrid;
            gvchangename.DataBind();
            ViewState["dt"] = dsGrid;
            
        }

        private void BindGridChangeNameD()
        {
         

            gvchangename.DataSource = ViewState["dt1"] as DataTable;
            gvchangename.DataBind();
        

        }
        protected void lnkDownloadDoc2_Click(object sender, EventArgs e)
        {

            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from tbl_change_name where cn_id=@cn_id";
                    cmd.Parameters.AddWithValue("@cn_id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["cn_doc2_data"];
                        contentType = sdr["contcontenttype"].ToString();
                        fileName = sdr["cn_doc2_name"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

      
        protected void lnkViewDoc1_Click(object sender, EventArgs e)
        {
            //int id = int.Parse((sender as LinkButton).CommandArgument);
            string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"500px\" height=\"600px\">";
            embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
            embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
            embed += "</object>";
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from tbl_change_name where cn_id=@cn_id";
                    cmd.Parameters.AddWithValue("@cn_id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["cn_doc1_data"];
                        contentType = sdr["contcontenttype"].ToString();
                        fileName = sdr["cn_doc1_name"].ToString();
                    }
                    con.Close();
                }
            }
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", bytes.Length.ToString());
            Response.BinaryWrite(bytes);
        }

        protected void btnchangeaddress_Click(object sender, EventArgs e)
        {
            objchangename.new_name = txtnewname.Value;
            HttpPostedFile postedFile = fu1changename.PostedFile;
            //string filename = Path.GetFileName(postedFile.FileName);
            //string fileExtension = Path.GetExtension(filename);
            //int fileSize = postedFile.ContentLength;
            objchangename.contcontenttype = fu1changename.PostedFile.ContentType;


            objchangename.cn_doc1_name = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(objchangename.cn_doc1_name);
            objchangename.cn_doc1_size = postedFile.ContentLength;

            Stream stream = postedFile.InputStream;
            BinaryReader binaryReader = new BinaryReader(stream);
            objchangename.cn_doc1_data = binaryReader.ReadBytes((int)stream.Length);

            objclsRationCardUpdation.ChangeName(objchangename);

            Response.Write("<script>alert('Request Raise Successfully');</script>");

        }

        //protected void lnkDelete_Click(object sender, EventArgs e)
        //{

        //}

        //protected void gvchangename_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvchangename.PageIndex = e.NewPageIndex;
        //    gvchangename.DataSource = ViewState[""];
        //    gvchangename.DataBind();
        //}

        


   

        protected void gvchangename_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;

                foreach (LinkButton button in e.Row.Cells[6].Controls.OfType<LinkButton>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
        }

       

        protected void gvchangename_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["dt"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["dt1"] = dt;
            BindGridChangeNameD();
        }

        protected void lnkDownloadDocadd1_Click(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from tbl_address_correction where ac_id=@ac_id";
                    cmd.Parameters.AddWithValue("@ac_id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["ac_doc1_data"];
                        contentType = sdr["contcontenttype"].ToString();
                        fileName = sdr["ac_doc1_name"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();

        }

        protected void lnkDownloadDocadd2_Click(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from tbl_address_correction where ac_id=@ac_id";
                    cmd.Parameters.AddWithValue("@ac_id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["ac_doc2_data"];
                        contentType = sdr["contcontenttype"].ToString();
                        fileName = sdr["ac_doc2_name"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();

        }

        protected void btnchangeaddress_Click1(object sender, EventArgs e)
        {
            objclschangeaddress.new_address = txtnewaddress .Value;
            objclschangeaddress.old_address =txtoldaddress.Value;           
            objclschangeaddress.user_id= Convert.ToInt32(Session["user_id"].ToString());
            HttpPostedFile postedFile =fu1address.PostedFile;
            //string filename = Path.GetFileName(postedFile.FileName);
            //string fileExtension = Path.GetExtension(filename);
            //int fileSize = postedFile.ContentLength;
            objclschangeaddress.contcontenttype = fu1address.PostedFile.ContentType;


            objclschangeaddress.ac_doc1_name = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(objclschangeaddress.ac_doc1_name);
            objclschangeaddress.ac_doc1_size = postedFile.ContentLength;

            Stream stream = postedFile.InputStream;
            BinaryReader binaryReader = new BinaryReader(stream);
            objclschangeaddress.ac_doc1_data = binaryReader.ReadBytes((int)stream.Length);

            objclsRationCardUpdation.ChangeAddress(objclschangeaddress);
            Response.Write("<script>alert('Request Raise Successfully');</script>");

        }

        private void BindGridAddress()
        {

            string strSQ1 = "select * from tbl_address_correction";
            DataTable dsGrid = new DataTable();
            dsGrid = objclsDbConnector.GetData(strSQ1);

            gvchangeaddress.DataSource = dsGrid;
            gvchangeaddress.DataBind();
            ViewState["dtadd"] = dsGrid;

        }

        private void BindGridAddressD()
        {


            gvchangeaddress.DataSource = ViewState["dtadd1"] as DataTable;
            gvchangeaddress.DataBind();


        }

        private void BindGridMbrCorrection()
        {

            string strSQ1 = "select * from tbl_membername_correction";
            DataTable dsGrid = new DataTable();
            dsGrid = objclsDbConnector.GetData(strSQ1);

            gvmbrcorrection.DataSource = dsGrid;
            gvmbrcorrection.DataBind();
            ViewState["dtmbr"] = dsGrid;

        }
        private void BindGridMbrCorrectionD()
        {


            gvmbrcorrection.DataSource = ViewState["dtmbr"] as DataTable;
            gvmbrcorrection.DataBind();


        }


        private void BindGridAddMember()
        {

            string strSQ1 = "select * from tbl_add_member";
            DataTable dsGrid = new DataTable();
            dsGrid = objclsDbConnector.GetData(strSQ1);

            gvaddmember.DataSource = dsGrid;
            gvaddmember.DataBind();
            ViewState["dtaddmbr"] = dsGrid;

        }
        private void BindGridAddMemberD()
        {


            gvaddmember.DataSource = ViewState["dtaddmbr"] as DataTable;
            gvaddmember.DataBind();


        }

        private void BindGridRemoveMember()
        {

            string strSQ1 = "select * from tbl_remove_member";
            DataTable dsGrid = new DataTable();
            dsGrid = objclsDbConnector.GetData(strSQ1);

            gbremovembr.DataSource = dsGrid;
            gbremovembr.DataBind();
            ViewState["dtremovembr"] = dsGrid;

        }
        private void BindGridRemoveMemberD()
        {

            gbremovembr.DataSource = ViewState["dtremovembr"] as DataTable;
            gbremovembr.DataBind();


        }


        public void GetData()
        {

            string userid = Session["user_id"].ToString();
            string strSQL;
            strSQL = "SELECT * from tbl_general_registration where user_id='" + userid + "'";
            DataSet dsTemp = objclsDbConnector.GetDataSet(strSQL);
            DataTable dtTemp = dsTemp.Tables[0];
            txtoldaddress.Value= dtTemp.Rows[0]["addresss"].ToString();
            
            
            string strSQLU;
            strSQLU = "SELECT * from users where user_id='" + userid + "'";
            DataSet dsTempU = objclsDbConnector.GetDataSet(strSQLU);
            DataTable dtTempU = dsTempU.Tables[0];
            txtoldname.Value= dtTempU.Rows[0]["name"].ToString();

        }

        public void MemberBind()
        {
            string userid = Session["user_id"].ToString();
            string strSQLM;
            strSQLM = "select mbr_name from tbl_member_list where user_id='" + userid + "'";
            DataSet dsTempM = objclsDbConnector.GetDataSet(strSQLM);
            DataTable dtTempM = dsTempM.Tables[0];
            ddlremovemembername.DataSource = dtTempM;
            ddlremovemembername.DataBind();
            ddlremovemembername.Items.Insert(0, "**SELECT**");

            ddlolmembername.DataSource= dtTempM;
            ddlolmembername.DataBind();
            ddlolmembername.Items.Insert(0, "**SELECT**");

        }

        protected void gvmbrcorrection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;

                foreach (LinkButton button in e.Row.Cells[6].Controls.OfType<LinkButton>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }

        }

        protected void lnkDownloadDocmbr1_Click(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from tbl_membername_correction where mnc_id=@mbr_id";
                    cmd.Parameters.AddWithValue("@mbr_id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["mbr_doc1_data"];
                        contentType = sdr["contcontenttype"].ToString();
                        fileName = sdr["mbr_doc1_name"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        protected void lnkDownloadDocmbr2_Click(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from tbl_address_correction where mbr_id=@mbr_id";
                    cmd.Parameters.AddWithValue("@mbr_id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["mbr_doc2_data"];
                        contentType = sdr["contcontenttype"].ToString();
                        fileName = sdr["mbr_doc2_name"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();

        }

        protected void btnchangemembername_Click(object sender, EventArgs e)
        {
            objclsmembercorrection.old_mbrname = ddlolmembername.SelectedValue;
            objclsmembercorrection.new_mbrname = txtnewmembername.Value;
            objclsmembercorrection.user_id = Convert.ToInt32(Session["user_id"].ToString());
            HttpPostedFile postedFile = fu1changemembername.PostedFile;
            //string filename = Path.GetFileName(postedFile.FileName);
            //string fileExtension = Path.GetExtension(filename);
            //int fileSize = postedFile.ContentLength;
            objclsmembercorrection.contcontenttype = fu1changemembername.PostedFile.ContentType;


            objclsmembercorrection.mbr_doc1_name = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(objclschangeaddress.ac_doc1_name);
            objclsmembercorrection.mbr_doc1_size = postedFile.ContentLength;

            Stream stream = postedFile.InputStream;
            BinaryReader binaryReader = new BinaryReader(stream);
            objclsmembercorrection.mbr_doc1_data = binaryReader.ReadBytes((int)stream.Length);

            objclsRationCardUpdation.ChangeMbrName(objclsmembercorrection);
            Response.Write("<script>alert('Request Raise Successfully');</script>");

        }

        protected void gvaddmember_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;

                foreach (LinkButton button in e.Row.Cells[6].Controls.OfType<LinkButton>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }

        }

        protected void lnkDownloadDocaddmbr1_Click(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from tbl_add_member where addmbr_id=@addmbr_id";
                    cmd.Parameters.AddWithValue("@addmbr_id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["addmbr_doc1_data"];
                        contentType = sdr["contcontenttype"].ToString();
                        fileName = sdr["addmbr_doc1_name"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        protected void lnkDownloadDocaddmbr2_Click(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from tbl_add_member where addmbr_id=@addmbr_id";
                    cmd.Parameters.AddWithValue("@addmbr_id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["addmbr_doc2_data"];
                        contentType = sdr["contcontenttype"].ToString();
                        fileName = sdr["addmbr_doc2_name"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();

        }

        protected void btnaddmember_Click(object sender, EventArgs e)
        {
            objclsaddmember.new_membername = txtaddmembername.Value;
            objclsaddmember.relation = txtaddmemberrelation.Value;
            objclsaddmember.user_id = Convert.ToInt32(Session["user_id"].ToString());
            HttpPostedFile postedFile = fu1addmember.PostedFile;
            //string filename = Path.GetFileName(postedFile.FileName);
            //string fileExtension = Path.GetExtension(filename);
            //int fileSize = postedFile.ContentLength;
            objclsaddmember.contcontenttype = fu1addmember.PostedFile.ContentType;


            objclsaddmember.addmbr_doc1_name = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(objclsaddmember.addmbr_doc1_name);
            objclsaddmember.addmbr_doc1_size = postedFile.ContentLength;

            Stream stream = postedFile.InputStream;
            BinaryReader binaryReader = new BinaryReader(stream);
            objclsaddmember.addmbr_doc1_data = binaryReader.ReadBytes((int)stream.Length);

            objclsRationCardUpdation.AddMember(objclsaddmember);
            Response.Write("<script>alert('Request Raise Successfully');</script>");

        }

        protected void lnkDownloadDocremovembr1_Click(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from tbl_remove_member where removembr_id=@removembr_id";
                    cmd.Parameters.AddWithValue("@removembr_id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["removembr_doc1_data"];
                        contentType = sdr["contcontenttype"].ToString();
                        fileName = sdr["removembr_doc1_name"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();

        }

        protected void lnkDownloadDocremovembr2_Click(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from tbl_remove_member where removembr_id=@removembr_id";
                    cmd.Parameters.AddWithValue("@removembr_id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["removembr_doc2_data"];
                        contentType = sdr["contcontenttype"].ToString();
                        fileName = sdr["removembr_doc2_name"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        protected void btnremovemember_Click(object sender, EventArgs e)
        {
            string userid = Session["user_id"].ToString();
            string strSQLM;
            strSQLM = "select mbrlist_id from tbl_member_list where mbr_name like '%" + ddlremovemembername.SelectedValue + "%' AND user_id='" + userid + "'";
            DataSet dsTempM = objclsDbConnector.GetDataSet(strSQLM);
            DataTable dtTempM = dsTempM.Tables[0];
            string mbrid = dtTempM.Rows[0][0].ToString();

            objclsremovembr.new_membername = ddlremovemembername.SelectedValue;
            objclsremovembr.mbrlist_id = Convert.ToInt32(mbrid);
            objclsremovembr.relation = txtmemberremovereson.Value;
            objclsremovembr.user_id = Convert.ToInt32(Session["user_id"].ToString());
            HttpPostedFile postedFile = fu1removemember.PostedFile;
            //string filename = Path.GetFileName(postedFile.FileName);
            //string fileExtension = Path.GetExtension(filename);
            //int fileSize = postedFile.ContentLength;
            objclsremovembr.contcontenttype = fu1removemember.PostedFile.ContentType;
            objclsremovembr.removembr_doc1_name = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(objclsremovembr.removembr_doc1_name);
            objclsremovembr.removembr_doc1_size = postedFile.ContentLength;

            Stream stream = postedFile.InputStream;
            BinaryReader binaryReader = new BinaryReader(stream);
            objclsremovembr.removembr_doc1_data = binaryReader.ReadBytes((int)stream.Length);
            
            objclsRationCardUpdation.RemoveMember(objclsremovembr);
            Response.Write("<script>alert('Request Raise Successfully');</script>");
        }

        //public void GetMemberId()
        //{
        //    string userid = Session["user_id"].ToString();
        //    string strSQLM;
        //    strSQLM = "select mbrlist_id from tbl_member_list where mbr_name like '%'" + ddlremovemembername.SelectedValue + "'% ";
        //    DataSet dsTempM = objclsDbConnector.GetDataSet(strSQLM);
        //    DataTable dtTempM = dsTempM.Tables[0];
        //    string mbrid = dtTempM.Rows[0][0].ToString();



        //}
    }
}