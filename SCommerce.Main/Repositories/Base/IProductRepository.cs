using SCommerce.Main.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCommerce.Main.Repositories.Base
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<Product> FindByIdAsync(int id);
        Task<List<Product>> ListAsync();
    }
}