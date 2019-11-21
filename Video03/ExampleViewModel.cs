

using PropertyChanged;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace Video03
{/// <summary>
/// example of viewModel
/// </summary>


    // Obsolete
    // this is made to work with fody nuget package only?
    //[ImplementPropertyChanged]
    public class ExampleViewModel : INotifyPropertyChanged
    {
        //private string test;

        //----- What is the difference?
        //public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public event PropertyChangedEventHandler PropertyChanged;


        public string Test { get; set; }
        #region How to fire event on set property, this is obsolete with fody package
        //public string Test
        //{
        //    get
        //    {
        //        return test;
        //    }
        //    set
        //    {
        //        if (test == value)
        //            return;
        //        test = value;
        //        PropertyChanged(this, new PropertyChangedEventArgs(nameof(Test)));

        //    }
        //} 
        #endregion
        #region Example how to use task to change property

        //public ExampleViewModel()
        //{
        //    int i = 0;
        //    Task.Run(async () =>
        //    {
        //        while (true)
        //        {
        //            await Task.Delay(200);
        //            Test = (i++).ToString();
        //            //Test += "!";
        //            // but this is not enough, we need to activate PropertyChanged
        //            // we send the eventhander this object, and the arguments test, that it knows
        //            // is the property name that it needs to update
        //            //PropertyChanged(this, new PropertyChangedEventArgs("Test"));

        //            // however this could just be moved into the set property of test...

        //        }
        //    });
        //    //ChangeProperty();
        //} 
        #endregion

        public void ChangeProperty()
        {
            Timer timer = new Timer(2000);
            timer.Elapsed += Timer_Elapsed;

            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Test += "x";
            MessageBox.Show(Test);
            PropertyChanged(this, new PropertyChangedEventArgs("Test"));

        }

        public override string ToString()
        {
            return "hello world";
        }

    }
}
