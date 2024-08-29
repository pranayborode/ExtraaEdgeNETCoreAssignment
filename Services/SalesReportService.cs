using MobileStoreManager.Entities.DTO;
using MobileStoreManager.Repository.Interfaces;
using MobileStoreManager.Services.Interfaces;

namespace MobileStoreManager.Services
{
    public class SalesReportService : ISalesReportService
    {
        private readonly ISalesReportRepository _salesReportRepository;
        public SalesReportService(ISalesReportRepository salesReportRepository)
        {
            _salesReportRepository = salesReportRepository;
        }


        public async Task<MonthlySalesReportDTO> GetMonthlySalesReport(DateTime fromDate, DateTime toDate)
        {
            return await _salesReportRepository.GetMonthlySalesReport(fromDate, toDate);
        }


        public async Task<List<MonthlyBrandWiseSalesReportDTO>> GetBrandWiseSalesData(DateTime fromDate, DateTime toDate)
        {
            return await _salesReportRepository.GetBrandWiseSalesData(fromDate, toDate);
        }

        public async Task<ProfitLossReportDTO> GetProfitLossReportAsync(DateTime fromDate, DateTime toDate, DateTime previousFromDate, DateTime previousToDate)
        {
            return await _salesReportRepository.GetProfitLossReportAsync(fromDate, toDate, previousFromDate, previousToDate);
        }
    }
}
