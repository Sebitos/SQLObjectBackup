using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SQLObjectBackup
{
    public class SqlGetDatabases
    {
        public int ObjectId { get; set; }
        public string DatabaseName { get; private set; }

        public SqlGetDatabases(int objectId, string databaseName)
        {
            if (objectId == 0)
                throw new ArgumentException("ObjectID cannot be zero");
            if (string.IsNullOrWhiteSpace(databaseName))
                throw new ArgumentException("Database Name cannot be null or empty");
            
            ObjectId = objectId;
            DatabaseName = databaseName;
         
        }
    }
}
