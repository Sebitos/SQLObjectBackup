using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLObjectBackup;



namespace SQLObjectBackupGUI
{
    public partial class BackupTable : Form
    {        
        public string serverName { get; set; }

        string selectedDB = "";
        int tableid = 0;
        SqlDatabase DB;
        SqlTable table;
        int rowCount = 0;
        TableConstraints foreignKeyTable;
        string isFK = "";

        /// <summary>
        /// To validate if selectAllButton or unselectAllButton is pressed.
        /// Works on the if statement in tablesCheckedList_ItemCheck
        /// </summary>
        bool isSelectAllButtonPressed;
        bool isUnselectAllButtonPressed;


        public BackupTable()
        {
            InitializeComponent();
        }
                
        private void SqlObjectBackupGUI_Load(object sender, EventArgs e)
        {
            Authenticate();
            tablesSelectedLabel.Text = "0";
        }

        private void databaseComboBox_DropDown(object sender, EventArgs e)
        {
            SqlConnectGUI sqlGUI = new SqlConnectGUI(serverName);
            this.databaseComboBox.DataSource = sqlGUI.Databases.ToList();

            this.databaseComboBox.DisplayMember = "DatabaseName";
            this.databaseComboBox.ValueMember = "DatabaseName";

            string selectedDB = this.databaseComboBox.SelectedValue.ToString();

            Tables(selectedDB);
        }

        private void Authenticate()
        {
            connectToServerForm connect = new connectToServerForm();
            connect.father = this;
            connect.ShowDialog();
        }

        private void Tables(string DbName)
        {
            if (this.databaseComboBox == null)
            {
                SqlConnectGUI sqlGUI = new SqlConnectGUI(serverName);
                this.databaseComboBox.DataSource = sqlGUI.Databases.ToList();

                this.databaseComboBox.DisplayMember = "DatabaseName";
                this.databaseComboBox.ValueMember = "DatabaseName";

                string selectedDB = this.databaseComboBox.SelectedValue.ToString();

                SqlDatabase sqlDB = new SqlDatabase(serverName, DbName);
                this.tablesCheckedList.DataSource = sqlDB.GetTables().ToList();
                this.tablesCheckedList.DisplayMember = "FullyQuotedName";
                this.tablesCheckedList.ValueMember = "FullyQuotedName";
                this.tablesCheckedList.ValueMember = "ObjectId";
            }
            else
            {
                SqlDatabase sqlDB = new SqlDatabase(serverName, DbName);
                this.tablesCheckedList.DataSource = sqlDB.GetTables().ToList();
                this.tablesCheckedList.DisplayMember = "FullyQuotedName";
                this.tablesCheckedList.ValueMember = "FullyQuotedName";
                this.tablesCheckedList.ValueMember = "ObjectId";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkSteps()
        {
            if (generalRadioButton.Checked)
            {
                panelManager1.SelectedIndex = 0;
                topLabel.Text = "General";
            }
            if (optionsRadioButton.Checked)
            {
                panelManager1.SelectedIndex = 1;
                topLabel.Text = "Options";
            }     
        }

        private void generalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            checkSteps();
        }

        private void optionsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            checkSteps();
        }

        private void databaseComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectedDB = this.databaseComboBox.SelectedValue.ToString();
            Tables(selectedDB);

            for (int i = 0; i < tablesCheckedList.Items.Count; i++)
            {
                tablesCheckedList.SetItemChecked(i, false);
            }

            tableInfoGrid.Rows.Clear();
            tableInfoGrid.Refresh();
            tablesSelectedLabel.Text = "0";
        }

        private void isForeignKey(string fullTableName)
        {
            DB = new SqlDatabase(selectedDB);

            


        }
        /// <summary>
        /// Method to add or delete rows in the DataGridView.
        /// Rows contain information about the table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tablesCheckedList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isSelectAllButtonPressed == true)
            {
                foreignKeyTable = DB.TableConstraint(table.FullyQuotedName);

                if (foreignKeyTable == null)
                {
                    insertTableInfo(table.ObjectId, table.FullyQuotedName, rowCount, "");
                }
                else
                {
                    insertTableInfo(table.ObjectId, table.FullyQuotedName, rowCount, foreignKeyTable.ConstraintName);
                }                    
            }
            else if (isUnselectAllButtonPressed == true)
            {
            }
            else
            {
                ///because of nature of ItemChecked event, the checked event will not happen until after the 
                ///ItemCheck event finishes, therefore to add a row into DataGridView Checkstate is Unchecked.
                if (tablesCheckedList.GetItemCheckState(tablesCheckedList.SelectedIndex) == CheckState.Unchecked)
                {
                    selectedDB = this.databaseComboBox.SelectedValue.ToString();
                    tableid = int.Parse(this.tablesCheckedList.SelectedValue.ToString());

                    DB = new SqlDatabase(selectedDB);
                    table = DB.GetTable(tableid);
                    rowCount = DB.GetRowCount(table);
                    foreignKeyTable = DB.TableConstraint(table.FullyQuotedName);

                    if (foreignKeyTable ==  null)
                    {
                        insertTableInfo(table.ObjectId, table.FullyQuotedName, rowCount, "");
                    }
                    else
                    {
                        insertTableInfo(table.ObjectId, table.FullyQuotedName, rowCount, foreignKeyTable.ConstraintName);
                    }                    

                    int tablesSelected = tablesCheckedList.CheckedItems.Count;
                    tablesSelected = tablesSelected + 1;
                    tablesSelectedLabel.Text = tablesSelected.ToString();
                }
                else
                {
                    string selectedDB = this.databaseComboBox.SelectedValue.ToString();
                    int tableid = int.Parse(this.tablesCheckedList.SelectedValue.ToString());                    
                                        
                    deleteTableInfo(tableid);

                    int tablesSelected = tablesCheckedList.CheckedItems.Count;
                    tablesSelected = tablesSelected - 1;
                    tablesSelectedLabel.Text = tablesSelected.ToString();                    
                }
            }
            
        }
        /// <summary>
        /// Add row to the grid based on the parameters list.
        /// </summary>
        /// <param name="ObjectId"></param>
        /// <param name="FullyQuotedName"></param>
        /// <param name="rowCount"></param>
        /// <param name="foreignKey"></param>
        private void insertTableInfo(int ObjectId, string FullyQuotedName, int rowCount, string foreignKey)
        {
            tableInfoGrid.Rows.Add(ObjectId, FullyQuotedName, rowCount, foreignKey);
        }
        /// <summary>
        /// Delete row from grid based on tableid.
        /// </summary>
        /// <param name="tableid"></param>
        private void deleteTableInfo(int tableid)
        {
            ///Look for the row index to delete from the gridview when a table is unselected
            foreach (DataGridViewRow row in tableInfoGrid.Rows)
            {
                if (row.Cells[0].Value.Equals(tableid))
                {
                    int gridRowID = row.Index;
                    this.tableInfoGrid.Rows.RemoveAt(gridRowID);
                    break;
                }
            }
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            isSelectAllButtonPressed = true;

            for (int i = 0; i < tablesCheckedList.Items.Count; i++)
            {
                tablesCheckedList.SelectedIndex = i;                

                selectedDB = this.databaseComboBox.SelectedValue.ToString();
                tableid = int.Parse(this.tablesCheckedList.SelectedValue.ToString());

                DB = new SqlDatabase(selectedDB);
                table = DB.GetTable(tableid);
                rowCount = DB.GetRowCount(table);                

                tablesCheckedList.SetItemChecked(i, true);

                int tablesSelected = tablesCheckedList.CheckedItems.Count;                
                tablesSelectedLabel.Text = tablesSelected.ToString();
            }
            isSelectAllButtonPressed = false;
        }

        private void unselectAllButton_Click(object sender, EventArgs e)
        {
            isUnselectAllButtonPressed = true;

            for (int i = 0; i < tablesCheckedList.Items.Count; i++)
            {
                tableInfoGrid.Rows.Clear();
                tableInfoGrid.Refresh(); 
                tablesCheckedList.SetItemChecked(i, false);                
            }
            isUnselectAllButtonPressed = false;
            tablesSelectedLabel.Text = "0";
        }

        private void directoryButton_Click(object sender, EventArgs e)
        {
            BackupDirectory bd = new BackupDirectory();
            bd.father = this;
            bd.Show();
        }

        /// <summary>
        /// Chage directoryTextBox Directory Path
        /// </summary>
        /// <param name="Directory"></param>
        /// <returns></returns>
        public string changeDirectoryTextBox(string Directory)
        {
            string NewDirectory = Directory.Replace(@"\\", @"\");
            //Change the directoryTextBox to show the selected path where the scripts are
            directoryTextBox.Text = NewDirectory;

            return "";
        }       
    }
}
