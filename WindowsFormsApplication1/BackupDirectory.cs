using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SQLObjectBackupGUI
{
    public partial class BackupDirectory : Form
    {
        public BackupTable father;
        public BackupDirectory()
        {
            InitializeComponent();
        }

        private void BackupDirectory_Load(object sender, EventArgs e)
        {
            directoryTree.Nodes.Clear();
            DirectoryInfo dirinfo;
            foreach (string drive in Directory.GetLogicalDrives())
            {
                dirinfo = new DirectoryInfo(drive);
                if (dirinfo.Exists)
                {
                    TreeNode tn = new TreeNode(dirinfo.Name);
                    tn.ImageIndex = 0;
                    tn.Tag = dirinfo;
                    directoryTree.Nodes.Add(tn);
                    AddSubFoldersRecursive(tn, dirinfo);
                }
                
            }            
        }
        private void AddSubFoldersRecursive(TreeNode tn, DirectoryInfo dirinfo)
        {
            foreach (DirectoryInfo tempdirinfo in dirinfo.GetDirectories())
            {
                TreeNode tnTemp = new TreeNode(tempdirinfo.Name);
                tnTemp.ImageIndex = 0;
                tnTemp.Tag = tempdirinfo;                
                tn.Nodes.Add(tnTemp);
            }
        }        

        private void directoryTree_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                DirectoryInfo dirinfo = (DirectoryInfo)e.Node.Tag;
                if (e.Node.Nodes.Count <= 0)
                {
                    AddSubFoldersRecursive(e.Node, dirinfo);
                }
            }
        }

        private void directoryTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                DirectoryInfo dirinfo = (DirectoryInfo)e.Node.Tag;
                if (e.Node.Nodes.Count <= 0)
                {
                    AddSubFoldersRecursive(e.Node, dirinfo);
                }
            }

            string NewDirectory = directoryTree.SelectedNode.FullPath.ToString().Replace(@"\\", @"\");
            selectedPathTextBox.Text = NewDirectory;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (fileNameTextBox.Text == "")
            {
                MessageBox.Show("Specify a file name for the table backup", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fileNameTextBox.Focus();
            }
            else
            {
                string fullPath = selectedPathTextBox.Text + @"\" + fileNameTextBox.Text + ".sql";
                father.changeDirectoryTextBox(fullPath);
                
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
