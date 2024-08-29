using Microsoft.EntityFrameworkCore;
using MobileStoreManager.Data;
using MobileStoreManager.Entities;
using MobileStoreManager.Entities.DTO;
using MobileStoreManager.Repository.Interfaces;

namespace MobileStoreManager.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddProduct(Product product)
        {

            product.IsActive = 1;
            product.AddedDate = DateTime.Now;
            _context.Products.Add(product);
            int result = _context.SaveChanges();
            return result;
        }

        public int UpdateProduct(Product product)
        {
            int result = 0;
            var _product = _context.Products.Where(m => m.ProductId == product.ProductId).FirstOrDefault();

            if (_product != null)
            {
                _product.BrandId = product.BrandId;
                _product.Model = product.Model;
                _product.Price = product.Price;
                _product.IsActive = 1;
                _product.AddedDate = product.AddedDate;
                _product.ModifiedDate = DateTime.Now;

                result = _context.SaveChanges();
            }
            return result;
        }

        public async Task BulkAddProductsAsync(Product product)
        {
            product.IsActive = 1;
            product.AddedDate = DateTime.Now;
            _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

        }

        public async Task BulkUpdateProductsAsync(Product product)
        {

            var _product = await _context.Products
                                .FirstOrDefaultAsync(m => m.ProductId == product.ProductId);

            if (_product != null)
            {
                _product.BrandId = product.BrandId;
                _product.Model = product.Model;
                _product.Price = product.Price;
                _product.IsActive = 1;
                _product.AddedDate = product.AddedDate;
                _product.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync();
            }
        }

        public int DeleteProduct(int productId)
        {
            int result = 0;
            var product = _context.Products.Where(m => m.ProductId == productId).FirstOrDefault();

            if (product != null)
            {
                product.IsActive = 0;
                product.ModifiedDate = DateTime.Now;
                result = _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var productList =
               from p in _context.Products
               join b in _context.Brands
               on p.BrandId equals b.BrandId
               where p.IsActive == 1
               select new ProductDTO
               {
                   ProductId = p.ProductId,
                   BrandId = p.BrandId,
                   BrandName = b.BrandName,
                   Model = p.Model,
                   Price = p.Price,
                   IsActive = p.IsActive,
                   AddedDate = p.AddedDate,
                   ModifiedDate = p.ModifiedDate,
               };
            return productList;
        }

        public Product GetProductById(int productId)
        {
            var product = _context.Products.Where(m => m.ProductId == productId).FirstOrDefault();
            return product;
        }

    }
}
