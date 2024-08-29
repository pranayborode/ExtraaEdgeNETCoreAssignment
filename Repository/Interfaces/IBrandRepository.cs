using MobileStoreManager.Entities;

namespace MobileStoreManager.Repository.Interfaces
{
    public interface IBrandRepository
    {
        int AddBrand(Brands brands);
        int UpdateBrand(Brands brands);
        IEnumerable<Brands> GetAllBrands();

        //Brands GetBrandById(int brandId);

        int DeleteBrand(int brandId);
        
    }
}
