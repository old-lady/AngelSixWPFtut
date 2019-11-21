



namespace Video03
{
    /// <summary>
    /// Information about a directory item, such as a drive, file or folder.
    /// datamodel, is it tile folder or drive?
    /// </summary>
    public class DirectoryItem
    {
        
        // Type of the item
        public DirectoryItemType Type { get; set; }

        // Absolute path to the item
        public string FullPath { get; set; }

        // we use a function to get the name (or use get file name)
        public string Name { get { return
                    // check if we have a drive
                    this.Type == DirectoryItemType.Drive?
                    // if yes name is just the full path
                    this.FullPath :
                    // else we use the method to get what is after the / in the full path string
                    DirectoryStructure.GetFileFolderName(FullPath); } }
    }
}
