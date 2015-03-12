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
using SQLObjectBackupGUI;
using System.Security;


namespace SQLObjectBackupGUI
{
    public partial class connectToServerForm : Form
    {
        /// <summary>
        /// Making SqlObjectBackupGUI the father of this form so when I close it it goes straight to the father.
        /// </summary>
        public BackupTable father;
        public connectToServerForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serverNameTxtBox.Text = Environment.MachineName;
            serverNameTxtBox.Select();
            authenticationTypeComboBox.SelectedIndex = 0;
            userNameTxtBox.ReadOnly = true;
            passwordTextBox.ReadOnly = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //father.closeButtonPressed = true;
            //father.Close();
        }
        /// <summary>
        /// Depending on the auth type, user and pwd text boxes are read only or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void authenticationTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (authenticationTypeComboBox.SelectedIndex == 0)
            {
                serverNameTxtBox.Select();
                userNameTxtBox.ReadOnly = true;
                passwordTextBox.ReadOnly = true;
            }
            else
            {
                userNameTxtBox.ReadOnly = false;
                passwordTextBox.ReadOnly = false;
                userNameTxtBox.Select();
            }
        }       
        
        private void connectButton_Click(object sender, EventArgs e)
        {
            if(serverNameTxtBox.Text == "")
            {
                MessageBox.Show("Please add a server name and/or the instance to connect to.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                serverNameTxtBox.Focus();
            }
            else
            {
                //If Windows Auth or SQL Auth
                if (authenticationTypeComboBox.SelectedIndex == 0)
                {
                    string serverName = serverNameTxtBox.Text;
                    SqlConnectGUI connect = new SqlConnectGUI(serverName); //new instance of the class that contains the next method
                    bool iCanConnect = connect.TestConnection(); //method to test connectivity to SQL Server

                    if (iCanConnect == true)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cannot connect to SQL Server " + serverName + ". Check that the Server name is correct.");
                    }
                }
                else
                {
                    //if (userNameTxtBox.Text == "" | passwordTextBox.Text == "")
                    //{
                    //    MessageBox.Show("Please type a user name and/or password to continue.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    //}

                    string serverName = serverNameTxtBox.Text;
                    string userName = userNameTxtBox.Text;

                    ///there is something wrong with securestring data type on the SQL Server side, if secured, 
                    ///it will not recognize the pwd, so I left it string only.
                    //var password = new SecureString();
                    //foreach (char c in passwordTextBox.Text)
                    //{
                    //    password.AppendChar(c);
                    //}
                    string password = passwordTextBox.Text;

                    SqlConnectGUI connect = new SqlConnectGUI(serverName, userName, password);
                    bool iCanConnect = connect.TestConnection();

                    if (iCanConnect == true)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cannot connect to SQL Server " + serverName + ". Check that the Server name, user name and passwords are correct.");
                    }
                }
            }
        }            
    }
}
