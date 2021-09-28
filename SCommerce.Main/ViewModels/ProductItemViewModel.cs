using Prism.Mvvm;
using SCommerce.Main.Common;
using SCommerce.Main.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace SCommerce.Main.ViewModels
{
   public class ProductItemViewModel: BindableBase
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public int Id { get; set; }

        private double price;
        public double Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }

        private BitmapImage thumbnail;
        public BitmapImage Thumbnail
        {
            get { return thumbnail; }
            set { SetProperty(ref thumbnail, value); }
        }

        public string ImagePath { get; set; }


        public ProductItemViewModel(Product product)
        {
            Title = product.Title;
            price = product.Price;
            Id = product.Id;
            ImagePath = product.Images.FirstOrDefault()?.Path;
        }

        public async void LoadThumbnail()
        {
            
            if(ImagePath != null)
            {                
                Thumbnail = await ImageUtils.ConvertToBitmapImageAsync(ImagePath);
            }
        }
    }
}
