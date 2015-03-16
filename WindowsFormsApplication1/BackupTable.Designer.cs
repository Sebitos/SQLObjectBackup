namespace SQLObjectBackupGUI
{
    partial class BackupTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cancelButton = new System.Windows.Forms.Button();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.optionsRadioButton = new System.Windows.Forms.RadioButton();
            this.generalRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.topLabel = new System.Windows.Forms.Label();
            this.backupButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panelManager1 = new Controls.PanelManager();
            this.managedPanel1 = new Controls.ManagedPanel();
            this.tablesSelectedLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.directoryButton = new System.Windows.Forms.Button();
            this.directoryTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.unselectAllButton = new System.Windows.Forms.Button();
            this.tableInfoGrid = new System.Windows.Forms.DataGridView();
            this.TablesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasForeignKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.tablesCheckedList = new System.Windows.Forms.CheckedListBox();
            this.databaseComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.managedPanel2 = new Controls.ManagedPanel();
            this.leftPanel.SuspendLayout();
            this.panelManager1.SuspendLayout();
            this.managedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableInfoGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(694, 548);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 30);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.SystemColors.Window;
            this.leftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftPanel.Controls.Add(this.optionsRadioButton);
            this.leftPanel.Controls.Add(this.generalRadioButton);
            this.leftPanel.Controls.Add(this.label1);
            this.leftPanel.Location = new System.Drawing.Point(12, 12);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(159, 566);
            this.leftPanel.TabIndex = 2;
            // 
            // optionsRadioButton
            // 
            this.optionsRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.optionsRadioButton.BackColor = System.Drawing.SystemColors.Window;
            this.optionsRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.optionsRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionsRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optionsRadioButton.Location = new System.Drawing.Point(-1, 57);
            this.optionsRadioButton.Name = "optionsRadioButton";
            this.optionsRadioButton.Size = new System.Drawing.Size(159, 28);
            this.optionsRadioButton.TabIndex = 3;
            this.optionsRadioButton.Text = "   Backup Options";
            this.optionsRadioButton.UseVisualStyleBackColor = true;
            this.optionsRadioButton.CheckedChanged += new System.EventHandler(this.optionsRadioButton_CheckedChanged);
            // 
            // generalRadioButton
            // 
            this.generalRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.generalRadioButton.BackColor = System.Drawing.SystemColors.Window;
            this.generalRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.generalRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generalRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.generalRadioButton.Location = new System.Drawing.Point(-1, 23);
            this.generalRadioButton.Name = "generalRadioButton";
            this.generalRadioButton.Size = new System.Drawing.Size(159, 28);
            this.generalRadioButton.TabIndex = 2;
            this.generalRadioButton.Text = "   General";
            this.generalRadioButton.UseVisualStyleBackColor = true;
            this.generalRadioButton.CheckedChanged += new System.EventHandler(this.generalRadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a page";
            // 
            // topLabel
            // 
            this.topLabel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.topLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topLabel.Location = new System.Drawing.Point(177, 13);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(620, 20);
            this.topLabel.TabIndex = 4;
            this.topLabel.Text = "General";
            this.topLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // backupButton
            // 
            this.backupButton.Location = new System.Drawing.Point(588, 548);
            this.backupButton.Name = "backupButton";
            this.backupButton.Size = new System.Drawing.Size(100, 30);
            this.backupButton.TabIndex = 5;
            this.backupButton.Text = "Backup";
            this.backupButton.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(171, 534);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(649, 2);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // panelManager1
            // 
            this.panelManager1.Controls.Add(this.managedPanel1);
            this.panelManager1.Controls.Add(this.managedPanel2);
            this.panelManager1.Location = new System.Drawing.Point(177, 36);
            this.panelManager1.Name = "panelManager1";
            this.panelManager1.SelectedIndex = 0;
            this.panelManager1.SelectedPanel = this.managedPanel1;
            this.panelManager1.Size = new System.Drawing.Size(620, 492);
            this.panelManager1.TabIndex = 3;
            // 
            // managedPanel1
            // 
            this.managedPanel1.Controls.Add(this.tablesSelectedLabel);
            this.managedPanel1.Controls.Add(this.label8);
            this.managedPanel1.Controls.Add(this.label7);
            this.managedPanel1.Controls.Add(this.directoryButton);
            this.managedPanel1.Controls.Add(this.directoryTextBox);
            this.managedPanel1.Controls.Add(this.groupBox2);
            this.managedPanel1.Controls.Add(this.groupBox1);
            this.managedPanel1.Controls.Add(this.label6);
            this.managedPanel1.Controls.Add(this.selectAllButton);
            this.managedPanel1.Controls.Add(this.unselectAllButton);
            this.managedPanel1.Controls.Add(this.tableInfoGrid);
            this.managedPanel1.Controls.Add(this.label3);
            this.managedPanel1.Controls.Add(this.tablesCheckedList);
            this.managedPanel1.Controls.Add(this.databaseComboBox);
            this.managedPanel1.Controls.Add(this.label5);
            this.managedPanel1.Controls.Add(this.label4);
            this.managedPanel1.Controls.Add(this.label2);
            this.managedPanel1.Location = new System.Drawing.Point(0, 0);
            this.managedPanel1.Name = "managedPanel1";
            this.managedPanel1.Size = new System.Drawing.Size(620, 492);
            this.managedPanel1.Text = "managedPanel1";
            // 
            // tablesSelectedLabel
            // 
            this.tablesSelectedLabel.AutoSize = true;
            this.tablesSelectedLabel.Location = new System.Drawing.Point(265, 183);
            this.tablesSelectedLabel.Name = "tablesSelectedLabel";
            this.tablesSelectedLabel.Size = new System.Drawing.Size(0, 17);
            this.tablesSelectedLabel.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(145, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Tables Selected:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 459);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Backup to:";
            // 
            // directoryButton
            // 
            this.directoryButton.Enabled = false;
            this.directoryButton.Location = new System.Drawing.Point(586, 456);
            this.directoryButton.Name = "directoryButton";
            this.directoryButton.Size = new System.Drawing.Size(31, 22);
            this.directoryButton.TabIndex = 20;
            this.directoryButton.Text = "...";
            this.directoryButton.UseVisualStyleBackColor = true;
            this.directoryButton.Click += new System.EventHandler(this.directoryButton_Click);
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.Location = new System.Drawing.Point(110, 456);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.Size = new System.Drawing.Size(470, 22);
            this.directoryTextBox.TabIndex = 19;
            this.directoryTextBox.Text = "Select Backup Directory";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(61, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(558, 2);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(87, 435);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 2);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 426);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Destination";
            // 
            // selectAllButton
            // 
            this.selectAllButton.Location = new System.Drawing.Point(411, 176);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(100, 30);
            this.selectAllButton.TabIndex = 13;
            this.selectAllButton.Text = "Select all";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // unselectAllButton
            // 
            this.unselectAllButton.Location = new System.Drawing.Point(517, 176);
            this.unselectAllButton.Name = "unselectAllButton";
            this.unselectAllButton.Size = new System.Drawing.Size(100, 30);
            this.unselectAllButton.TabIndex = 12;
            this.unselectAllButton.Text = "Unselect all";
            this.unselectAllButton.UseVisualStyleBackColor = true;
            this.unselectAllButton.Click += new System.EventHandler(this.unselectAllButton_Click);
            // 
            // tableInfoGrid
            // 
            this.tableInfoGrid.AllowUserToAddRows = false;
            this.tableInfoGrid.AllowUserToDeleteRows = false;
            this.tableInfoGrid.AllowUserToOrderColumns = true;
            this.tableInfoGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.tableInfoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableInfoGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TablesID,
            this.TableName,
            this.RowsCount,
            this.HasForeignKey});
            this.tableInfoGrid.Location = new System.Drawing.Point(16, 225);
            this.tableInfoGrid.Name = "tableInfoGrid";
            this.tableInfoGrid.ReadOnly = true;
            this.tableInfoGrid.RowHeadersVisible = false;
            this.tableInfoGrid.RowTemplate.Height = 24;
            this.tableInfoGrid.Size = new System.Drawing.Size(601, 187);
            this.tableInfoGrid.TabIndex = 11;
            // 
            // TablesID
            // 
            this.TablesID.HeaderText = "Table ID";
            this.TablesID.Name = "TablesID";
            this.TablesID.ReadOnly = true;
            // 
            // TableName
            // 
            this.TableName.HeaderText = "Table Name";
            this.TableName.Name = "TableName";
            this.TableName.ReadOnly = true;
            // 
            // RowsCount
            // 
            this.RowsCount.HeaderText = "Row Count";
            this.RowsCount.Name = "RowsCount";
            this.RowsCount.ReadOnly = true;
            // 
            // HasForeignKey
            // 
            this.HasForeignKey.HeaderText = "Has Foreign Key";
            this.HasForeignKey.Name = "HasForeignKey";
            this.HasForeignKey.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Table information";
            // 
            // tablesCheckedList
            // 
            this.tablesCheckedList.AllowDrop = true;
            this.tablesCheckedList.FormattingEnabled = true;
            this.tablesCheckedList.Location = new System.Drawing.Point(148, 64);
            this.tablesCheckedList.Name = "tablesCheckedList";
            this.tablesCheckedList.Size = new System.Drawing.Size(469, 106);
            this.tablesCheckedList.TabIndex = 9;
            this.tablesCheckedList.ThreeDCheckBoxes = true;
            this.tablesCheckedList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.tablesCheckedList_ItemCheck);
            // 
            // databaseComboBox
            // 
            this.databaseComboBox.FormattingEnabled = true;
            this.databaseComboBox.Location = new System.Drawing.Point(148, 31);
            this.databaseComboBox.Name = "databaseComboBox";
            this.databaseComboBox.Size = new System.Drawing.Size(469, 24);
            this.databaseComboBox.TabIndex = 7;
            this.databaseComboBox.DropDown += new System.EventHandler(this.databaseComboBox_DropDown);
            this.databaseComboBox.SelectionChangeCommitted += new System.EventHandler(this.databaseComboBox_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Table:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Database:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Source";
            // 
            // managedPanel2
            // 
            this.managedPanel2.Location = new System.Drawing.Point(0, 0);
            this.managedPanel2.Name = "managedPanel2";
            this.managedPanel2.Size = new System.Drawing.Size(0, 0);
            this.managedPanel2.Text = "managedPanel2";
            // 
            // BackupTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 590);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.backupButton);
            this.Controls.Add(this.panelManager1);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.topLabel);
            this.Controls.Add(this.cancelButton);
            this.Name = "BackupTable";
            this.Text = "Table Backup";
            this.Load += new System.EventHandler(this.SqlObjectBackupGUI_Load);
            this.leftPanel.ResumeLayout(false);
            this.panelManager1.ResumeLayout(false);
            this.managedPanel1.ResumeLayout(false);
            this.managedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableInfoGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        internal System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.RadioButton optionsRadioButton;
        private System.Windows.Forms.RadioButton generalRadioButton;
        private System.Windows.Forms.Label label1;
        private Controls.PanelManager panelManager1;
        private Controls.ManagedPanel managedPanel1;
        private System.Windows.Forms.Label topLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Controls.ManagedPanel managedPanel2;
        private System.Windows.Forms.ComboBox databaseComboBox;
        private System.Windows.Forms.CheckedListBox tablesCheckedList;
        private System.Windows.Forms.DataGridView tableInfoGrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button unselectAllButton;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.Button backupButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button directoryButton;
        private System.Windows.Forms.TextBox directoryTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label tablesSelectedLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn TablesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowsCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn HasForeignKey;
    }
}