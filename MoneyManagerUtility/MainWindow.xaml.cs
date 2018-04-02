using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MoneyManagerUtility.Import;
using System.IO;

namespace MoneyManagerUtility
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const String END_TITLE_SIGN = "=";
        public const String End_VALUE_SIGN = "-";

        private ImportChecker checker;
        private SaveFileManager saveFileManager;
        private TreeNode head;

        private ItemReader reader = new ItemReader();
        public MainWindow()
        {
            InitializeComponent();
            CheckFolderStructure();
            checker = new ImportChecker();
            saveFileManager = new SaveFileManager();
            Load();
        }

        private void Load()
        {
            String[] files = Directory.GetFiles(String.Format("{0}{1}", Environment.CurrentDirectory, StringResources.SAVE_FOLDER_PATH));
            String openFile = null;
            foreach (String file in files)
                if (file.ToUpper().EndsWith("XML"))
                {
                    openFile = file;
                    continue;
                }
            if (openFile == null)
                return;
            Import_XML(openFile);
        }

        private void CheckFolderStructure()
        {
            //todo
        }

        public void SetTree(TreeNode treeNode)
        {
            TreeItemViewMain.Header = treeNode.Title;
            if (treeNode.children != null)
                SetChildren(treeNode.children, TreeItemViewMain);
        }

        private void SetChildren(List<TreeNode> children, TreeViewItem parent)
        {
            if (children == null)
                return;
            foreach (TreeNode actual in children)
            {
                NodeItem nodeItem = actual as NodeItem;
                bool isSum = (actual.Title != null) ? actual.Title.StartsWith(StringResources.SUM) : false;
                bool isActualBalance = (actual.Title != null) ? actual.Title.StartsWith(StringResources.ACTUAL_BALANCE) : false;
                if (isSum)
                {
                    NodeItem separator = new NodeItem(nodeItem.reader);
                    separator.Title = StringResources.XML_SEPARATOR_DAILY_LIST_END;
                    TreeViewItem separatorItem = new TreeViewItem() { Header = separator.Title, IsExpanded = true };
                    parent.Items.Add(separatorItem);
                    separatorItem.Tag = actual;
                }

                String header = actual.Title;
                if (nodeItem != null)
                    header = String.Format("{0}{1}{2}", nodeItem.Title, END_TITLE_SIGN, nodeItem.Value, End_VALUE_SIGN, nodeItem.Description);

                TreeViewItem item = new TreeViewItem() { Header = header, IsExpanded = true };
                item.MouseDoubleClick += TreeNodeItem_DoubleClick;
                item.MouseDoubleClick += mouseDoubleHandler_Click;
                parent.Items.Add(item);
                item.Tag = actual;
                SetChildren(actual.children, item);
                if (isActualBalance)
                {
                    NodeItem separator = new NodeItem(nodeItem.reader) { Title = StringResources.XML_SEPARATOR_DAY };
                    TreeViewItem separatorItem = new TreeViewItem() { Header = separator.Title, IsExpanded = true };
                    parent.Items.Add(separatorItem);
                    separatorItem.Tag = actual;
                }
            }
        }

        private void TreeNodeItem_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem item = sender as TreeViewItem;
            if (item == null)
                return;
            NodeItem node = item.Tag as NodeItem;
            if (node == null)
                return;
            DialogModifyItem dialog = new DialogModifyItem(node, reader);
            dialog.ShowDialog();
            item.IsExpanded = true;
            item.Header = String.Format("{0}{1}{2}", node.Title, END_TITLE_SIGN, node.Value, End_VALUE_SIGN, node.Description);
            TreeItemViewMain.Items.Refresh();
        }

        private void mouseDoubleHandler_Click(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem item = sender as TreeViewItem;
            if (item == null)
                return;
            TreeNode node = item.Tag as TreeNode;
            if (node == null)
                return;
            //modify dialog
        }

        private void TXTImport_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Image files (*.txt, *.TXT) | *.txt; *.TXT";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                checker.IsValidTXTFile(filename);
                ClearTheTree();
                Import_TXT(filename);
            }
        }

        public void Import_TXT(String testimportfile)
        {
            //string testimportfile = @"c:\docs\kiadások2.txt";
            FileImporter impoerter = new TXTFileImporter(testimportfile, reader);
            impoerter.Import();
            head = impoerter.GetHead();
            SetTree(head);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (IsNew() && head != null)
            {
                CreateNewTreeFile();
            }
            else
            {
                Save();
            }
        }

        private bool IsNew()
        {
            return !File.Exists(TreeItemViewMain.Header.ToString());
        }

        private void CreateNewTreeFile()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(String.Format(StringResources.SAVE_FORMAT_YEAR_START, head.Title));
            saveFileManager.CreateNewTreeFile_Recursive(ref builder, head);
            builder.AppendLine(StringResources.SAVE_FORMAT_YEAR_END);
            File.WriteAllText(String.Format("{0}{1}{2}{3}", Environment.CurrentDirectory, StringResources.SAVE_FOLDER_PATH, TreeItemViewMain.Header, StringResources.SAVE_FORMAT_EXTENSION), builder.ToString());
            MessageBox.Show("Save finiesed", "Save");
        }


        private void Save()
        {

        }

        private void XMLImport_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "Image files (*.xml, *.XML) | *.xml; *.XM";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                checker.IsValidXMLFile(filename);
                ClearTheTree();
                Import_XML(filename);
            }
        }

        public void ClearTheTree()
        {
            TreeItemViewMain.Items.Clear();
        }

        private void Import_XML(string openFile)
        {
            FileImporter impoerter = new XLMFileImporter(openFile, reader);
            impoerter.Import();
            head = impoerter.GetHead();
            SetTree(head);
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            DialogNew newDialog = new DialogNew(reader, this);
            newDialog.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        public void SetHead(TreeNode head) {
            this.head = head;
        }
    }
}