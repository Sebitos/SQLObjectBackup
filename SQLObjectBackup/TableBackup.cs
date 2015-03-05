using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLObjectBackup
{
    public class TableBackup
    {
        public SqlTable SourceTable { get; set; }
        public SqlTable BackupTable { get; set; }
        public DateTime CreatedOn { get; set; }

        public TableBackup(SqlTable sourceTable, SqlTable backupTable, DateTime createdOn)
        {
            if (sourceTable == null)
                throw new ArgumentNullException("sourceTable");
            if (backupTable == null)
                throw new ArgumentNullException("backupTable");

            SourceTable = sourceTable;
            BackupTable = backupTable;
            CreatedOn = createdOn;
        }
    }
}
