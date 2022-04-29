using e_ration_card.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using e_ration_card.Models;

namespace e_ration_card
{
    public partial class Distributor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user_id"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                
              
            }
            Label lblname = this.Master.FindControl("lblkname") as Label;
            lblname.Text = Session["name"].ToString();
            Label lblkid = this.Master.FindControl("lblkid") as Label;
            lblkid.Text = Session["kotedarid"].ToString();
            Label lblconstiuency = this.Master.FindControl("lblconstiuency") as Label;
            string test = Session["constituency"].ToString();
            lblconstiuency.Text = Session["constituency"].ToString();

        }
    }
}