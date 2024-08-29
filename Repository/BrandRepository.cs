using MobileStoreManager.Data;
using MobileStoreManager.Entities;
using MobileStoreManager.Repository.Interfaces;

namespace MobileStoreManager.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddBrand(Brands brands)
        {
            brands.IsActive = 1;
            _context.Brands.Add(brands);
            int result = _context.SaveChanges();
            return result;
        }

        public int DeleteBrand(int brandId)
        {
            int result = 0;
            var brand = _context.Brands.Where(b => b.BrandId == brandId).FirstOrDefault();

            if (brand != null)
            {
                brand.IsActive = 0;
                result = _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Brands> GetAllBrands()
        {
            var brandList =
                from brand in _context.Brands
                where brand.IsActive == 1
                select new Brands
                {
                    BrandId = brand.BrandId,
                    BrandName = brand.BrandName,
                    IsActive = brand.IsActive
                };
            return brandList;
        }

        public int UpdateBrand(Brands brands)
        {
            int result = 0;
            var _brand = _context.Brands.Where(b => b.BrandId == brands.BrandId).FirstOrDefault();

            if (_brand != null) 
            {
                _brand.BrandName = brands.BrandName;
                _brand.IsActive = 1;

                result = _context.SaveChanges();
            }
            return result;
        }
    }
}
