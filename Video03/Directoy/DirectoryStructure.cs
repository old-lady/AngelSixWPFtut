


using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Video03
{
    /// <summary>
    /// Static helper class to query information about directories
    /// Ususally this class and content of the folder this is in
    /// would be a seperate project all together 
    /// </summary>
    public static class DirectoryStructure
    {
        /// <summary>
        /// Gets the directories topLevel content
        /// </summary>
        /// <param name="fullPath">The full path to the directory </param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            // create empty list
            var items = new List<DirectoryItem>();
            #region get folders

            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
            }
            catch { }
            #endregion
            #region get files

            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                    items.AddRange(fs.Select(f => new DirectoryItem { FullPath = f, Type = DirectoryItemType.File }));
            }
            catch { } 
            #endregion

            return items;
        }

        /// <summary>
        /// gets all logical drives on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            // get every logical drive
            // but now we do not have anything to do with the ui

            // this returns a list.
            // each item on that list is a new directoryItem, where full path and type(drive) is set
            // each item comes from a string[] that is returned from GetLocicalDrives, a static method in the Directory namespace
            // it is selected (drive is one element in the strin[]), and from it fullpath is taken 
            // (each element in the string[] that is returned by Directory.GetLogicalDrives() is simply the full path)

            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();

            
        }

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
