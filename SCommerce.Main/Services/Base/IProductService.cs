using SCommerce.Main.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace SCommerce.Main.Services.Base
{
    public interface IProductService
    {
        Task<Product> FindByIdAsync(int id);
        Task<Product> AddAsync(string title, string description, int rating, double price, IList<StorageFile> images);

        Task<List<Product>> ListAsync();
    }
}