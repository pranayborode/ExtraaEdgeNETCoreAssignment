using MobileStoreManager.Entities;

namespace MobileStoreManager.Services.Interfaces
{
    public interface IBrandService
    {
        int AddBrand(Brands brands);
        int UpdateBrand(Brands brands);
        IEnumerable<Brands> GetAllBrands();

        //Brands GetBrandById(int brandId);

        int DeleteBrand(int brandId);
    }
}
