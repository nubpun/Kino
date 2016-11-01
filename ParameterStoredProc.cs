using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class ParameterStoredProc
    {
        public readonly SqlDbType sqlType;
        public readonly string key;
        public readonly object value;
        public ParameterStoredProc(SqlDbType sqlType, string key, object value)
        {
            this.sqlType = sqlType;
            this.key = key;
            this.value = value;
        }
    }
}
