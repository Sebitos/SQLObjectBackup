using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SQLObjectBackup
{
    public class SqlDatabase : IDataStore, ISqlDatabase
    {
        private const string _backupSchemaName = "sqlob";
        private const string _metaDataTableName = "meta";
        private const string _dboSchema = "dbo";
        private string _selectSchemaName = "";

        private IEnumerable<SqlTable> _tables;
        private IEnumerable<TableConstraints> _tableConstraints;

        public string SqlServerName { get; private set; }
        public string DatabaseName { get; private set; }
        public bool IsWindowsAuth { get; private set; }
        public string SqlUserName { get; private set; }
        public string Password { get; private set; }
        public IEnumerable<SqlTable> Tables { get { return GetTables(); } private set { _tables = value; } }
        public IEnumerable<TableConstraints> ConstraintTable { get { return GetTableConstraints(); } private set { _tableConstraints = value; } }

        /// <summary>
        /// windows auth constructor
        /// </summary>
        public SqlDatabase(string sqlServerName, string databaseName)
        {
            SqlServerName = sqlServerName;
            DatabaseName = databaseName;
            IsWindowsAuth = true;
        }
        public SqlDatabase(string databaseName) : this("localhost", databaseName) { }

        /// <summary>
        /// sql auth constructor
        /// </summary>
        public SqlDatabase(string sqlServerName, string databaseName, string sqlUserName, string password)
        {
            SqlServerName = sqlServerName;
            DatabaseName = databaseName;
            IsWindowsAuth = false;
            SqlUserName = sqlUserName;
            Password = password;
        }
        public SqlDatabase(string databaseName, string sqlUserName, string password) : this("localhost", databaseName, sqlUserName, password) { }

        private string GetConnectionString()
        {
            string connectionString = string.Format("data source = {0}; initial catalog = {1}; ", SqlServerName, DatabaseName);

            connectionString += IsWindowsAuth ? "trusted_connection = true;" : string.Format("user id = {0}; password = {1};", SqlUserName, Password);

            return connectionString;
        }
        public bool TestConnection()
        {
            using (SqlConnection databaseConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    databaseConnection.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public IEnumerable<SqlTable> GetTables()
        {
            DataTable output = new DataTable();

            using (SqlConnection databaseConnection = new SqlConnection(GetConnectionString()))
            using (SqlCommand sqlCmd = new SqlCommand())
            using (SqlDataAdapter sda = new SqlDataAdapter(sqlCmd))
            {
                sqlCmd.Connection = databaseConnection;
                sqlCmd.CommandText =
                    @"select
                        t.object_id,
                        schema_name = s.name,
                        object_name = t.name,
	                    fully_quoted_name = 
		                    quotename(s.name) + '.' + quotename(t.name)
                    from sys.tables t
                    inner join sys.schemas s
                    on t.schema_id = s.schema_id;";

                sda.Fill(output);
                
                foreach (DataRow row in output.Rows)
                    yield return new SqlTable(
                        Convert.ToInt32(row["object_id"]), 
                        row["schema_name"].ToString(), 
                        row["object_name"].ToString(),
                        row["fully_quoted_name"].ToString());
            }
        }
        public SqlTable GetTable(string schemaName, string objectName)
        {
            IEnumerable<SqlTable> sqlTables = GetTables().Where(m => m.SchemaName == schemaName && m.ObjectName == objectName);
            if (sqlTables.Count() == 0)
                return null;
            else
                return sqlTables.First();
        }
        public SqlTable GetTable(int objectId)
        {
            IEnumerable<SqlTable> sqlTables = GetTables().Where(m => m.ObjectId == objectId);
            if (sqlTables.Count() == 0)
                return null;
            else
                return sqlTables.First();
        }

        public IEnumerable<TableConstraints> GetTableConstraints()
        {
            DataTable output = new DataTable();

            using (SqlConnection databaseConnection = new SqlConnection(GetConnectionString()))
            using (SqlCommand sqlCmd = new SqlCommand())
            using (SqlDataAdapter sda = new SqlDataAdapter(sqlCmd))
            {
                sqlCmd.Connection = databaseConnection;
                sqlCmd.CommandText =
                    @"SELECT    
	                         KCU1.CONSTRAINT_NAME AS 'ConstraintName'
                           , quotename(KCU1.TABLE_SCHEMA) + '.' + quotename(KCU1.TABLE_NAME) AS 'TableName'
                           , KCU1.COLUMN_NAME AS 'ColumnName'
                           , quotename(KCU2.TABLE_SCHEMA) + '.' + quotename(KCU2.TABLE_NAME) AS 'TableReferenceName'
                           , KCU2.CONSTRAINT_NAME AS 'TableReferenceConstraintName'
                           , KCU2.COLUMN_NAME AS 'TableReferenceColumnName'
                        FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS RC
                        JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU1
                           ON KCU1.CONSTRAINT_CATALOG = RC.CONSTRAINT_CATALOG
                           AND KCU1.CONSTRAINT_SCHEMA = RC.CONSTRAINT_SCHEMA
                           AND KCU1.CONSTRAINT_NAME = RC.CONSTRAINT_NAME
                        JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU2
                           ON KCU2.CONSTRAINT_CATALOG = RC.UNIQUE_CONSTRAINT_CATALOG
                           AND KCU2.CONSTRAINT_SCHEMA = RC.UNIQUE_CONSTRAINT_SCHEMA
                           AND KCU2.CONSTRAINT_NAME = RC.UNIQUE_CONSTRAINT_NAME
                        WHERE KCU1.ORDINAL_POSITION = KCU2.ORDINAL_POSITION
                        ORDER BY TableName;";

                sda.Fill(output);

                foreach (DataRow row in output.Rows)
                    yield return new TableConstraints(
                        row["ConstraintName"].ToString(),
                        row["TableName"].ToString(),
                        row["ColumnName"].ToString(),
                        row["TableReferenceName"].ToString(),
                        row["TableReferenceConstraintName"].ToString(),
                        row["TableReferenceColumnName"].ToString());
            }
        }

        public TableConstraints TableConstraint(string fullyQualifiedTableName)
        {
            IEnumerable<TableConstraints> getTableConstraints = GetTableConstraints().Where(m => m.TableName == fullyQualifiedTableName);
            if (getTableConstraints.Count() == 0)
                return null;
            else
                return getTableConstraints.First();
        }

        public int GetRowCount(SqlTable sqlTable)
        {
            using (SqlConnection databaseConnection = new SqlConnection(GetConnectionString()))
            using (SqlCommand SqlCmd = new SqlCommand())
            {
                SqlCmd.Connection = databaseConnection;
                SqlCmd.CommandText = string.Format("select count(*) from {0};", sqlTable.FullyQuotedName);

                try
                {
                    databaseConnection.Open();
                    return Convert.ToInt32(SqlCmd.ExecuteScalar());
                }
                finally
                {
                    if (databaseConnection.State == ConnectionState.Open)
                        databaseConnection.Close();
                }
            }
        }

        private string QuoteName(string name)
        {
            using (SqlConnection databaseConnection = new SqlConnection(GetConnectionString()))
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.Connection = databaseConnection;
                sqlCmd.CommandText = "select quotename(@input);";
                sqlCmd.Parameters.Add(new SqlParameter("@input", SqlDbType.NVarChar, 1024) { Value = name });

                databaseConnection.Open();
                return sqlCmd.ExecuteScalar().ToString();
            }
        }

        public void CleanupAll()
        {
            RemoveAllBackups();
            DeleteBaseEntities();
        }

        public bool BaseEntitiesExist()
        {
            return BaseSchemaExists() && MetadataTableExists();
        }
        private bool BaseSchemaExists()
        {
            using (SqlConnection databaseConnection = new SqlConnection(GetConnectionString()))
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.Connection = databaseConnection;
                sqlCmd.CommandText = @"
                    select count(*)
                    from sys.schemas
                    where name = @schema_name;";
                sqlCmd.Parameters.Add(new SqlParameter("@schema_name", SqlDbType.NVarChar, 128) { Value = _backupSchemaName });

                databaseConnection.Open();

                return Convert.ToInt32(sqlCmd.ExecuteScalar()) == 1 ? true : false;
            }
        }
        private bool MetadataTableExists()
        {
            return GetMetadataTable() != null;
        }

        private SqlTable GetMetadataTable()
        {
            return GetTable(_backupSchemaName, _metaDataTableName);
        }

        public void CreateBaseEntities()
        {
            CreateBaseSchema();
            CreateMetadataTable();
        }
        private void CreateBaseSchema()
        {
            if (BaseSchemaExists())
                return;

            using (SqlConnection databaseConnection = new SqlConnection(GetConnectionString()))
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.Connection = databaseConnection;
                sqlCmd.CommandText = string.Format("create schema {0};", _backupSchemaName);

                databaseConnection.Open();

                sqlCmd.ExecuteNonQuery();
            }
        }
        private void CreateMetadataTable()
        {
            if (MetadataTableExists())
                return;

            using (SqlConnection databaseConnection = new SqlConnection(GetConnectionString()))
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.Connection = databaseConnection;
                sqlCmd.CommandText = string.Format(@"
                    create table {0}.{1}
                    (
                        base_object_id int not null,
                        backup_object_id int not null,
                        backup_create_datetime datetime not null
                    );", _backupSchemaName, _metaDataTableName);

                databaseConnection.Open();

                sqlCmd.ExecuteNonQuery();
            }
        }

        public void DeleteBaseEntities()
        {
            DeleteMetadataTable();
            DeleteBaseSchema();
        }
        private void DeleteBaseSchema()
        {
            if (!BaseSchemaExists())
                return;

            using (SqlConnection databaseConnection = new SqlConnection(GetConnectionString()))
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.Connection = databaseConnection;
                sqlCmd.CommandText = string.Format("drop schema {0};", _backupSchemaName);

                databaseConnection.Open();

                sqlCmd.ExecuteNonQuery();
            }
        }
        private void DeleteMetadataTable()
        {
            if (!MetadataTableExists())
                return;

            SqlTable metaDataTable = GetMetadataTable();

            using (SqlConnection DatabaseConnection = new SqlConnection(GetConnectionString()))
            using (SqlCommand SqlCmd = new SqlCommand())
            {
                SqlCmd.Connection = DatabaseConnection;
                SqlCmd.CommandText = string.Format("drop table {0};", metaDataTable.FullyQuotedName);

                DatabaseConnection.Open();

                SqlCmd.ExecuteNonQuery();
            }
        }

        public SqlTable BackupTable(SqlTable sourceTable)
        {
            if (!BaseEntitiesExist())
                throw new SqlDatabaseException("Base entities must exist before backing up the table");
            if (sourceTable == null)
                throw new ArgumentNullException("sourceTable");
            if (string.IsNullOrWhiteSpace(sourceTable.ObjectName))
                throw new SqlDatabaseException("Source table object name can't be null");
            if (string.IsNullOrWhiteSpace(sourceTable.SchemaName))
                throw new SqlDatabaseException("Source table schema name can't be null");
            if (sourceTable.ObjectId == 0)
                throw new SqlDatabaseException("Source table object_id can't be 0");

            SqlTable backupTable = CreateTableCopy(sourceTable, GenerateBackupTableName(sourceTable));

            // test for a returned backup table object 
            // the logic here is that if no table is returned 
            // then the insert wasn't successful, and therefore 
            // we shouldn't insert a meta row
            //
            if (backupTable != null)
                InsertMetaRowFromBackup(sourceTable, backupTable);
                        
            return backupTable;
        }
        private string GenerateBackupTableName(SqlTable sourceTable)
        {
            // note: the schema for the backup tables will always be the 
            // backup schema name, they won't be stored in any other schema
            //
            // the backup table name will just be the same name with an 
            // appended "_<GUID>"
            //
            return string.Format("{0}_{1}", sourceTable.ObjectName, Guid.NewGuid().ToString().Replace("-", ""));
        }
        private SqlTable CreateTableCopy(SqlTable sourceTable, string backupTableObjectName)
        {
            using (SqlConnection databaseConnection = new SqlConnection(GetConnectionString()))
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.Connection = databaseConnection;
                sqlCmd.CommandText = string.Format(@"
                    select *
                    into {0}.{1}
                    from {2};", 
                    QuoteName(_backupSchemaName), QuoteName(backupTableObjectName),
                    sourceTable.FullyQuotedName);

                databaseConnection.Open();

                sqlCmd.ExecuteNonQuery();

                return GetTable(_backupSchemaName, backupTableObjectName);
            }
        }
        private void InsertMetaRowFromBackup(SqlTable sourceTable, SqlTable backupTable)
        {
            if (!MetadataTableExists())
                throw new SqlDatabaseException("Metadata table does not exist when attempting to insert meta row");
            if (sourceTable == null || backupTable == null)
                throw new SqlDatabaseException("Source table and backup table cannot be null when attempting to add meta from a backup");

            SqlTable metaDataTable = GetMetadataTable();

            using (SqlConnection databaseConnection = new SqlConnection(GetConnectionString()))
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.Connection = databaseConnection;
                sqlCmd.CommandText = string.Format(@"
                    insert into {0} 
                    (
                        base_object_id,
                        backup_object_id,
                        backup_create_datetime
                    )
                    values (@base_object_id, @backup_object_id, @backup_create_datetime);",
                    metaDataTable.FullyQuotedName);

                sqlCmd.Parameters.Add(new SqlParameter("@base_object_id", SqlDbType.Int) { Value = sourceTable.ObjectId });
                sqlCmd.Parameters.Add(new SqlParameter("@backup_object_id", SqlDbType.Int) { Value = backupTable.ObjectId });
                sqlCmd.Parameters.Add(new SqlParameter("@backup_create_datetime", SqlDbType.DateTime) { Value = DateTime.Now });

                databaseConnection.Open();

                sqlCmd.ExecuteNonQuery();
            }
        }
                        
        public IEnumerable<TableBackup> GetTableBackup()
        {
            if (!BaseEntitiesExist())
                throw new SqlDatabaseException("Base entities don't exist");

            SqlTable metaDataTable = GetMetadataTable();
            DataTable output = new DataTable();

            using (SqlConnection databaseConnection = new SqlConnection(GetConnectionString()))
            using (SqlCommand sqlCmd = new SqlCommand())
            using (SqlDataAdapter sda = new SqlDataAdapter(sqlCmd))
            {
                sqlCmd.Connection = databaseConnection;
                sqlCmd.CommandText = string.Format(@"
                    select base_object_id, backup_object_id, backup_create_datetime
                    from {0}", metaDataTable.FullyQuotedName);

                sda.Fill(output);

                foreach (DataRow row in output.Rows)
                    yield return new TableBackup(
                        GetTable(Convert.ToInt32(row["base_object_id"])),
                        GetTable(Convert.ToInt32(row["backup_object_id"])),
                        Convert.ToDateTime(row["backup_create_datetime"]));
            }
        }
        public IEnumerable<TableBackup> GetTableBackup(SqlTable sourceTable)
        {
            return GetTableBackup().Where(m => m.SourceTable.ObjectId == sourceTable.ObjectId);
        }

        public void RemoveAllBackups()
        {
            foreach (TableBackup tableBackup in GetTableBackup())
                RemoveBackup(tableBackup);
        }
        public void RemoveBackup(SqlTable sourceTable)
        {
            foreach (TableBackup tableBackup in GetTableBackup(sourceTable))
                RemoveBackup(tableBackup);
        }
        public void RemoveBackup(TableBackup tableBackup)
        {
            RemoveTable(tableBackup.BackupTable);

            // do a sanity check to make sure the backup table 
            // was actually removed, and if not then we should 
            // throw an exception
            //
            if (GetTable(tableBackup.BackupTable.ObjectId) != null)
                throw new SqlDatabaseException("Expected to have deleted the backup table, but it still exists");

            // otherwise, if the table is gone then remove the row 
            // from the meta data table
            //
            DeleteMetaRow(tableBackup);
        }
        private void RemoveTable(SqlTable table)
        {
            if (table == null)
                throw new ArgumentNullException("table");
            if (GetTable(table.SchemaName, table.ObjectName) == null)
                throw new SqlDatabaseException("Table does not exist in the database");

            using (SqlConnection databaseConnection = new SqlConnection(GetConnectionString()))
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.Connection = databaseConnection;
                sqlCmd.CommandText = string.Format("drop table {0};", table.FullyQuotedName);

                databaseConnection.Open();

                sqlCmd.ExecuteNonQuery();
            }
        }
        private void DeleteMetaRow(TableBackup tableBackup)
        {
            if (!BaseEntitiesExist())
                throw new SqlDatabaseException("Base entities don't exist");

            SqlTable metaDataTable = GetMetadataTable();

            using (SqlConnection databaseConnection = new SqlConnection(GetConnectionString()))
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.Connection = databaseConnection;
                sqlCmd.CommandText = string.Format(@"
                    delete from {0}
                    where base_object_id = @base_object_id
                    and backup_object_id = @backup_object_id;", metaDataTable.FullyQuotedName);

                sqlCmd.Parameters.Add(new SqlParameter("@base_object_id", SqlDbType.Int) { Value = tableBackup.SourceTable.ObjectId });
                sqlCmd.Parameters.Add(new SqlParameter("@backup_object_id", SqlDbType.Int) { Value = tableBackup.BackupTable.ObjectId });

                databaseConnection.Open();
                sqlCmd.ExecuteNonQuery();
            }
        }
    }
}
