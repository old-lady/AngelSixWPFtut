using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Video02
{
    /// <summary>
    /// Converts a full path to a specific image type of a drive, folder or file.
    /// </summary>
    
    // attribute for easier findings
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // use debugger to see what is passed to value when this app runs!

            // get the full path
            var path = (string)value;

            // if path is null, ignore
            if (path == null)
                return null;

            // get the name of the item
            var name = MainWindow.GetFileFolderName(path);

            // default
            string image = "Images/Document-Blank-icon.png";

            // if the name is blank, we presume it's a drive, as a file or folder always has a name.
            // for drives that name would be label?

            if (string.IsNullOrEmpty(name))
                image = "Images/Home-icon.png";
            // check if it is a foler (else it must be file, and just stay default)
            if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
                image = "Images/Folder-icon.png";

            // pack://application:,,, is where the resourses in the file explorer are located
            // those pics are not where you would think...

            //return new BitmapImage(new Uri($"pack://application:,,,/Images/Folder-icon.png"));
            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));

            // a direct path works too, but since the app can be located diffrently on another mashine
            // a refrence to the refrences packeges is better, as those follow the app
            //return new BitmapImage(new Uri("D:\\PrgTek13\\ADO02\\AngelSixWPFtut\\Video02\\Images\\Folder-icon.png"));

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
