using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLObjectBackup
{
    public class SqlDatabaseException : Exception
    {
        public SqlDatabaseException(string message) : base(message) { }
    }
}
