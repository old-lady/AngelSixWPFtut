using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Video03
{
    /// <summary>
    /// A viewmodel for each directory item
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        #region Public properties
        public string FullPath { get; set; }
        public DirectoryItemType Type { get; set; }

        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(FullPath); } }


        /// <summary>
        /// A list of all children contaned inside this item.
        /// </summary>
        // a list with a INotifyPropertyChanged interface
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        /// <summary>
        /// indicates if this instance of directoryItemviewmodel can be expanded
        /// </summary>
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }

        public bool IsExpanded
        {
            get
            {
                // returns true, if there are children on the list, that are not null (as we have a dummy to show expandable icon)
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                // if the ui wants us to expand...
                if (value == true)
                    Expand();
                // else it wants us to close
                else
                {
                    ClearChildren();
                }
            }
        }
        #endregion

        #region Constructor

        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            this.ExpandCommand = new RelayCommand(Expand);

            this.FullPath = fullPath;
            this.Type = type;

            // not only does this method clear, it also adds a dummy item - and we need that to
            // show the ui it can expand.
            ClearChildren();
        }
        #endregion

        #region Public Commands
        /// <summary>
        /// Command to expand this item
        /// </summary>
        public ICommand ExpandCommand { get; set; }

        #endregion
        /// <summary>
        /// Expands this directory and finds all children
        /// </summary>
        private void Expand()
        {
            if (this.Type == DirectoryItemType.File)
                return;

            var children = DirectoryStructure.GetDirectoryContents(this.FullPath);
            this.Children = new ObservableCollection<DirectoryItemViewModel>
                ( children.Select(content => new DirectoryItemViewModel (content.FullPath, content.Type )));
        }
        #region Helper methods
        /// <summary>
        /// Clears the children from list, adds dummy icon so UI shows expandable icon
        /// </summary>
        private void ClearChildren()
        {
            Children = new ObservableCollection<DirectoryItemViewModel>();

            // add dummy, if we are not a file
            if (Type != DirectoryItemType.File)
                Children.Add(null);
        }
        #endregion
    }
}
