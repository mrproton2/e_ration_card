using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_ration_card.Master
{
    public partial class Distributor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["user_id"] == null)
            //{
                
            //}
            //else
            //{
            //    string name = Session["user_name"].ToString();
            //    lblkname.Text = name;
            //}
            

        }

      
        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("index.aspx?action=logout");
        }
    }
}