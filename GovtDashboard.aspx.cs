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
    public partial class GovtDashboard : System.Web.UI.Page
    {
        changename objchangename = new changename();
        clsRationCardUpdation objclsRationCardUpdation = new clsRationCardUpdation();
        distribution_details objdistribution_Details = new distribution_details();
        clsDbConnector objclsDbConnector = new clsDbConnector();
        clsDistribution objclsDistribution = new clsDistribution();
        protected void Page_Load(object sender, EventArgs e)
        {
            //string username = "";
            //string userid = "";
            //Nullable<int> username = null;

            // username = Session["username"].ToString();
            // userid = Session["user_id"].ToString();

            clsDbConnector objclsDbConnector = new clsDbConnector();
            string strSQ = "SELECT consitiuency_name from tbl_consitiuency";
            DataSet ds = new DataSet();
            ds = objclsDbConnector.GetDataSet(strSQ);

            //BindGridChangeName();

            if (Session["user_id"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {

            }
            if (!IsPostBack)
            {
                
                ddlconstituency.DataSource = ds.Tables[0];
                ddlconstituency.DataBind();
                ddlconstituency.Items.Insert(0, "**SELECT**");
                BindGridChangeName();
                BindGridChangeNameB();

            }

        }

        private void BindGridChangeName()
        {
            if (ddlcorrectiontype.SelectedValue== "Name Correction")
            {
                string strSQ1 = "select b.cn_id,a.card_holder_name,a.constituency,a.rationcard_no,a.states,district," +
                    "b.old_name,b.new_name,cn_doc1_name,cn_doc2_name," +
                    "Authorize,b.reject_reson " +
                    "from tbl_general_registration a " +
                    "inner join tbl_change_name b " +
                    "on a.user_id = b.user_id ";
                DataTable dsGrid = new DataTable();
                dsGrid = objclsDbConnector.GetData(strSQ1);
                gvchangename.DataSource = dsGrid;
                gvchangename.DataBind();
               

            }
            if (ddlcorrectiontype.SelectedValue == "Change Address")
            {
                string strSQ1 = "select * from tbl_change_name";
                DataTable dsGrid = new DataTable();
                dsGrid = objclsDbConnector.GetData(strSQ1);
                gvchangename.DataSource = dsGrid;
                gvchangename.DataBind();
              

            }


            

        }

        private void BindGridChangeNameB()
        {
            if (ddlcorrectiontype.SelectedValue == "Name Correction")
            {
                string strSQ1 = "select b.user_id user_id,b.cn_id,a.card_holder_name,a.constituency,a.rationcard_no,a.states,district," +
                    "b.old_name,b.new_name,cn_doc1_name,cn_doc2_name," +
                    "Authorize,b.reject_reson " +
                    "from tbl_general_registration a " +
                    "inner join tbl_change_name b " +
                    "on a.user_id = b.user_id where a.constituency='" + ddlconstituency.SelectedItem.Text  +"' " +
                    "and Authorize='Pending'";


                DataTable dsGrid = new DataTable();
                dsGrid = objclsDbConnector.GetData(strSQ1);
                gvchangename.DataSource = dsGrid;
                gvchangename.DataBind();


            }
            if (ddlcorrectiontype.SelectedValue == "Change Address")
            {
                string strSQ1 = "select b.user_id user_id, b.ac_id,a.card_holder_name,a.constituency,a.rationcard_no,a.states,district,b.old_address,b.new_address,ac_doc1_name,ac_doc2_name," +
                    "Authorize,b.reject_reson " +
                    "from tbl_general_registration a "+
                    "inner join tbl_address_correction b " +
                    "on a.user_id = b.user_id where a.constituency='" + ddlconstituency.SelectedItem.Text + "' " +
                    "and Authorize='Pending'";
                DataTable dsGrid = new DataTable();
                dsGrid = objclsDbConnector.GetData(strSQ1);
                gvaddresscorrection.DataSource = dsGrid;
                gvaddresscorrection.DataBind();


            }

            if (ddlcorrectiontype.SelectedValue == "Member Name Correction")
            {
                string strSQ1 = "select b.user_id user_id, b.mbr_id,a.card_holder_name,a.constituency,a.rationcard_no,a.states,district,b.old_mbrname,b.new_mbrname,mbr_doc1_name,mbr_doc2_name," +
                    "Authorize,b.reject_reson " +
                    "from tbl_general_registration a " +
                    "inner join tbl_membername_correction b " +
                    "on a.user_id = b.user_id where a.constituency='" + ddlconstituency.SelectedItem.Text + "' " +
                    "and Authorize='Pending'";
                DataTable dsGrid = new DataTable();
                dsGrid = objclsDbConnector.GetData(strSQ1);
                gvmembernamecorr.DataSource = dsGrid;
                gvmembernamecorr.DataBind();


            }

            if (ddlcorrectiontype.SelectedValue == "Add Member")
            {
                string strSQ1 = "select b.user_id user_id, b.addmbr_id,a.card_holder_name,a.constituency,a.rationcard_no,a.states,district,b.membername,addmbr_doc1_name,addmbr_doc2_name,b.relation, " +
                    "Authorize,b.reject_reson " +
                    "from tbl_general_registration a " +
                    "inner join tbl_add_member b " +
                    "on a.user_id = b.user_id where a.constituency='" + ddlconstituency.SelectedItem.Text + "' " +
                    "and Authorize='Pending'";
                DataTable dsGrid = new DataTable();
                dsGrid = objclsDbConnector.GetData(strSQ1);
                gvaddmbr.DataSource = dsGrid;
                gvaddmbr.DataBind();


            }


            if (ddlcorrectiontype.SelectedValue == "Remove Member")
            {
                string strSQ1 = "select b.user_id user_id, b.removembr_id,a.card_holder_name,a.constituency,a.rationcard_no,a.states,district,b.membername,removembr_doc1_name,removembr_doc2_name,b.relation, " +
                    "Authorize,b.reject_reson " +
                    "from tbl_general_registration a " +
                    "inner join tbl_remove_member b " +
                    "on a.user_id = b.user_id where a.constituency='" + ddlconstituency.SelectedItem.Text + "' " +
                    "and Authorize='Pending'";
                DataTable dsGrid = new DataTable();
                dsGrid = objclsDbConnector.GetData(strSQ1);
                gvremovembr.DataSource = dsGrid;
                gvremovembr.DataBind();


            }




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


        protected void gvchangename_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    string item = e.Row.Cells[0].Text;

            //    foreach (LinkButton button in e.Row.Cells[6].Controls.OfType<LinkButton>())
            //    {
            //        if (button.CommandName == "Delete")
            //        {
            //            button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
            //        }
            //    }
            //}


            try
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {
                    TableCellCollection cells = e.Row.Cells;
                    foreach (TableCell cell in cells)
                    {
                        if (cell.Text.ToUpper().StartsWith("H_"))
                        {
                            cell.Attributes.Add("style", "display:none");
                        }
                    }
                }

          
                switch (e.Row.RowType)
                {
                    case DataControlRowType.Header:
                        ((CheckBox)e.Row.FindControl("chkAll")).Attributes.Add("OnClick", "SelectAll(this.checked)");
                        //e.Row.Cells[1].Visible = false;
                        //e.Row.Cells[1].Attributes.Add("style", "display:none");

                        break;
                    case DataControlRowType.DataRow:
                        CheckBox chk = new CheckBox();
                        //e.Row.Cells[1].Visible = false;

                        chk = ((CheckBox)(e.Row.FindControl("chkChange")));
                        chk.Enabled = true;


                        // chk.Attributes.Add("OnClick", @"selectRowChk(" + lblamount.Text + ", this)");
                        break;
                }
            }
            catch (Exception exRecon)
            {
                // Logging.InfoEntry(exRecon.ToString(), menuId, Logging.LogLevel.ERROR);
            }
        }



        protected void gvchangename_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["dt"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["dt1"] = dt;
            BindGridChangeName();
        }

        protected void btnserch_Click(object sender, EventArgs e)
        {
            BindGridChangeNameB();
        }

        //protected void gvchangename_PreRender(object sender, EventArgs e)
        //{
        ////    int iFixedColumn = 1;
        ////    DataTable dt = new DataTable();

        ////    try
        ////    {
        ////        dt = (DataTable)gvchangename.DataSource;

        ////        for (short i = 0; i <= dt.Columns.Count - 1; i++)
        ////        {
        ////            DataColumn col = dt.Columns[i];
        ////            if (col.ColumnName.ToUpper().StartsWith("H_"))
        ////            {
        ////                for (short j = 0; j <= gvchangename.Rows.Count - 1; j++)
        ////                {
        ////                    gvchangename.Rows[j].Cells[i + iFixedColumn].Attributes.Add("style", "display:none");
        ////                }
        ////            }
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        Response.Write(ex.Message);
        ////    }
        //}

        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {
                    TableCellCollection cells = e.Row.Cells;
                    foreach (TableCell cell in cells)
                    {
                        if (cell.Text.ToUpper().StartsWith("H_"))
                        {
                            cell.Attributes.Add("style", "display:none");
                        }
                    }
                }

                switch (e.Row.RowType)
                {
                    case DataControlRowType.Header:
                        ((CheckBox)e.Row.FindControl("chkAll")).Attributes.Add("OnClick", "SelectAll(this.checked)");
                        //e.Row.Cells[1].Visible = false;
                        //e.Row.Cells[1].Attributes.Add("style", "display:none");

                        break;
                    case DataControlRowType.DataRow:
                        CheckBox chk = new CheckBox();
                        //e.Row.Cells[1].Visible = false;
                        chk = ((CheckBox)(e.Row.FindControl("chkChange")));
                        chk.Enabled = true;


                        // chk.Attributes.Add("OnClick", @"selectRowChk(" + lblamount.Text + ", this)");
                        break;
                }
            }
            catch (Exception exRecon)
            {
                // Logging.InfoEntry(exRecon.ToString(), menuId, Logging.LogLevel.ERROR);
            }
        }

        int GetColumnIndexByName(GridViewRow row, string columnName)
        {
            int columnIndex = 0;
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.ContainingField is BoundField)
                    if (((BoundField)cell.ContainingField).DataField.Equals(columnName))
                        break;
                columnIndex++; // keep adding 1 while we don't have the correct name
            }
            return columnIndex;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (Session["user_id"] != null)
            {
                string user_id1 = Session["user_id"].ToString();
                //objgeneral_registration.user_id = Convert.ToInt32(user_id1);
            }

            Bulk_Update();

            
        }
        protected void Bulk_Update()
        {
            try
            {
                
                foreach (GridViewRow row in gvchangename.Rows)
                {
                 
                    CheckBox chkRow = (CheckBox)row.FindControl("chkChange");
                    bool isSelected = (row.FindControl("chkChange") as CheckBox).Checked;
                    if (chkRow.Checked || isSelected)
                    {
                        //string nowDate = DateTime.Now.AddDays(365).ToString();                       
                        DropDownList ddlapprovestatus = row.FindControl("ddlapprovestatus") as DropDownList;
                        string auth = ddlapprovestatus.SelectedItem.Text;
                        TextBox reason = (TextBox)row.FindControl("txtrejectreason");

                        string res = reason.Text; 
                         Label cnid = (Label)row.FindControl("lblcnid");
                        int cnid1 = Convert.ToInt32(cnid.Text);
                        string dateCreated = DateTime.Now.ToShortDateString();
                        string user_id1 = Session["user_id"].ToString();
                        string updtQuery = "update tbl_change_name set Authorize='" + auth + "'," +
                            "reject_reson='" + res + "'," +
                            " creatredate ='" + dateCreated + "' " +
                            "where cn_id='" + cnid1 + "'";
                        string consString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                        //using (SqlConnection con = new SqlConnection(consString))
                        using (SqlConnection UpdtCon = new SqlConnection(consString))
                        using (SqlCommand UpdtCmd = new SqlCommand(updtQuery, UpdtCon))
                        {
                            UpdtCon.Open();
                            int i = UpdtCmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                //string message = "Approval/Rejection Done.";
                                //script += message;
                                //script += "')};";
                                //ClientScript.RegisterStartupScript(this.GetType(), "", script, true);
                                Response.Write("<script>alert('Detail Updated Successfull');</script>");

                                Bulk_UpdateMain();

                            }
                        }
                    }
                }

               
                gvchangename.DataSource = "";
                gvchangename.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message.ToString()) + "')</script>");
            }

        }


        public void Bulk_UpdateMain()
        {
            Label userid = (Label)FindControl("lbluserid");
            int userid1 = Convert.ToInt32(userid.Text);
           Label newname = (Label)FindControl("lblnewname");
            string newnames = newname.Text;
        // string user_id2 = session["user_id"].tostring();
           string updtquery = "update user set name='" + newnames + "'," +
                "where user_id='" + userid1 + "'";
            string consString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(consString))
            using (SqlConnection UpdtCon = new SqlConnection(consString))
            using (SqlCommand UpdtCmd = new SqlCommand(updtquery, UpdtCon))
            {
                UpdtCon.Open();
                int i = UpdtCmd.ExecuteNonQuery();
                if (i > 0)
                {
                    //string message = "approval/rejection done.";
                    //script += message;
                    //script += "')};";
                    //clientscript.registerstartupscript(this.gettype(), "", script, true);
                    Response.Write("<script>alert('detail updated successfull');</script>");


                }
            }
        }

        protected void lnkDownloadDoc1_Click1(object sender, EventArgs e)
        {

        }

        protected void lnkDownloadDoc2_Click1(object sender, EventArgs e)
        {

        }

        protected void lnkDownloadDoc1_Click2(object sender, EventArgs e)
        {

        }

        protected void lnkDownloadDoc2_Click2(object sender, EventArgs e)
        {

        }

        protected void lnkDownloadDoc1_Click3(object sender, EventArgs e)
        {

        }

        protected void lnkDownloadDoc2_Click3(object sender, EventArgs e)
        {

        }

        protected void lnkDownloadDoc1_Click4(object sender, EventArgs e)
        {

        }

        protected void lnkDownloadDoc2_Click4(object sender, EventArgs e)
        {

        }

        protected void lnkDownloadAddressDoc1_Click(object sender, EventArgs e)
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

        protected void lnkDownloadMbrnameDoc1_Click(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from tbl_membername_correction where mbr_id=@mbr_id";
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

        protected void lnkDownloadAddmbrDoc1_Click(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from tbl_membername_correction where addmbr_id=@addmbr_id";
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

        protected void lnkDownloadRemovembrDoc1_Click(object sender, EventArgs e)
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
    }

}