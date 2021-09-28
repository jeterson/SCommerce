using Prism.Mvvm;
using Prism.Windows.Mvvm;
using SCommerce.Main.Common;
using SCommerce.Main.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace SCommerce.Main.ViewModels
{
    public class CartItemViewModel : BindableBase
    {
        private int productId;
        public int ProductId
        {
            get { return productId; }
            set { SetProperty(ref productId, value); }

        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }

        }
        private double price;
        public double Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }

        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }

        }

        

        private BitmapImage image;
        public BitmapImage Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }

        }

        private string imagePath;
        public string ImagePath
        {
            get { return imagePath; }
            set { SetProperty(ref imagePath, value); }

        }

        private Action<int, int> AddItemAction;
        private Action<int> RemoveItemAction;
        private Action<int, int> SubtractItemAction;


        public static CartItemViewModel Create(CartEntry cartEntry, Action<int, int> addItem, Action<int, int> subtractFromItem, Action<int> removeItem)
        {

            
            return new CartItemViewModel
            {
                ProductId = cartEntry.ProductId,
                Price = cartEntry.Price,
                Quantity = cartEntry.Quantity,                
                Title = cartEntry.Title,
                ImagePath = cartEntry.Image,
                AddItemAction = addItem,
                RemoveItemAction = removeItem,
                SubtractItemAction = subtractFromItem
            };
        }


        public async void LoadThumnail()
        {
            Image = await ImageUtils.ConvertToBitmapImageAsync(ImagePath);
        }

        public void Add()
        {
            AddItemAction.Invoke(ProductId, 1);
        }
        public void Remove()
        {
            RemoveItemAction.Invoke(ProductId);
        }
        public void Subtract()
        {
            SubtractItemAction.Invoke(ProductId, 1);
        }

    }
}
