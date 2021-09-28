using Prism.Events;
using Prism.Mvvm;
using Prism.Windows.Navigation;
using SCommerce.Main.Common;
using SCommerce.Main.Events;
using SCommerce.Main.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace SCommerce.Main.ViewModels
{
    public class HeaderViewModel : BindableBase
    {
        #region Attributes
        private readonly INavigationService navigationService;
        private readonly IEventAggregator eventAggregator;
        
        #endregion

        #region Properties
        private int cartQuantity = 0;
        public int CartQuantity
        {
            get { return cartQuantity; }
            set { SetProperty(ref cartQuantity, value); }
        }
        #endregion

        public HeaderViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            this.navigationService = navigationService;
            this.eventAggregator = eventAggregator;

            eventAggregator.GetEvent<AddToCartEvent>().Subscribe(HandleAddToCartEvent);
            eventAggregator.GetEvent<SubtractedFromCartEvent>().Subscribe(HandleSubtractedCartEvent);
        }

        private void HandleSubtractedCartEvent(SubtractedFromCartEvent.PayloadCart payload)
        {
            CartQuantity -= payload.Quantity;
        }

        private void HandleAddToCartEvent(AddToCartEvent.PayloadCart payload)
        {
            CartQuantity += payload.Quantity;
            
        }

        public async void OpenAddProduct()
        {
            var view = CoreApplication.CreateNewView();
            int viewId = 0;
            await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => 
            {
                var page = new ProductFormPage();
                Window.Current.Content = page;
                Window.Current.Activate();
                viewId = ApplicationView.GetForCurrentView().Id;
            });

            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(viewId);
        }

        public void NavigateToCartPage()
        {
            navigationService.Navigate(PageTokens.CartPage, null);
        }
    }
}
