using e_ration_card.Models;
using e_ration_card.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_ration_card
{
    public partial class rptDistributionData : System.Web.UI.Page
    {
        changename objchangename = new changename();
        clsRationCardUpdation objclsRationCardUpdation = new clsRationCardUpdation();
        distribution_details objdistribution_Details = new distribution_details();
        clsDbConnector objclsDbConnector = new clsDbConnector();
        clsDistribution objclsDistribution = new clsDistribution();

     
        protected void Page_Load(object sender, EventArgs e)
        {
            clsDbConnector objclsDbConnector = new clsDbConnector();
            string strSQ = "SELECT state_id,state_name from tbl_state";
            DataSet ds = new DataSet();
            ds = objclsDbConnector.GetDataSet(strSQ);

            string strSQ1 = "SELECT consitiuency_name from tbl_consitiuency";
            DataSet ds1 = new DataSet();
            ds1 = objclsDbConnector.GetDataSet(strSQ1);
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

            }

           

            BindGridAll();
        }

        private void BindGridAll()
        {
            if(txtkotedarno.Text=="")
            {
                txtkotedarno.Text = null;
            }
            if (txtration.Text == "")
            {
                txtration.Text = null;
            }

            string strSQ1 = "select A.rationcard_no RationCardNo,A.card_holder_name CardHolderName,A.pancard_no PanNo,A.states 'StateName******',A.district DistrictName," +
                "A.constituency Constituency,A.typeof_rationcard RationCardType,A.aadharcard_no AadharNO,B.cereals_name CerealsName,B.per_personunit UnitPerPerson,B.weight_individual Weight," +
                "B.price_individual Price,B.kotedar_name KotedarName,B.kotedar_no KotedarNo,B.curr_date DateTime " +
                "from tbl_general_registration A " +
                "inner join tbl_dd_cerealsdata B " +
                "on A.general_id = B.general_id " + 
                "where states='"+ ddlstate.SelectedItem.Text + "' And district='"+ ddldistrict.SelectedValue + "' And constituency='" + ddlconstituency.Text + "' or rationcard_no='" + txtration.Text+ "' or kotedar_no='" + txtkotedarno.Text+"'";




                DataTable dsGrid = new DataTable();
                dsGrid = objclsDbConnector.GetData(strSQ1);
                gvchangename.DataSource = dsGrid;
                gvchangename.DataBind();


        }

        //private void BindGridChangeNameB()
        //{

        //        string strSQ1 = "select b.cn_id,a.card_holder_name,a.constituency,a.rationcard_no,a.states,district," +
        //            "b.old_name,b.new_name,cn_doc1_name,cn_doc2_name," +
        //            "Authorize,b.reject_reson " +
        //            "from tbl_general_registration a " +
        //            "inner join tbl_change_name b " +
        //            "on a.user_id = b.user_id where a.constituency='" + txtconstituency.Text + "'";
        //        DataTable dsGrid = new DataTable();
        //        dsGrid = objclsDbConnector.GetData(strSQ1);
        //        gvchangename.DataSource = dsGrid;
        //        gvchangename.DataBind();






        //}

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsDbConnector objclsDbConnector = new clsDbConnector();
            string strSQ = "SELECT district_name from tbl_district where state_id='" + ddlstate.SelectedValue.Trim() + "'";
            DataSet ds = new DataSet();
            ds = objclsDbConnector.GetDataSet(strSQ);
            ddldistrict.DataSource = ds.Tables[0];
            ddldistrict.DataBind();
        }

        protected void gvchangename_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvchangename.PageIndex = e.NewPageIndex;
            this.BindGridAll();

        }

        protected void btnserch_Click(object sender, EventArgs e)
        {
            BindGridAll();
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            ddlstate.SelectedIndex = 0;
            ddldistrict.SelectedIndex = 0;
            ddlconstituency.SelectedIndex = 0;
            txtration.Text = "";
            txtkotedarno.Text = "";
            gvchangename.DataSource = null;
            gvchangename.DataBind();


        }
    }
}