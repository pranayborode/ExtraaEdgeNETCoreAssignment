using MobileStoreManager.Entities.DTO;

namespace MobileStoreManager.Services.Interfaces
{
    public interface ISalesReportService
    {
        Task<MonthlySalesReportDTO> GetMonthlySalesReport(DateTime fromDate, DateTime toDate);

        Task<List<MonthlyBrandWiseSalesReportDTO>> GetBrandWiseSalesData(DateTime fromDate, DateTime toDate);

        Task<ProfitLossReportDTO> GetProfitLossReportAsync(DateTime fromDate, DateTime toDate, DateTime previousFromDate, DateTime previousToDate);
    }
}
