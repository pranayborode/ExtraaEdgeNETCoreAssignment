using Microsoft.EntityFrameworkCore;
using MobileStoreManager.Data;
using MobileStoreManager.Entities;
using MobileStoreManager.Entities.DTO;
using MobileStoreManager.Repository.Interfaces;

namespace MobileStoreManager.Repository
{
    public class SalesReportRepository : ISalesReportRepository
    {
        private readonly ApplicationDbContext _context;

        public SalesReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<MonthlySalesReportDTO> GetMonthlySalesReport(DateTime fromDate, DateTime toDate)
        {
            var salesDetails = await _context.Orders
                 .Where(o => o.OrderDate >= fromDate && o.OrderDate <= toDate)
                 .GroupBy(o => o.OrderDate.Value.Date)
                 .Select(ds => new DailySalesDTO
                 {
                     Date = ds.Key,
                     TotalAmount = ds.Sum(s => s.SalePrice * s.Quantity),
                     QuantitySold = ds.Sum(s => s.Quantity),
                     TotalDiscount = ds.Sum(s => (s.SalePrice * s.Quantity) * (s.Discount / 100)),
                     TotalAmountAfterDiscount = ds.Sum(x => (x.SalePrice * (1 - (x.Discount / 100))) * x.Quantity)
                 }).ToListAsync();

            var totalAmount = salesDetails.Sum(s => s.TotalAmount);
            var totalQuantitySold = salesDetails.Sum(s => s.QuantitySold);
            var totalDiscount = salesDetails.Sum(s => s.TotalDiscount);
            var totalAmountAfterDiscount = salesDetails.Sum(s => s.TotalAmountAfterDiscount);

            return new MonthlySalesReportDTO
            {
                FromDate = fromDate,
                ToDate = toDate,
                TotalAmount = totalAmount,
                TotalQuantitySold = totalQuantitySold,
                TotalDiscount = totalDiscount,
                TotalAmountAfterDiscount = totalAmountAfterDiscount,
                SalesDetails = salesDetails
            };
        }

        public async Task<List<MonthlyBrandWiseSalesReportDTO>> GetBrandWiseSalesData(DateTime fromDate, DateTime toDate)
        {
            var brandWiseSales = await (from o in _context.Orders
                                        join p in _context.Products on o.ProductId equals p.ProductId
                                        join b in _context.Brands on p.BrandId equals b.BrandId
                                        where o.OrderDate >= fromDate && o.OrderDate <= toDate
                                        group new { o, p } by b.BrandName into bs
                                        select new MonthlyBrandWiseSalesReportDTO
                                        {
                                            BrandName = bs.Key,
                                            TotalOrders = bs.Count(),
                                            TotalAmount = bs.Sum(s => s.o.SalePrice * s.o.Quantity),
                                            TotalQuantitySold = bs.Sum(s => s.o.Quantity),
                                            TotalDiscount = bs.Sum(s => (s.o.SalePrice * s.o.Discount / 100) * s.o.Quantity),
                                            TotalAmountAfterDiscount = bs.Sum(s => (s.o.SalePrice * (1 - (s.o.Discount / 100))) * s.o.Quantity)
                                        }).ToListAsync();

            return brandWiseSales;
        }

        public async Task<ProfitLossReportDTO> GetProfitLossReportAsync(DateTime fromDate, DateTime toDate, DateTime previousFromDate, DateTime previousToDate)
        {
         
            var currentPeriodData = await _context.Orders
                .Where(o => o.OrderDate >= fromDate && o.OrderDate <= toDate)
                .Include(o => o.Product) 
                .ToListAsync();

            var currentTotalRevenue = currentPeriodData.Sum(o => o.SalePrice * o.Quantity);
            var currentTotalCost = currentPeriodData.Sum(o => o.Product.Price * o.Quantity); 
            var currentTotalDiscounts = currentPeriodData.Sum(o => o.SalePrice * (o.Discount / 100) * o.Quantity);
            var currentTotalAmountAfterDiscount = currentPeriodData.Sum(o => (o.SalePrice * (1 - (o.Discount / 100))) * o.Quantity);
            var currentProfitOrLoss = currentTotalAmountAfterDiscount - currentTotalCost;

           
            var previousPeriodData = await _context.Orders
                .Where(o => o.OrderDate >= previousFromDate && o.OrderDate <= previousToDate)
                .Include(o => o.Product) 
                .ToListAsync();

            var previousTotalRevenue = previousPeriodData.Sum(o => o.SalePrice * o.Quantity);
            var previousTotalCost = previousPeriodData.Sum(o => o.Product.Price * o.Quantity);
            var previousTotalDiscounts = previousPeriodData.Sum(o => o.SalePrice * (o.Discount / 100) * o.Quantity);
            var previousTotalAmountAfterDiscount = previousPeriodData.Sum(o => (o.SalePrice * (1 - (o.Discount / 100))) * o.Quantity);
            var previousProfitOrLoss = previousTotalAmountAfterDiscount - previousTotalCost;

            var revenueChangePercentage = (previousTotalRevenue != 0)
                ? ((currentTotalRevenue - previousTotalRevenue) / previousTotalRevenue) * 100
                : 0;

            var profitLossChangePercentage = (previousProfitOrLoss != 0)
                ? ((currentProfitOrLoss - previousProfitOrLoss) / previousProfitOrLoss) * 100
                : 0;

            return new ProfitLossReportDTO
            {
                CurrentPeriod = new PeriodDataDTO
                {
                    TotalRevenue = currentTotalRevenue,
                    TotalCost = currentTotalCost,
                    TotalDiscounts = currentTotalDiscounts,
                    ProfitOrLoss = currentProfitOrLoss
                },
                PreviousPeriod = new PeriodDataDTO
                {
                    TotalRevenue = previousTotalRevenue,
                    TotalCost = previousTotalCost,
                    TotalDiscounts = previousTotalDiscounts,
                    ProfitOrLoss = previousProfitOrLoss
                },
                Comparison = new ProfitLossComparisonDTO
                {
                    RevenueChangePercentage = revenueChangePercentage,
                    ProfitLossChangePercentage = profitLossChangePercentage
                }
            };
        }

    }
}
