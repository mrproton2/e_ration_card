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

namespace e_ration_card.Master
{
    public partial class DistributorScreen : System.Web.UI.Page
    {
        distribution_details objdistribution_Details = new distribution_details();
        clsDbConnector objclsDbConnector = new clsDbConnector();
        protected void Page_Load(object sender, EventArgs e)
        {
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
            if (Session["user_id"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
               
            }


        }

        protected void btnserch_Click(object sender, EventArgs e)
        {
            clsDbConnector objclsDbConnector = new clsDbConnector();
            string user_id = Session["user_id"].ToString();
            string rationcard = txtrationcardno.Value;
            string strSQ = "select A.rationcard_no,A.card_holder_name,A.pancard_no,A.[addresss],B.mbr_name Member_Name,b.relation " +
                "from tbl_general_registration A " +
                "inner join tbl_member_list B " +
                "on A.general_id = B.general_id " +
                "where[status] = 'Active' And B.user_id = '" + user_id + "'And A.rationcard_no ='" + rationcard + "'";
            DataSet dsActive = new DataSet();
            dsActive = objclsDbConnector.GetDataSet(strSQ);
            if (dsActive.Tables[0].Rows.Count > 0)
            {
                ddlactivemember.DataSource = dsActive.Tables[0];
                ddlactivemember.DataBind();
                detailDiv.Visible = true;
                lblchn.Text= dsActive.Tables[0].Rows[0]["card_holder_name"].ToString();
                ViewState["Data"] = dsActive;
            }
            string strSQInActive = "select A.rationcard_no,A.card_holder_name,A.pancard_no,A.[addresss],B.mbr_name Member_Name,b.relation " +
                "from tbl_general_registration A " +
                "inner join tbl_member_list B " +
                "on A.general_id = B.general_id " +
                "where[status] = 'InActive' And B.user_id = '" + user_id + "'And A.rationcard_no ='" + rationcard + "'";
            DataSet dsInActive = new DataSet();
            dsInActive = objclsDbConnector.GetDataSet(strSQInActive);
            if (dsInActive.Tables[0].Rows.Count > 0)
            {               
                ddlinactivemember.DataSource = dsInActive.Tables[0];
                ddlinactivemember.DataBind();
                detailDiv.Visible = true;
            }
            
            string strSQLCount = "select count(1)" +
               "from tbl_general_registration A " +
               "inner join tbl_member_list B " +
               "on A.general_id = B.general_id " +
               "where[status] = 'Active' And B.user_id = '" + user_id + "'And A.rationcard_no ='" + rationcard + "'";
            DataSet dsActiveCount = new DataSet();
            dsActiveCount = objclsDbConnector.GetDataSet(strSQLCount);
            string activecount = dsActiveCount.Tables[0].Rows[0]["column1"].ToString();
            lblmember.Text = activecount;
            lblprice.Text = Convert.ToString(Convert.ToInt32(activecount) * 3);
            lblweight.Text = Convert.ToString(Convert.ToInt32(activecount) * 3);
        }

        protected void LeftClick(object sender, EventArgs e)
        {
            //List will hold items to be removed.
            List<ListItem> removedItems = new List<ListItem>();

            //Loop and transfer the Items to Destination ListBox.
            foreach (ListItem item in lstRight.Items)
            {
                if (item.Selected)
                {
                    item.Selected = false;
                    lstLeft.Items.Add(item);
                    removedItems.Add(item);
                }
                else
                {
                    string msg = "Please select at least one from box";
                    
                  // ClientScript.RegisterClientScriptBlock(GetType(), "alert", msg, true /* addScriptTags */);
                   ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select at least one from box');", true);
                }
            }

            //Loop and remove the Items from the Source ListBox.
            foreach (ListItem item in removedItems)
            {
                lstRight.Items.Remove(item);
            }
        }

        protected void RightClick(object sender, EventArgs e)
        {
            //List will hold items to be removed.
            List<ListItem> removedItems = new List<ListItem>();

            //Loop and transfer the Items to Destination ListBox.
            foreach (ListItem item in lstLeft.Items)
            {
                if (item.Selected)
                {
                    item.Selected = false;
                    lstRight.Items.Add(item);
                    removedItems.Add(item);
                }
                else
                {
                    string msg = "Please select at least one from box";

                   // ClientScript.RegisterClientScriptBlock(GetType(), "alert", msg, true /* addScriptTags */);
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select at least one from box');", true);
                }
            }

            //Loop and remove the Items from the Source ListBox.
            foreach (ListItem item in removedItems)
            {
                lstLeft.Items.Remove(item);
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (Session["user_id"] != null)
            {
                string user_id1 = Session["user_id"].ToString();
                //objgeneral_registration.user_id = Convert.ToInt32(user_id1);
            }
            
            objdistribution_Details.kotedar_id = 1;
            objdistribution_Details.kotedar_name = "abhis";
            objdistribution_Details.Area = "sangharsh nagar";
            objdistribution_Details.cardholdernme = lblchn.Text;
            objdistribution_Details.Authenticated_mbr = ddlactivemember.SelectedValue;
            objdistribution_Details.rationcard_no = Convert.ToInt32(txtrationcardno.Value);
            objdistribution_Details.total_price = Convert.ToInt32(lblprice.Text);
            objdistribution_Details.total_weight = lblweight.Text;
            objdistribution_Details.Active_mbr = lblmember.Text;
            objdistribution_Details.date_time = DateTime.Now;



            objdistribution_Details.InsertDistributionDetails(objdistribution_Details);

            Response.Write("<script>alert('General Detail Updated Successfull');</script>");
        }
    }
}