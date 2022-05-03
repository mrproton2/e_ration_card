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
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["user_id"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {

            }
            
            changename.Visible = false;
            changeaddress.Visible = false;
            addmember.Visible = false;
            removemember.Visible = false;
            annualincome.Visible = false;
            changemembernam.Visible = false;
            VisibleDiv();


            BindGridChangeName();
            BindGridAddress();

            Label lblhname = this.Master.FindControl("lblhname") as Label;
            lblhname.Text = Session["cardholdername"].ToString();
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

        protected void btnchangeaddress_Click1(object sender, EventArgs e)
        {
            objclschangeaddress.new_address = txtnewaddress .Value;
            objclschangeaddress.old_address =txtoldaddress.Value;
            HttpPostedFile postedFile =fu1address.PostedFile;
            //string filename = Path.GetFileName(postedFile.FileName);
            //string fileExtension = Path.GetExtension(filename);
            //int fileSize = postedFile.ContentLength;
            objchangename.contcontenttype = fu1address.PostedFile.ContentType;


            objclschangeaddress.ac_doc1_name = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(objclschangeaddress.ac_doc1_name);
            objclschangeaddress.ac_doc1_size = postedFile.ContentLength;

            Stream stream = postedFile.InputStream;
            BinaryReader binaryReader = new BinaryReader(stream);
            objclschangeaddress.ac_doc1_data = binaryReader.ReadBytes((int)stream.Length);

            objclsRationCardUpdation.ChangeAddress(objclschangeaddress);

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
    }
}