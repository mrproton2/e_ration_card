    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_ration_card
{
    public partial class GovtDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string username = "";
            //string userid = "";
            //Nullable<int> username = null;

            // username = Session["username"].ToString();
            // userid = Session["user_id"].ToString();


            if (Session["user_id"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {

            }
           
        }
    }
}