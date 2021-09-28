using SCommerce.Main.Entities;
using SCommerce.Main.Repositories.Base;
using SCommerce.Main.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace SCommerce.Main.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }
        public Task<Product> FindByIdAsync(int id) => repository.FindByIdAsync(id);

        public Task<List<Product>> ListAsync() => repository.ListAsync();

        public async Task<Product> AddAsync(string title, string description, int rating, double price, IList<StorageFile> images)
        {

            var fileNames = new List<ProductImage>();
            var destFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("Images", CreationCollisionOption.OpenIfExists);
            foreach (var image in images)
            {
                
                var file = await image.CopyAsync(destFolder, image.Name, NameCollisionOption.GenerateUniqueName);
                fileNames.Add(new ProductImage { Path = file.Name });
            }
            var product = new Product
            {
                Price = price,
                Description = description,
                Title = title,
                Rating = rating,
                Images = fileNames
            };

            await repository.AddAsync(product);
            return product;
        }
    }
}
