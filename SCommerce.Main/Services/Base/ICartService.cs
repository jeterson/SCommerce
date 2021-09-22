namespace SCommerce.Main.Services.Base
{
    public interface ICartService
    {
        void Add(int productId, int quantity);
    }
}