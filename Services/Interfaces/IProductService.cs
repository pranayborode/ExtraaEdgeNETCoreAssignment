using MobileStoreManager.Entities;
using MobileStoreManager.Entities.DTO;

namespace MobileStoreManager.Services.Interfaces
{
    public interface IProductService
    {

        int AddProduct(Product product);
        int UpdateProduct(Product product);

        Task BulkAddProductsAsync(List<Product> productsList);

        Task BulkUpdateProductsAsync(List<Product> productsList);

        IEnumerable<ProductDTO> GetAllProducts();

        Product GetProductById(int productId);

        int DeleteProduct(int productId);

    }
}
