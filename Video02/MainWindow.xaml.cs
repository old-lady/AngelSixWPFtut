using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace Video02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //var t = new TreeViewItem();
            // too see what three view item has in properties and so on
            // t. ( and let intelij tell you)
        }
        #endregion

        #region On Loaded
        /// <summary>
        /// When the application first opens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // get every logical drive
            foreach (var drive in Directory.GetLogicalDrives())
            {
                // create new item for each drive 
                // when folder view wants it, it is a treeviewitem:
                // **--**
                // new syntax :O for setting properties in a class...

                var item = new TreeViewItem()
                {
                    Header = drive,
                    Tag = drive
                };
                // ^
                // |
                // |
                // |
                // this threeviewitem is modified 
                // the header property is what would be text in the view
                // the tag is just custom information
                // old syntax
                //item.Header = drive;
                //item.Tag = drive;

                // the treevewItem can have its own items, it is a tree
                // we add a dummy item
                // this is so you can see the tree in action
                item.Items.Add(null);

                // listem for item being expanded
                item.Expanded += Folder_Expanded;

                // now it is ready to be added
                FolderView.Items.Add(item);
            }
        }

        #endregion


        #region Folder Expanded
        /// <summary>
        /// When a folder is expanded, find the subfolders/ files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            #region initial checks
            // first get the treeviewItem that is listening for this
            // this item is **--** (search for it)

            var item = (TreeViewItem)sender;
            // we check if the treeviewItem contains only the dummy data (so this is first time it is run)
            // by removeing this, it will refresh each time it is expaned
            //if (item.Items.Count == 1 && item.Items[0] == null)
            //{

            //}
            // we reverse the logic of that if statement, so that we don't have to run all code in the if statement
            if (item.Items.Count != 1 || item.Items[0] != null)
                return;

            //clear the data
            item.Items.Clear();
            // set the full path
            var fullPath = (string)item.Tag;
            #endregion

            #region Get folders
            // create a blank list for directories
            var directories = new List<string>();

            // try find all directories (folders)
            // we add a try catch to ignore all errors - this is not good practice most places!
            // user here is not notified if something goes wrong

            try
            {
                // unlike a for or foreach loop, we make this sp that getdirectories only gets called once
                // if it fails (as it can trow many exeptions), we only catch one error.
                var dirs = Directory.GetDirectories(fullPath);
                if(dirs.Length > 0)
                {
                    directories.AddRange(dirs);

                }
            }
            catch { }

            // foreach directory
            directories.ForEach(directoryPath =>
            {
                // create the item we want to show in the tree
                // get the tag, that is the full path of that directory
                // the header is what is shown as text in the treeview, so we get the name of the directory
                var subItem = new TreeViewItem()
                {
                    //Header = Path.GetDirectoryName(directoryPath),
                    Header = Path.GetFileName(directoryPath),
                    //Header = GetFileFolderName(directoryPath),
                    Tag = directoryPath,
                };

                // we again add a dummy item, so that we can call this method on this sumitem (yay, recursion)
                // this way we can expand sumfolders
                subItem.Items.Add(null);

                // and now we listen for the expanding event
                // and run folder_expanded if it happens
                subItem.Expanded += Folder_Expanded;

                // and last we add this subitem to the "parent" item
                item.Items.Add(subItem);

            });
            #endregion

            #region get files

            // create a blank list for files
            var files = new List<string>();

            // try find all files 
            // we add a try catch to ignore all errors - this is not good practice most places!
            // user here is not notified if something goes wrong

            try
            {
                // unlike a for or foreach loop, we make this sp that GetFiles only gets called once
                // if it fails (as it can trow many exeptions), we only catch one error.
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                {
                    files.AddRange(fs);

                }
            }
            catch { }

            // foreach file
            files.ForEach(filePath =>
            {
                // create the item we want to show in the tree
                // get the tag, that is the full path of that directory
                // the header is what is shown as text in the treeview, so we get the name of the directory
                var subItem = new TreeViewItem()
                {
                    //Header = Path.GetDirectoryName(directoryPath),

                    // filename
                    //Header = Path.GetFileName(filePath),
                    Header = MainWindow.GetFileFolderName(filePath),
                    // filepath
                    Tag = filePath,
                };

                // no dummy needed for files, as they cannot be expanded
                // no event listen for expantion

                // and last we add this subitem to the "parent" item
                item.Items.Add(subItem);

            });
            

            #endregion

        }

        #endregion

        #region Helpers
        /// <summary>
        /// Find the file or folder name from a full path
        /// </summary>
        /// <param name="path">the full path</param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            // c:\something\a folder
            // c:\something\a file.png

            // if we have no path, return empty
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            var normalizedPath = path.Replace('/', '\\');

            // the index of the last \ in filepath
            var lastIndex = path.LastIndexOf('\\');

            // if we don't find a backslash (or there is only one and the path starts with it)
            // we asume it is a filename, so we can return the path itself

            if (lastIndex <= 0)
                return path;

            // else return everything after the last backslash (does not matter if it is path, or normalized path, index is the same)
            return path.Substring(lastIndex + 1);

        }
        #endregion


    }
}
