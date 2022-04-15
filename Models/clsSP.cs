using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace e_ration_card.Models
{
    public enum sqlParameterType
    {
        CHAR,
        VARCHAR,
        NVARCHAR,
        DATETIME,
        NUMBER,
        CURSOR,
        TIMESTAMP,
        CLOB
    }

    public class clsSP: MarshalByRefObject
    {
        public string prmName
        { get; set; }

        public SqlDbType prmType
         { get; set; }

        public object prmValue
        { get; set; }

        public ParameterDirection prmDirection
        { get; set; }

        public void clsSqlSP(string pName, sqlParameterType pType, object pValue, ParameterDirection pDirection)
        {
            prmName = pName;
            prmValue = pValue;
            prmDirection = pDirection;

            switch (pType)
            {
                case sqlParameterType.CHAR:
                    prmType = SqlDbType.Char;
                    break;

                case sqlParameterType.VARCHAR:
                    prmType = SqlDbType.VarChar;
                    break;

                case sqlParameterType.NVARCHAR:
                    prmType = SqlDbType.NVarChar;
                    break;
                case sqlParameterType.CLOB:
                    prmType = SqlDbType.NVarChar;
                    break;
                case sqlParameterType.DATETIME:
                    prmType = SqlDbType.DateTime;
                    break;

                case sqlParameterType.NUMBER:
                    prmType = SqlDbType.Int;
                    break;

                //case sqlParameterType.CURSOR:
                //    prmType = SqlDbType.cur
                //    break;

                case sqlParameterType.TIMESTAMP:
                    prmType = SqlDbType.Timestamp;
                    break;


            }
        }
    }
}