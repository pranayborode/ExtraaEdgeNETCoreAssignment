namespace MobileStoreManager.Entities.DTO
{
    public class MonthlyBrandWiseSalesReportDTO
    {
        public string BrandName { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalAmountAfterDiscount { get; set; }

    }
}
