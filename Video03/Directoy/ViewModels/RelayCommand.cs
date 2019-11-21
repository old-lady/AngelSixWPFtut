using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Video03
{
    /// <summary>
    /// a basic command that runs an action
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private members

        /// <summary>
        /// action to run
        /// </summary>
        private Action mAction;
        #endregion
        #region Public event
        /// <summary>
        /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        //public event EventHandler CanExecuteChanged;
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion


        #region Constructor
        /// <summary>
        /// Default constuctor
        /// </summary>
        public RelayCommand(Action action)
        {
            mAction = action;
        }
        #endregion

        #region Command Methods

        /// <summary>
        /// a relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) { return true; }

        /// <summary>
        /// Execute the commands action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction();
        }

        #endregion
    }
}
