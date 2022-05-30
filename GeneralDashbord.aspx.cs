using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_ration_card.Master
{
    public partial class GeneralDashbord : System.Web.UI.Page
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
            Label lblhname = this.Master.FindControl("lblhname") as Label;
            lblhname.Text = Session["name"].ToString();
            Label lblconstiuency = this.Master.FindControl("lblconstiuency") as Label;
            lblconstiuency.Text = Session["constituency"].ToString();

        }
    }
}