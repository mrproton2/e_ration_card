
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using e_ration_card.Models;

namespace e_ration_card.Services
{
    public class clsuserlogin_logic
    {
        public clsDbConnector ObjdbConnector = new clsDbConnector();
        users objusers = new users();
        public clsuserlogin_logic()
        {
            this.ObjdbConnector = new clsDbConnector();
        }

       
        public DataSet CheckLogin(string username,string pass)
        {
            string strSQL;
            strSQL = "SELECT * From users";
            strSQL += " where user_name='" + username + "'";
            strSQL += " and user_password='" + pass + "'";
            DataSet dsTemp;
            dsTemp = ObjdbConnector.GetDataSet(strSQL);
            return dsTemp;
        }

        //public bool CheckOldPassword()
        //{
        //    string strSQL;
        //    strSQL = "SELECT Password from tbl_Users";
        //    strSQL += " where User_Id='" + _UserId + "'";
        //    strSQL += " and Password='" + _Password + "'";
        //    DataSet dsTemp;
        //    dsTemp = ObjdbConnector.GetDataSet(strSQL);

        //    if (dsTemp.Tables[0].Rows.Count > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public void ChangeUserPassword()
        //{
        //    string strSQL1;
        //    strSQL1 = "update tbl_Users set";
        //    strSQL1 += " Password='" + _Password + "'";
        //    strSQL1 += " where User_Id='" + pro_UserId + "'";
        //    ObjdbConnector.runSQL(strSQL1);
        //}
    }
}