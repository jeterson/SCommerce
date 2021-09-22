using SCommerce.Main.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommerce.Main.Services
{
    public class CartService : ICartService
    {
        private Dictionary<int, int> cart;

        public CartService()
        {
            cart = new Dictionary<int, int>();
        }
        public void Add(int productId, int quantity)
        {
            if (cart.ContainsKey(productId))
            {
                cart[productId] += quantity;
            }
            else
            {
                cart.Add(productId, quantity);
            }
        }
    }
}
