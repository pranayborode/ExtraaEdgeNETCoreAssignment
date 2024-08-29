using MobileStoreManager.Entities;
using MobileStoreManager.Repository.Interfaces;
using MobileStoreManager.Services.Interfaces;

namespace MobileStoreManager.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public int AddBrand(Brands brands)
        {
            return _brandRepository.AddBrand(brands);
        }

        public int DeleteBrand(int brandId)
        {
           return _brandRepository.DeleteBrand(brandId);
        }

        public IEnumerable<Brands> GetAllBrands()
        {
            return _brandRepository.GetAllBrands();
        }

        public int UpdateBrand(Brands brands)
        {
            return _brandRepository.UpdateBrand(brands);    
        }
    }
}
