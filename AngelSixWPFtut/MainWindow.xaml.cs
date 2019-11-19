using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AngelSixWPFtut
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SolidColorBrush color01 = (SolidColorBrush)new BrushConverter().ConvertFrom("#EECF62");
        public MainWindow()
        {
            InitializeComponent();
            //Border.Background = color01;
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The description is {this.DescriptionText.Text}");


        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            this.DrillCheckbox.IsChecked =
            this.WeldCheckbox.IsChecked =
            this.AssamblyCheckbox.IsChecked =
            this.PlasmaCheckbox.IsChecked =
            this.LaserCheckbox.IsChecked =
            this.PurchaseCheckbox.IsChecked =

            this.LatheCheckbox.IsChecked =
            this.DrillCheckbox.IsChecked =
            this.FoldCheckbox.IsChecked =
            this.RollCheckbox.IsChecked =
            this.SawCheckbox.IsChecked
            = false;
        }

        private void Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            // sender is the object that is sent with the event, it is now object type
            // we cast it to checkbox, that is was before ending up here, so be can access its properties
            this.LengthText.Text += ((CheckBox)sender).Content;
        }
        private void FinishDropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.NoteText == null) return;
            var combo = (ComboBox)sender;
            var value = (ComboBoxItem)combo.SelectedValue;

            // problems here because
            // combobox fires this when it is created, as it has a default value - so it changes selection upon creation
            // since note text box first is created after combobox, is not not made, the first time this event fires
            // so it rises a null exeption :)
            // this is why we check for null at the beginning of this event.

            // check Window_loaded event for way to avoid this!
            this.NoteText.Text = (string)value.Content;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FinishDropdown_SelectionChanged(this.FinishDropdown, null);
            MessageBox.Show("Thanks for being awesome!");
        }

        private void SupplierNameText_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.MassText.Text = this.SupplierNameText.Text;
        }
    }
}
