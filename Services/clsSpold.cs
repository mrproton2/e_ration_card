using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace e_ration_card.Services
{
    public class clsSpold
    {

        public enum ParameterType
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


        public class clsCallSP : MarshalByRefObject
        {
            public string prmName
            { get; set; }

            public ParameterType prmType
            { get; set; }

            public object prmValue
            { get; set; }

            public ParameterDirection prmDirection
            { get; set; }

            public clsCallSP(string pName, ParameterType pType, object pValue, ParameterDirection pDirection)
            {
                prmName = pName;
                prmValue = pValue;
                prmDirection = pDirection;

                switch (pType)
                {
                    case ParameterType.CHAR:
                        prmType = ParameterType.CHAR;
                        break;

                    case ParameterType.VARCHAR:
                        prmType = ParameterType.VARCHAR;
                        break;

                    case ParameterType.NVARCHAR:
                        prmType = ParameterType.NVARCHAR;
                        break;
                    case ParameterType.CLOB:
                        prmType = ParameterType.CLOB;
                        break;
                    case ParameterType.DATETIME:
                        prmType = ParameterType.DATETIME;
                        break;

                    case ParameterType.NUMBER:
                        prmType = ParameterType.NUMBER;
                        break;

                    case ParameterType.CURSOR:
                        prmType = ParameterType.CURSOR;
                        break;

                    case ParameterType.TIMESTAMP:
                        prmType = ParameterType.TIMESTAMP;
                        break;


                }
            }
        }
    }
}