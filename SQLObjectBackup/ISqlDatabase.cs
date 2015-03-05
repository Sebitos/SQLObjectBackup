using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLObjectBackup
{
    interface ISqlDatabase
    {
        bool BaseEntitiesExist();
        void CreateBaseEntities();
        void DeleteBaseEntities();
        
        IEnumerable<SqlTable> GetTables();
        SqlTable GetTable(string schemaName, string objectName);

        SqlTable BackupTable(SqlTable sourceTable);

        IEnumerable<TableBackup> GetTableBackup();
        IEnumerable<TableBackup> GetTableBackup(SqlTable sourceTable);

        void RemoveAllBackups();
        void RemoveBackup(SqlTable sourceTable);
        void RemoveBackup(TableBackup tableBackup);
    }
}
