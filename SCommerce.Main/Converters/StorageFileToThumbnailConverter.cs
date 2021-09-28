using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace SCommerce.Main.Converters
{
    public class StorageFileToThumbnailConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is StorageFile file)
            {
                using (var stream = file.OpenReadAsync().AsTask().Result)
                {                    
                    var bi = new BitmapImage();
                    bi.SetSource(stream);
                    return bi;
                }

            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
