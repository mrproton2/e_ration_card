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
            BindGridChangeName();

            if (Session["user_id"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {

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
                string strSQ1 = "select b.cn_id,a.card_holder_name,a.constituency,a.rationcard_no,a.states,district," +
                    "b.old_name,b.new_name,cn_doc1_name,cn_doc2_name," +
                    "Authorize,b.reject_reson " +
                    "from tbl_general_registration a " +
                    "inner join tbl_change_name b " +
                    "on a.user_id = b.user_id where a.constituency='" + txtconstituency.Text + "'";
                DataTable dsGrid = new DataTable();
                dsGrid = objclsDbConnector.GetData(strSQ1);
                gvchangename.DataSource = dsGrid;
                gvchangename.DataBind();


            }
            if (ddlcorrectiontype.SelectedValue == "Change Address")
            {
                string strSQ1 = "select * from tbl_change_name where a.constituency='" + txtconstituency.Text + "'";
                DataTable dsGrid = new DataTable();
                dsGrid = objclsDbConnector.GetData(strSQ1);
                gvchangename.DataSource = dsGrid;
                gvchangename.DataBind();


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

        protected void gvchangename_PreRender(object sender, EventArgs e)
        {
        //    int iFixedColumn = 1;
        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        dt = (DataTable)gvchangename.DataSource;

        //        for (short i = 0; i <= dt.Columns.Count - 1; i++)
        //        {
        //            DataColumn col = dt.Columns[i];
        //            if (col.ColumnName.ToUpper().StartsWith("H_"))
        //            {
        //                for (short j = 0; j <= gvchangename.Rows.Count - 1; j++)
        //                {
        //                    gvchangename.Rows[j].Cells[i + iFixedColumn].Attributes.Add("style", "display:none");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        }

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

    }

}