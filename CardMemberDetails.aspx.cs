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

namespace e_ration_card.Master
{
    public partial class CardMemberDetails : System.Web.UI.Page
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



            int userid1=Convert.ToInt32(Session["user_id"].ToString());


            string strSQ1 = "select mbr_name MemberName,status Status from tbl_member_list where user_id='" + userid1 + "' ";
            DataSet ds1 = new DataSet();
            ds1 = objclsDbConnector.GetDataSet(strSQ1);

            if(!IsPostBack)
            {
                gvmemberlist.DataSource = ds1;
                gvmemberlist.DataBind();
            }

            if (Session["user_id"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {

            }

            if (Session["name"] != null)
            {
                Label lblhname = this.Master.FindControl("lblhname") as Label;
                lblhname.Text = Session["name"].ToString();
            }
            if (Session["constituency"] != null)
            {
                Label lblconstiuency = this.Master.FindControl("lblconstiuency") as Label;
                lblconstiuency.Text = Session["constituency"].ToString();
            }
        }
    }
}