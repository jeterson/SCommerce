using SCommerce.Main.Entities;
using System.Threading.Tasks;

namespace SCommerce.Main.Services.Base
{
    public interface IProductService
    {
        Task<Product> FindByIdAsync(int id);
    }
}