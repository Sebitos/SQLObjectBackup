using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SQLObjectBackup
{
    public class SqlTable
    {
        public int ObjectId { get; set; }
        public string ObjectName { get; private set; }
        public string SchemaName { get; private set; }
        public string FullyQuotedName { get; set; }

        public SqlTable(int objectId, string schemaName, string objectName, string fullyQuotedName)
        {
            if (objectId == 0)
                throw new ArgumentException("ObjectID cannot be zero");
            if (string.IsNullOrWhiteSpace(schemaName))
                throw new ArgumentException("Schema name cannot be null or empty");
            if (string.IsNullOrWhiteSpace(objectName))
                throw new ArgumentException("Object name cannot be null or empty");
            if (string.IsNullOrWhiteSpace(fullyQuotedName))
                throw new ArgumentException("Fully quoted name cannot be null or empty");

            ObjectId = objectId;
            ObjectName = objectName;
            SchemaName = schemaName;
            FullyQuotedName = fullyQuotedName;
        }
    }
}
