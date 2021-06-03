using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTIS_Vulcan_ZECT
{
    public class csParameterListType
    {
        private string _Name;
        private SqlDbType _Sqltype;
        private string _Value;

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public SqlDbType Sqltype
        {
            get
            {
                return _Sqltype;
            }
            set
            {
                _Sqltype = value;
            }
        }
        public string Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }

        public csParameterListType(string name__1, SqlDbType sqltype__2, string value__3)
        {
            Name = name__1;
            Sqltype = sqltype__2;
            Value = value__3;
        }
    }
}
