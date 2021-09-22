using SCommerce.Main.Entities;
using SCommerce.Main.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommerce.Main.Services
{
    public class ProductService : IProductService
    {
        public Task<Product> FindByIdAsync(int id)
        {
            var result = new Product
            {
                Id = 1,
                Price = 99.99,
                Description = "Some nice description for this amazing product",
                Rating = 5,
                Title = "Female T-Shirts",
                Images = {
                    "ms-appx:///Assets/Images/shirt5.jpg",
                    "ms-appx:///Assets/Images/shirt4.jpg",
                    "ms-appx:///Assets/Images/shirt5.jpg",
                    "ms-appx:///Assets/Images/shirt5.jpg",
                }

            };

            return Task.FromResult(result);
        }
    }
}
