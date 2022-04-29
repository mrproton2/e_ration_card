using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using e_ration_card.Services;
using static e_ration_card.Models.clsSP;
using e_ration_card.Models;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;



namespace e_ration_card.Services
{
    public class clsDbConnector: System.Web.UI.Page
    {
        private SqlConnection dbConnection;
        private SqlDataAdapter dbAdapter;
        private SqlCommand cmd;

       // clsSpold objclsSp = new clsSpold();
        clsSP objclsSP = new clsSP();
        public clsDbConnector()
        {
            this.dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);
            //Or
            //this.dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"]);
            if (dbConnection.State == ConnectionState.Closed)
            {
                try
                {
                    if (dbConnection.State == ConnectionState.Broken)
                    {
                        dbConnection.Close();
                        dbConnection.Open();
                    }
                }
                catch (Exception err)
                {
                    throw err;
                }
            }
            if (dbConnection.State == ConnectionState.Broken)
            {
                dbConnection.Close();
                dbConnection.Open();
            }
            cmd = new SqlCommand();
        }


        public DataSet GetDataSet(string strSQL)
        {
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }
            if (dbConnection.State == ConnectionState.Broken)
            {
                dbConnection.Close();
                dbConnection.Open();
            }
            dbAdapter = new SqlDataAdapter(strSQL, dbConnection);
            DataSet dsTemp = new DataSet();
            dbAdapter.Fill(dsTemp);
            dbConnection.Close();
            return dsTemp;
        }

        public DataTable GetData(string strSQL)
        {
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }
            if (dbConnection.State == ConnectionState.Broken)
            {
                dbConnection.Close();
                dbConnection.Open();
            }
            dbAdapter = new SqlDataAdapter(strSQL, dbConnection);
            DataTable dsTemp = new DataTable();
            dbAdapter.Fill(dsTemp);
            dbConnection.Close();
            return dsTemp;
        }

        public SqlDataReader getSqlDataReader(string strSQL)
        {
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }
            if (dbConnection.State == ConnectionState.Broken)
            {
                dbConnection.Close();
                dbConnection.Open();
            }
            cmd.Connection = dbConnection;
            cmd.CommandText = strSQL;
            return cmd.ExecuteReader();
        }

        public void runSQL(string strSQL)
        {
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }
            else if (dbConnection.State == ConnectionState.Broken)
            {
                dbConnection.Close();
                dbConnection.Open();
            }
            cmd = new SqlCommand(strSQL, dbConnection);
            cmd.ExecuteNonQuery();
            dbConnection.Close();
        }


        //public void RunUSP(string spName, users objusers)
        //{
        //    if (dbConnection.State == ConnectionState.Closed)
        //    {
        //        dbConnection.Open();
        //    }
        //    else if (dbConnection.State == ConnectionState.Broken)
        //    {
        //        dbConnection.Close();
        //        dbConnection.Open();
        //    }
        //    cmd = new SqlCommand(spName, dbConnection);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@date", objusers.user_name);
        //    cmd.Parameters.AddWithValue("@doctor", objusers.user_password);
        //    cmd.Parameters.AddWithValue("@doctor", objusers.user_type);
        //    cmd.Parameters.AddWithValue("@doctor", objusers.mobile_no);
        //    cmd.Parameters.AddWithValue("@doctor", objusers.name);
        //    cmd.ExecuteNonQuery();
        //    dbConnection.Close();
        //    //return;
        //}

        public Boolean BatchTransaction(string[] strSql)
        {

            dbConnection.Open();
            SqlTransaction t;
            SqlCommand dbCommand = new SqlCommand();
            t = dbConnection.BeginTransaction();
            dbCommand.Connection = dbConnection;
            dbCommand.Transaction = t;
            try
            {
                for (int i = 0; i < strSql.Length; i++)
                {
                    if (strSql[i].ToString() == null)
                        break;
                    dbCommand.CommandText = strSql[i].ToString();
                    dbCommand.ExecuteNonQuery();
                }
                //Commit Transactions
                t.Commit();
                t = null;
                dbCommand.Dispose();
                dbConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                //Rollback Transactions
                t.Rollback();
                t = null;
                string str = ex.Message;
                dbCommand.Dispose();
                dbConnection.Close();
                return false;
            }


        }

        //public DataSet FetchFromSP(string storedProcedureName, clsSP[] prmList)
        //{

        //    try
        //    {
        //        if (dbConnection.State == ConnectionState.Closed)
        //        {
        //            dbConnection.Open();
        //        }
        //        if (dbConnection.State == ConnectionState.Broken)
        //        {
        //            dbConnection.Close();
        //            dbConnection.Open();
        //        }
        //        dbAdapter = new SqlDataAdapter(storedProcedureName, dbConnection);
        //        DataSet dsTemp = new DataSet();
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        foreach(clsSP objPrm in prmList)
        //        {
        //            //If parameter direction is output, no need to assign value
        //            if (objPrm.prmDirection == ParameterDirection.Output)
        //                cmd.Parameters.AddWithValue(objPrm.prmName, objPrm.prmType).Direction = objPrm.prmDirection;
        //            else
        //                cmd.Parameters.AddWithValue(objPrm.prmName, objPrm.prmType).Value = objPrm.prmValue;
        //        }
        //        //DataSet ds = new DataSet();
        //        //objCon.Open();
        //        //DataSet dsTemp = new DataSet();
        //        dbAdapter.Fill(dsTemp);
        //        dbConnection.Close();
        //        return dsTemp;


        //    }

        //    catch (Exception ex)
        //    {

        //        if (dbConnection.State == ConnectionState.Open)

        //            dbConnection.Close();

        //        throw ex;
        //    }
        //}

        public void SetValueType(TextType TextAppreance, HtmlInputText field, int maxLength = 500)
        {
            string num = null;
            string amt = null;
            string upp = null;
            string low = null;
            string spl = null;
            string spl1 = null;
            string tel = null;
            string passwrd = null;

            num = "0123456789";
            amt = "0123456789.";
            upp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ.` ";
            low = "abcdefghijklmnopqrstuvwxyz.` ";
            tel = "0123456789()+- ,";
            spl = ",@!#$%&*()_+|:?><./[]\\=-`~";
            spl1 = "@!#.";
            passwrd = "@!#$%&*()_|:?><./;[]\\=+-`~";

            switch (TextAppreance)
            {
                case TextType.RemarksFixedLength:
                    field.Attributes.Add("onkeypress", "var str='" + upp + low + amt + spl + "';ValidateCharactersMultiline(str, event, this, " + maxLength + ")");
                    break;

                case TextType.NumericField:
                    field.Attributes.Add("onkeypress", "var str='" + num + "';ValidateCharacters(str, event)");
                    //field.Attributes.Add("PlaceHolder", "Number Values only");
                    break;
                case TextType.AmountField:
                    //field.Attributes.Add("onkeypress", "var str='" + amt + "';if(str.indexOf(String.fromCharCode(event.keyCode))==-1){event.returnValue = false;}else {var str = this.value.split('.');if(str.length>=2 && event.keyCode==46){event.returnValue=false}}"); 
                    //field.Attributes.Add("PlaceHolder", "Number Values only");
                    field.Attributes.Add("onkeypress", "var str='" + amt + "';if (ValidateCharacters(str, event)){var str = this.value.split('.');if (str.length >= 2 && event.keyCode == 46){if (event.preventDefault != undefined){event.preventDefault();}else{event.returnValue = false;}}}");
                    field.Attributes.Add("onblur", "if(Trim(this.value) != ''){this.value=roundOff(this.value,2);}else{this.value=roundOff(0,2);}");
                    break;
                case TextType.AmountFieldNTSL:
                    //field.Attributes.Add("onkeypress", "var str='" + amt + "';if(str.indexOf(String.fromCharCode(event.keyCode))==-1){event.returnValue = false;}else {var str = this.value.split('.');if(str.length>=2 && event.keyCode==46){event.returnValue=false}}"); 
                    //field.Attributes.Add("PlaceHolder", "Number Values only");
                    field.Attributes.Add("onkeypress", "var str='" + amt + "';if (ValidateCharacters(str, event)){var str = this.value.split('.');if (str.length >= 5 && event.keyCode == 46){if (event.preventDefault != undefined){event.preventDefault();}else{event.returnValue = false;}}}");
                    field.Attributes.Add("onblur", "if(Trim(this.value) != ''){this.value=roundOff(this.value,5);}else{this.value=roundOff(0,5);}");
                    break;
                case TextType.CharacterField:
                    //field.Attributes.Add("PlaceHolder", "Character values only");
                    field.Attributes.Add("onkeypress", "var str='" + upp + low + "';ValidateCharacters(str, event)");
                    break;
                case TextType.AlphNumericField:
                    field.Attributes.Add("onkeypress", "var str='" + upp + low + amt + "';ValidateCharacters(str, event)");
                    break;
                case TextType.TelephoneField:
                    field.Attributes.Add("onkeypress", "var str='" + tel + "';ValidateCharacters(str, event)");
                    break;
                //Case TextType.EmailField 
                case TextType.RemarkField:
                    field.Attributes.Add("onkeypress", "var str='" + upp + low + amt + spl + "';ValidateCharacters(str, event)");
                    break;
                case TextType.RemarkFieldNTSL:
                    field.Attributes.Add("onkeypress", "var str='" + upp + low + amt + spl1 + "';ValidateCharacters(str, event)");
                    break;
                case TextType.UpperCase:
                    break;
                //field.Attributes.Add("onkeypress", "var str='" & upp & "';if(str.indexOf(String.fromCharCode(event.keyCode))==-1){event.returnValue = false;}") 
                case TextType.LowerCase:
                    field.Attributes.Add("onkeypress", "var str='" + low + "';ValidateCharacters(str, event)");
                    break;
                case TextType.DateField:
                    field.Attributes.Add("PlaceHolder", "DD/MM/YYYY");
                    field.Attributes.Add("onkeypress", "CheckDateCharacters(this);");
                    field.Attributes.Add("onblur", "ValidateDate(this);");
                    break;
                case TextType.TimeField:
                    field.Attributes.Add("onkeypress", "CheckTimeCharacters(this);");
                    //field.Attributes.Add("onblur", "ValidateDate(this);");
                    break;
                case TextType.Password:
                    field.Attributes.Add("onkeypress", "var str='" + low + upp + num + passwrd + "';ValidateCharacters(str, event)");
                    break;
                //case TextType.CardNo:
                //    string strSQL = "";

                //    strSQL = "SELECT cardmask_from,cardmask_to,ISCARDMASK_APPLICABLE FROM projectsettings";
                //    System.Data.DataSet ds = oDataSetCreator.GetDataSet(strSQL);
                //    field.Attributes.Add("onkeypress", "var str='" + num + "';ValidateCharacters(str, event)");
                //    //field.Attributes.Add("PlaceHolder", "Enter Card No.");
                //    field.Attributes.Add("autocomplete", "off");
                //    field.Attributes.Add("ondragstart", "return false");
                //    field.Attributes.Add("draggable", "false");

                   

            }

            //if (TextAppreance != TextType.LowerCase)
            //{
            //    field.Attributes.Add("onChange", "this.value = this.value.toUpperCase()");

            //}
        }

        public enum TextType
        {
            NumericField = 1,
            AmountField = 2,
            CharacterField = 3,
            AlphNumericField = 4,
            TelephoneField = 5,
            //EmailField = 6 
            RemarkField = 7,
            UpperCase = 8,
            LowerCase = 9,
            DateField = 10,
            TimeField = 12,
            //DateTimeField = 11 
            Password = 11,
            CardNo = 13,
            RemarksFixedLength = 14,
            RemarkFieldNTSL = 15,
            AmountFieldNTSL = 16
        }

        

    }


}