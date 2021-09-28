using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace SCommerce.Main.Common
{
    public class ImageUtils
    {

        public static async Task<BitmapImage> ConvertToBitmapImageAsync(StorageFile file)
        {
            if (file != null)
            {
                using (var stream = file.OpenReadAsync().AsTask().Result)
                {
                    var bi = new BitmapImage();
                    await bi.SetSourceAsync(stream);
                    return bi;
                }
            }
            else
            {
                throw new ArgumentException("File must be provided");
            }
        }
        public async static Task<BitmapImage> ConvertToBitmapImageAsync(string imagePath)
        {
            if (imagePath != null)
            {
                var path = Path.Combine("Images", imagePath);
                var file = await ApplicationData.Current.LocalFolder.GetFileAsync(path);

                using (var stream = file.OpenReadAsync().AsTask().Result)
                {
                    var bi = new BitmapImage();
                    await bi.SetSourceAsync(stream);
                    return bi;
                }
            }
            else
            {
                throw new ArgumentException("ImagePath must be provided");
            }
        }
    }
}
