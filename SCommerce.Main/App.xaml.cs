using Microsoft.Practices.Unity;
using Prism.Unity.Windows;
using Prism.Windows.AppModel;
using SCommerce.Main.Common;
using SCommerce.Main.Entities;
using SCommerce.Main.Repositories;
using SCommerce.Main.Repositories.Base;
using SCommerce.Main.Services;
using SCommerce.Main.Services.Base;
using SCommerce.Main.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SCommerce.Main
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : PrismUnityApplication
    {
        protected override async Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {

           
                using (var db = new SCommerceDb())
                {
                    await db.Database.EnsureCreatedAsync();
                }
                NavigationService.Navigate(PageTokens.ProductsPage, null);
            

            
        }

        protected override UIElement CreateShell(Frame rootFrame)
        {
            var appShell = new AppShell();
            appShell.SetFrame(rootFrame);
            return appShell;
            
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterInstance(typeof(IResourceLoader), new ResourceLoaderAdapter(new ResourceLoader()), new ContainerControlledLifetimeManager());
            RegisterTypeIfMissing(typeof(IProductService), typeof(ProductService), false);
            RegisterTypeIfMissing(typeof(ICartService), typeof(CartService), true);
            RegisterTypeIfMissing(typeof(IProductRepository), typeof(ProductRepository), false);
        }
    }
}

