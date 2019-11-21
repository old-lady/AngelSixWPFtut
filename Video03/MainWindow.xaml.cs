using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace Video03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary///
        
        public MainWindow()
        {
            
            InitializeComponent();

            // now everything in the ui i bound to this class!
            this.DataContext = new DirectoryStructureViewModel();


            // testing viewModels 
            //var d = new DirectoryStructureViewModel();
            //var item01 = d.Items[0];
            //d.Items[0].ExpandCommand.Execute(null);
            



        }
        #endregion



    }
}
