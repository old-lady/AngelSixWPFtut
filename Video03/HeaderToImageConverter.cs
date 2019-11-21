using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Video03
{
    /// <summary>
    /// Converts a full path to a specific image type of a drive, folder or file.
    /// </summary>
    
    // attribute for easier findings
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {



            // default
            string image = "Images/Document-Blank-icon.png";

            switch ((DirectoryItemType)value)
            {
                case DirectoryItemType.Drive:
                    image = "Images/Home-icon.png";
                    break;
                case DirectoryItemType.File:
                    image = "Images/Document-Blank-icon.png";
                    break;
                case DirectoryItemType.Folder:
                    image = "Images/Folder-icon.png";
                    break;
                default:
                    image = "Images/Document-Blank-icon.png";
                    break;
            }

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
