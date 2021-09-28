using Microsoft.EntityFrameworkCore;
using SCommerce.Main.Entities;
using SCommerce.Main.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommerce.Main.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task AddAsync(Product product)
        {
            using (var db = new SCommerceDb())
            {
                db.Products.Add(product);

                await db.SaveChangesAsync();
            }
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            using (var db = new SCommerceDb())
            {
                var product = await db.Products
                    .Include(p => p.Images)
                    .FirstOrDefaultAsync(p => p.Id == id);

                return product;

            }            
        }

        public async Task<List<Product>> ListAsync()
        {
            using(var db = new SCommerceDb())
            {

                return await db.Products.Include(p => p.Images).ToListAsync();
            }
        }
    }
}
