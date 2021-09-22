using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SCommerce.Main.Entities;
using SCommerce.Main.Services.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommerce.Main.ViewModels
{
    public class ProductDetailsPageViewModel : ViewModelBase
    {

        #region Atributos
        private readonly IProductService productService;
        private readonly ICartService cartService;
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
        private List<string> images =new List<string>();
        public List<string> Images
        {
            get { return images; }
            set { SetProperty(ref images, value); }
        }
        private string selectedImage;
        

        public string SelectedImage
        {
            get { return selectedImage; }
            set { SetProperty(ref selectedImage, value); }
        }

        #endregion

        #region Commands
        private DelegateCommand addToCart;
        public DelegateCommand AddToCart =>
            addToCart ?? (addToCart = new DelegateCommand(ExecuteAddToCart));

        void ExecuteAddToCart()
        {
            cartService.Add(model.Id, 1);
        }
        #endregion

        public ProductDetailsPageViewModel(IProductService productService, ICartService cartService)
        {
            this.productService = productService;
            this.cartService = cartService;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            await LoadProductAsync(1);

        }

        private async Task LoadProductAsync(int id)
        {

            model = await productService.FindByIdAsync(id);

            Title = model.Title;
            Description = model.Description;
            Price = model.Price;
            Rating = model.Rating;
            Images = model.Images;
            SelectedImage = model.Images.FirstOrDefault();
        }


    }
}
