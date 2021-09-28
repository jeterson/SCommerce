using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SCommerce.Main.Common;
using SCommerce.Main.Entities;
using SCommerce.Main.Services.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace SCommerce.Main.ViewModels
{
    public class ProductDetailsPageViewModel : ViewModelBase
    {
        
        #region Atributos
        private readonly IProductService productService;
        private readonly ICartService cartService;
        private readonly IResourceLoader resourceLoader;
        private Product model;
        #endregion

        #region Propriedades
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }

        private int rating;
        public int Rating
        {
            get { return rating; }
            set { SetProperty(ref rating, value); }
        }
        private List<BitmapImage> images;
        public List<BitmapImage> Images
        {
            get { return images; }
            set { SetProperty(ref images, value); }
        }
        private BitmapImage selectedImage;


        public BitmapImage SelectedImage
        {
            get { return selectedImage; }
            set { SetProperty(ref selectedImage, value); }
        }

        #endregion

        #region Commands
        private DelegateCommand addToCart;
        public DelegateCommand AddToCart =>
            addToCart ?? (addToCart = new DelegateCommand(ExecuteAddToCart));

        async void ExecuteAddToCart()
        {
            await cartService.AddAsync(model.Id, 1);
        }
        #endregion

        public ProductDetailsPageViewModel(IProductService productService, ICartService cartService, IResourceLoader resourceLoader)
        {
            this.productService = productService;
            this.cartService = cartService;
            this.resourceLoader = resourceLoader;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            var productId = (int) e.Parameter;
            await LoadProductAsync(productId);

        }

        private async Task LoadProductAsync(int id)
        {

            model = await productService.FindByIdAsync(id);

            var saleLabel = resourceLoader.GetString("SaleLabel");

            Title = $"{model.Title} ({saleLabel})";
            Description = model.Description;
            Price = model.Price;
            Rating = model.Rating;
            var list = await LoadImagesAsync();
            Images = list;
            SelectedImage = Images.FirstOrDefault();
        }

        private async Task<List<BitmapImage>> LoadImagesAsync()
        {
            var list = new List<BitmapImage>();
            foreach (var item in model.Images)
            {
                var bi = await ImageUtils.ConvertToBitmapImageAsync(item.Path);
                list.Add(bi);

            }

            return list;
            
        }

        public async void AddToCartMethod()
        {
           await cartService.AddAsync(model.Id, 1);
        }


    }
}
