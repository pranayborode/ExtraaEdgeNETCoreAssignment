using MobileStoreManager.Entities;
using MobileStoreManager.Entities.DTO;
using MobileStoreManager.Repository.Interfaces;
using MobileStoreManager.Services.Interfaces;

namespace MobileStoreManager.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public int AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public int UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }

        public async Task BulkAddProductsAsync(List<Product> productsList)
        {
            foreach (var product in productsList)
            {
                await _productRepository.BulkAddProductsAsync(product);
            }
        }

        public async Task BulkUpdateProductsAsync(List<Product> productsList)
        {
            foreach (var product in productsList)
            {
                await _productRepository.BulkUpdateProductsAsync(product);
            }
        }

        public int DeleteProduct(int productId)
        {
            return _productRepository.DeleteProduct(productId);
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
           return _productRepository.GetAllProducts();
        }

        public Product GetProductById(int productId)
        {
           return _productRepository.GetProductById(productId);
        }
    }
}
