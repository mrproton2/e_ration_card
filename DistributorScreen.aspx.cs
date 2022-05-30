using e_ration_card.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using e_ration_card.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace e_ration_card.Master
{
    public partial class DistributorScreen : System.Web.UI.Page
    {
        distribution_details objdistribution_Details = new distribution_details();
        clsDbConnector objclsDbConnector = new clsDbConnector();
        clsDistribution objclsDistribution = new clsDistribution();
        clsdd_cereals_data clsdd_Cereals_Data = new clsdd_cereals_data();

        protected void Page_Load(object sender, EventArgs e)
       {
            string au = ddlactivemember.SelectedValue;
            if ((txtrationcardno.Value.Length>0)&& (ddlactivemember.SelectedValue==""))
            {
                string authenticate = ddlactivemember.SelectedValue;
                BindActiveMBR();          
            }
            


                
           
            
           detailDiv.Visible = false;
            if (ViewState["Data"] != null)
            {
                detailDiv.Visible = true;
            }
            else
            {
               detailDiv.Visible = false;
            }

                lbldatetime.Text = DateTime.Now.ToString();
            FetchData();

            if (Session["user_id"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else if(Session["kono"] == null)
            {
                Response.Write("<script>alert('Please update Kotedar number');</script>");
                Response.Redirect("DistributorProfile.aspx");
                Response.Write("<script>alert('Please update Kotedar number');</script>");
            }
            else
            {

            }
            //if (IsPostBack)
            //{
            //    objdistribution_Details.Authenticated_mbr = ddlactivemember.SelectedItem.Text;


            //}

          
        }

        public void btnserch_Click(object sender, EventArgs e)
        {

        
            string userid = "";
            clsDbConnector objclsDbConnector = new clsDbConnector();
            //string user_id = Session["user_id"].ToString();

            string rationcard = txtrationcardno.Value;
            string strSQ5 = @"select general_id,user_id from tbl_general_registration where rationcard_no='" + rationcard + "'";
            DataSet dsActive1 = new DataSet();
            dsActive1 = objclsDbConnector.GetDataSet(strSQ5);
            if (dsActive1.Tables[0].Rows.Count > 0)
            {
                lblgeneralid.Text = dsActive1.Tables[0].Rows[0]["general_id"].ToString();
                 userid = dsActive1.Tables[0].Rows[0]["user_id"].ToString();
            }

          
            //string user_id = Session["user_id"].ToString();
            ////string rationcard = txtrationcardno.Value;
            //string strSQ = "select A.rationcard_no,A.card_holder_name,A.pancard_no,A.[addresss],B.mbr_name Member_Name,b.relation,C.name " +
            //    "from tbl_general_registration A " +
            //    "inner join tbl_member_list B " +
            //    "on A.user_id = B.user_id " +
            //    "inner join users C " +
            //    "on B.user_id = C.user_id " +
            //    "where[status] = 'Active' And A.rationcard_no ='" + rationcard + "'";
            //DataSet dsActive = new DataSet();
            //dsActive = objclsDbConnector.GetDataSet(strSQ);
            //if (dsActive.Tables[0].Rows.Count > 0)
            //{
               
            //        ddlactivemember.DataSource = dsActive.Tables[0];
            //        ddlactivemember.DataBind();
                
            //    //detailDiv.Visible = true;
            //    lblchn.Text= dsActive.Tables[0].Rows[0]["name"].ToString();
               
            //}



            string strSQInActive = "select A.rationcard_no,A.card_holder_name,A.pancard_no,A.[addresss],B.mbr_name Member_Name,b.relation " +
                "from tbl_general_registration A " +
                "inner join tbl_member_list B " +
                 "on A.user_id = B.user_id " +
                "where[status] = 'InActive' And B.user_id = '" + userid + "'And A.rationcard_no ='" + rationcard + "'";
            DataSet dsInActive = new DataSet();
            dsInActive = objclsDbConnector.GetDataSet(strSQInActive);
            if (dsInActive.Tables[0].Rows.Count > 0)
            {
               
                    ddlinactivemember.DataSource = dsInActive.Tables[0];
                    ddlinactivemember.DataBind();
              
                //detailDiv.Visible = true;
            }
            
            string strSQLCount = "select count(1)" +
               "from tbl_general_registration A " +
               "inner join tbl_member_list B " +
               "on A.user_id = B.user_id " +
               "where[status] = 'Active' And B.user_id = '" + userid + "'And A.rationcard_no ='" + rationcard + "'";
            DataSet dsActiveCount = new DataSet();
            dsActiveCount = objclsDbConnector.GetDataSet(strSQLCount);
            string activecount = dsActiveCount.Tables[0].Rows[0]["column1"].ToString();
            lblmember.Text = activecount;
            int checkactive = Convert.ToInt32(activecount)+1;
            lblmember.Text = Convert.ToString(checkactive);
            if (checkactive >= 1)
            {
                detailDiv.Visible = true;
                
                //int activecount1 = Convert.ToInt32(activecount);
            }

            string strSQLCount1 = "select count(1)" +
              "from tbl_general_registration where rationcard_no ='" + rationcard + "'";
            DataSet dsRationCard = new DataSet();
            dsRationCard = objclsDbConnector.GetDataSet(strSQLCount1);
            string rationcardcount = dsRationCard.Tables[0].Rows[0]["column1"].ToString();
            //lblmember.Text = activecount;
            int checkactive1 = Convert.ToInt32(rationcardcount);
            if (checkactive1 == 0 && checkactive >=1)
            {
                Response.Write("<script>alert('Invalid Rationcard No');</script>");
                //Initalizefield();
                return;
                
            }

            //lblprice.Text = Convert.ToString(Convert.ToInt32(activecount) * 3);
            //lblweight.Text = Convert.ToString(Convert.ToInt32(activecount) * 3);

            string strSQ1 = "select cereals_name Name,per_personunit Units from tbl_default_cereals";
            DataTable dsGrid = new DataTable();
            dsGrid = objclsDbConnector.GetData(strSQ1);
            dsGrid.Columns.AddRange(new DataColumn[2] { new DataColumn("weight", typeof(string)), new DataColumn("price", typeof(string)) });
            
            gvlist.DataSource = dsGrid;
            gvlist.DataBind();          
            
            
            GridBindNew();
        }

        public void GetGeneralid()
        {
            clsDbConnector objclsDbConnector = new clsDbConnector();
            //string user_id = Session["user_id"].ToString();

            string rationcard = txtrationcardno.Value;
            string strSQ = @"select general_id,user_id from tbl_general_registration where rationcard_no='" + rationcard + "'";         
            DataSet dsActive = new DataSet();
            dsActive = objclsDbConnector.GetDataSet(strSQ);
            if (dsActive.Tables[0].Rows.Count > 0)
            {
              lblgeneralid.Text= dsActive.Tables[0].Rows[0]["general_id"].ToString();
              string userid= dsActive.Tables[0].Rows[0]["user_id"].ToString();
            }

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string kotedarno = "";
            string constituency = "";
            string kotedarno1 = "";
            if (Session["user_id"] != null)
            {
                string user_id1 = Session["user_id"].ToString();
                //objgeneral_registration.user_id = Convert.ToInt32(user_id1);
            }
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
                kotedarno= dtTemp.Rows[0]["kotedar_no"].ToString();
                
                Session["kotedarno"] = kotedarno;

                Label lblconstiuency = this.Master.FindControl("lblconstiuency") as Label;
                lblconstiuency.Text = dtTemp.Rows[0]["contituency"].ToString();
                constituency= dtTemp.Rows[0]["contituency"].ToString();

            }

            objdistribution_Details.kotedar_id = Convert.ToInt32(kotedarno);
            objdistribution_Details.kotedar_name = Session["name"].ToString();
            objdistribution_Details.Area = constituency;
            objdistribution_Details.cardholdernme = lblchn.Text;
            objdistribution_Details.Authenticated_mbr = ddlactivemember.SelectedItem.Text;
            objdistribution_Details.rationcard_no = Convert.ToInt32(txtrationcardno.Value);
            objdistribution_Details.total_price = 1;
            objdistribution_Details.total_weight = lblweight.Text;
            objdistribution_Details.Active_mbr = lblmember.Text;
            objdistribution_Details.date_time = DateTime.Now;
            objdistribution_Details.general_id = Convert.ToInt32(lblgeneralid.Text);

            

            Bulk_Insert();

            objclsDistribution.InsertDistributionDetails(objdistribution_Details);

            Response.Write("<script>alert('Dis Detail Updated Successfull');</script>");

            ddlactivemember.Items.Clear();

        }

        protected void gvlist_PreRender(object sender, EventArgs e)
        {
            int iFixedColumn = 1;
            DataTable dt = new DataTable();

            try
            {
                dt = (DataTable)gvlist.DataSource;

                for (short i = 0; i <= dt.Columns.Count - 1; i++)
                {
                    DataColumn col = dt.Columns[i];
                    if (col.ColumnName.ToUpper().StartsWith("H_"))
                    {
                        for (short j = 0; j <= gvlist.Rows.Count - 1; j++)
                        {
                            gvlist.Rows[j].Cells[i + iFixedColumn].Attributes.Add("style", "display:none");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
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

                //if (e.Row.RowType == DataControlRowType.DataRow)
                //{
                //    //decimal mycolumn = 7.50; //i believe hours value should be decimal or int
                //    Label member = (Label)e.Row.FindControl("acm");
                //    member.Text = lblmember.Text;
                //}

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

                        //decimal mycolumn = 7.50; //i believe hours value should be decimal or int
                        string mbr=lblmember.Text;

                        //string unitperperson = e.Row.Cells[2].Text; 
                        Label units = (Label)e.Row.FindControl("units");
                        int unit1 = Convert.ToInt32(units.Text);
                        //units.Text = Convert.ToString(unit1);

                        Label name = (Label)e.Row.FindControl("name");
                        string name1 = name.Text;

                        Label weight = (Label)e.Row.FindControl("acm");
                        int weightcal = Convert.ToInt32(mbr) * Convert.ToInt32(unit1);
                        weight.Text = Convert.ToString(weightcal);

                        int priceperunit = 0;
                        string unittype = string.Empty;

                        if (name1 == "Wheat")
                        {
                            priceperunit = 2;
                            unittype = "Kg";
                        }
                        if (name1 == "Rice")
                        {
                            priceperunit = 3;
                            unittype = "Kg";
                        }
                        if (name1 == "Oil")
                        {
                            priceperunit = 120;
                            unittype = "Liter";
                        }
                        if (name1 == "Gram")
                        {
                            priceperunit = 24;
                            unittype = "Kg";
                        }
                        if (name1 == "Suger")
                        {
                            priceperunit = 20;
                            unittype = "Kg";
                        }
                        if (name1 == "Salt")
                        {
                            priceperunit = 5;
                            unittype = "Kg";
                        }



                        Label unitsign = (Label)e.Row.FindControl("unitsign");
                        unitsign.Text = Convert.ToString(unittype);

                        string tweight = e.Row.Cells[4].Text.ToString();
                        //string tweight11 = e.Row.Cells[2].Text.ToString();

                        
                      
                        int pricecal = Convert.ToInt32(priceperunit) * Convert.ToInt32(weight.Text);
                        Label price = (Label)e.Row.FindControl("price");                       
                        price.Text = Convert.ToString(pricecal);

                        
                        
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


        protected void Bulk_Insert()
        {
            DataTable dt = new DataTable();
            DataRow dr;       
            dt.Columns.Add(new System.Data.DataColumn("name", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("units", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("weight", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("price", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("generalid", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("kotedarno", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("kotedarname", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("currentdate", typeof(string)));
            
            foreach (GridViewRow row in gvlist.Rows)
            {
                if ((row.FindControl("chkChange") as CheckBox).Checked)
                {
                    Label name = (Label)row.FindControl("name");
                    Label unit = (Label)row.FindControl("units");
                    Label weight = (Label)row.FindControl("acm");
                    Label price = (Label)row.FindControl("price");
                    int general = Convert.ToInt32(lblgeneralid.Text);
                    int kotedarno = Convert.ToInt32(Session["kotedarno"].ToString());
                    string kotedarname = Session["name"].ToString();
                    string currentdate = lbldatetime.Text;
                    dr = dt.NewRow();

                    dr[0] = name.Text;
                    dr[1] = unit.Text;
                    dr[2] = weight.Text;
                    dr[3] = price.Text;
                    dr[4] = general;
                    dr[5] = kotedarno;
                    dr[6] = kotedarname;
                    dr[7] = currentdate;

                    dt.Rows.Add(dr);
                   
                }
           

            }
            if (dt.Rows.Count > 0)
            {
                string consString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.tbl_dd_cerealsdata";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        //sqlBulkCopy.ColumnMappings.Add("Id", "CustomerId");
                        sqlBulkCopy.ColumnMappings.Add("Name", "cereals_name");
                        sqlBulkCopy.ColumnMappings.Add("units", "per_personunit");
                        sqlBulkCopy.ColumnMappings.Add("weight", "weight_individual");
                        sqlBulkCopy.ColumnMappings.Add("price", "price_individual");
                        sqlBulkCopy.ColumnMappings.Add("generalid", "general_id");
                        sqlBulkCopy.ColumnMappings.Add("kotedarno", "kotedar_no");
                        sqlBulkCopy.ColumnMappings.Add("kotedarname", "kotedar_name");
                        sqlBulkCopy.ColumnMappings.Add("currentdate", "curr_date");
                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }
            }
        }

        protected void GridBindNew()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("name", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("units", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("weight", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("price", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("generalid", typeof(int)));
            int m = 0;
            int i = 0;
            foreach (GridViewRow row in gvlist.Rows)
            {
                if ((row.FindControl("chkChange") as CheckBox).Checked)
                {
                    Label name = (Label)row.FindControl("name");
                    Label unit = (Label)row.FindControl("units");
                    Label weight = (Label)row.FindControl("acm");
                    Label price = (Label)row.FindControl("price");
                    int general = Convert.ToInt32(lblgeneralid.Text);


                    dr = dt.NewRow();
                    dr[0] = name.Text;
                    dr[1] = unit.Text;
                    dr[2] = weight.Text;
                    dr[3] = price.Text;
                    dr[4] = general;

                    dt.Rows.Add(dr);
                  

                    gvlist.DataSource = dt;
                    gvlist.DataBind();
                    m = m + int.Parse(price.Text);
                    i = i + int.Parse(weight.Text);
                }

            }
            lblprice.Text = Convert.ToString(m) + " ₹";
            lblweight.Text = Convert.ToString(i);

        }
        protected void btnclear_Click(object sender, EventArgs e)
        {
            detailDiv.Visible = false;
            txtrationcardno.Value = "";
            lblchn.Text = "";
            lbldatetime.Text = "";
            lblgeneralid.Text = "";
            lblmember.Text = "";
            lblprice.Text = "";
            lblweight.Text = "";
            ddlactivemember.SelectedIndex = 0;
            ddlinactivemember.SelectedIndex = 0;
            gvlist.DataSource = null;
            //divrecord.visible = false;



        }

        public void Initalizefield()
        {
            detailDiv.Visible = false;
            //txtrationcardno.Value = "";
            lblchn.Text = "";
            lbldatetime.Text = "";
            lblgeneralid.Text = "";
            lblmember.Text = "";
            lblprice.Text = "";
            lblweight.Text = "";
            //ddlactivemember.SelectedIndex = 0;
            //ddlinactivemember.SelectedIndex = 0;
            gvlist.DataSource = null;
            //divrecord.visible = false;
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

                Session["kono"] = dtTemp.Rows[0]["kotedar_no"].ToString();

            }

        }

        public void BindActiveMBR()
        {

            string user_id = Session["user_id"].ToString();
            string rationcard = txtrationcardno.Value;
            string strSQ = "select A.rationcard_no,A.card_holder_name,A.pancard_no,A.[addresss],B.mbr_name Member_Name,b.relation,C.name " +
                "from tbl_general_registration A " +
                "inner join tbl_member_list B " +
                "on A.user_id = B.user_id " +
                "inner join users C " +
                "on B.user_id = C.user_id " +
                "where[status] = 'Active' And A.rationcard_no ='" + rationcard + "'";
            DataSet dsActive = new DataSet();
            dsActive = objclsDbConnector.GetDataSet(strSQ);
            if (dsActive.Tables[0].Rows.Count > 0)
            {

                ddlactivemember.DataSource = dsActive.Tables[0];
                ddlactivemember.DataBind();

                //detailDiv.Visible = true;
                lblchn.Text = dsActive.Tables[0].Rows[0]["name"].ToString();

            }
        }
    }
}