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
        clsRationCardUpdation objclsRationCardUpdation = new clsRationCardUpdation();
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
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from tbl_change_name";
                    cmd.Connection = con;
                    con.Open();
                    gvchangename.DataSource = cmd.ExecuteReader();
                    gvchangename.DataBind();
                    con.Close();
                }
            }
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

        //protected void gvchangename_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvchangename.PageIndex = e.NewPageIndex;
        //    gvchangename.DataSource = ViewState[""];
        //    gvchangename.DataBind();
        //}
    }
}