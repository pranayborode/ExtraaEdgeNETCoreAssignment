using MobileStoreManager.Entities;
using MobileStoreManager.Entities.DTO;

namespace MobileStoreManager.Repository.Interfaces
{
    public interface IProductRepository
    {
        int AddProduct(Product product);
        int UpdateProduct(Product product);

        Task BulkAddProductsAsync(Product product);

        Task BulkUpdateProductsAsync(Product product);

        IEnumerable<ProductDTO> GetAllProducts();

        Product GetProductById(int productId);

        int DeleteProduct(int productId);
    }
}
