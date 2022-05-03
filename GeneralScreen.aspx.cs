using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using e_ration_card.Models;
using e_ration_card.Services;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json;


namespace e_ration_card
{
    public partial class GeneralScreen : System.Web.UI.Page
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

            if (Session["user_id"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {

            }
            Label lblhname = this.Master.FindControl("lblhname") as Label;
            lblhname.Text = Session["cardholdername"].ToString();
            Label lblconstiuency = this.Master.FindControl("lblconstiuency") as Label;
            lblconstiuency.Text = Session["constituency"].ToString();
            GetData();
            BindGridAll();
            Authenticatembr();
        }

        public void GetData()
        {

            string userid = Session["user_id"].ToString();
            string strSQL;
            strSQL = "SELECT * from tbl_general_registration where user_id='" + userid + "'";
            DataSet dsTemp = objclsDbConnector.GetDataSet(strSQL);
            DataTable dtTemp = dsTemp.Tables[0];
            if (dtTemp.Rows.Count > 0)
            {
                lblrationca.Text = dtTemp.Rows[0]["rationcard_no"].ToString();
                txtaddress.Value= dtTemp.Rows[0]["addresss"].ToString();
                lblcardtype.Text = dtTemp.Rows[0]["typeof_rationcard"].ToString();
            }

            string strSQLU;
            strSQLU = "SELECT * from users where user_id='" + userid + "'";
            DataSet dsTempU = objclsDbConnector.GetDataSet(strSQLU);
            DataTable dtTempU = dsTempU.Tables[0];
            if (dtTempU.Rows.Count > 0)
            {

                lblmobileno.Text = dtTempU.Rows[0]["mobile"].ToString();
                lblemail.Text = dtTempU.Rows[0]["email"].ToString();
            }
        }

        private void BindGridAll()
        {


            string userid = Session["user_id"].ToString();
            string strSQ1 = "select A.rationcard_no RationCardNo,A.card_holder_name CardHolderName," +
                "A.typeof_rationcard RationCardType,B.cereals_name CerealsName,B.per_personunit UnitPerPerson,B.weight_individual Weight," +
                "B.price_individual Price,B.kotedar_name KotedarName,B.curr_date DateTime " +
                "from tbl_general_registration A " +
                "inner join tbl_dd_cerealsdata B " +
                "on A.general_id = B.general_id " +
                "where A.user_id='" + userid + "'";




            DataTable dsGrid = new DataTable();
            dsGrid = objclsDbConnector.GetData(strSQ1);
            gvchangename.DataSource = dsGrid;
            gvchangename.DataBind();


        }


        private void Authenticatembr()
        {


            string userid = Session["user_id"].ToString();
            string strSQ1 = "select Authenticated_mbr Authentication_Person,date_time Dates,kotedar_name KotdarName " +
                "from tbl_distribution_details " +
                "where rationcard_no='" + lblrationca.Text + "'"; 



            DataTable dsGrid = new DataTable();
            dsGrid = objclsDbConnector.GetData(strSQ1);
            gvlist.DataSource = dsGrid;
            gvlist.DataBind();


        }
        //protected void gvchangename_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvchangename.PageIndex = e.NewPageIndex;
        //    this.BindGridAll();

        //}
    }
}