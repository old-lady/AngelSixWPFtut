using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video03
{ 
    /// <summary>
    /// The viewModel for the applications main directory view
    /// (used by the tree structure in xamel)
    /// </summary>
    public class DirectoryStructureViewModel :BaseViewModel
    {
        /// <summary>
        /// A list of logical drives
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        public DirectoryStructureViewModel()
        {
            var children = DirectoryStructure.GetLogicalDrives();
            this.Items = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(drive => new DirectoryItemViewModel(drive.FullPath, drive.Type = DirectoryItemType.Drive)));


        }

    }
}
