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
    public partial class rptDistribution : System.Web.UI.Page
    {
        general_registration objgeneral_registration = new general_registration();

        clsGeneral_Logic objclsGeneral_Logic = new clsGeneral_Logic();
        kotedar_registration objkotedar_registration = new kotedar_registration();
        clsDbConnector objclsDbConnector = new clsDbConnector();
        clsKotedarUpdation_logic objclsKotedarUpdation_Logic = new clsKotedarUpdation_logic();
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


            }
            FetchData();
            BindGridAll();

        }

        private void BindGridAll()
        {
            string kono = "";
            if (Session["kono"] != null)
            {
                kono = Session["kono"].ToString();
            }

            string userid = Session["user_id"].ToString();
            string strSQ1 = "select A.rationcard_no RationCardNo," +
                "A.typeof_rationcard RationCardType,B.cereals_name CerealsName,B.per_personunit UnitPerPerson,B.weight_individual Weight," +
                "B.price_individual Price,B.kotedar_name KotedarName,Convert(varchar, B.curr_date,105) Dates " +
                "from tbl_general_registration A " +
                "inner join tbl_dd_cerealsdata B " +
                "on A.general_id = B.general_id " +
                "where B.kotedar_no='" + kono + "'" +
                "or A.rationcard_no='" + txtration.Text + "'"+
                "or B.curr_date='" + txtdate.Value + "'";






         DataTable dsGrid = new DataTable();
            dsGrid = objclsDbConnector.GetData(strSQ1);
            gvlist.DataSource = dsGrid;
            gvlist.DataBind();


        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        protected void btnclear_Click(object sender, EventArgs e)
        {
            
            txtration.Text = "";
            txtdate.Value = "";
            gvlist.DataSource = null;
            gvlist.DataBind();

        }

        protected void btnserch_Click(object sender, EventArgs e)
        {
            BindGridAll();
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

                Session["kono"]= dtTemp.Rows[0]["kotedar_no"].ToString();

            }

        }
    }
}