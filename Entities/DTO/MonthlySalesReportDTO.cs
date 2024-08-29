namespace MobileStoreManager.Entities.DTO
{
    public class MonthlySalesReportDTO
    {
        public DateTime FromDate { get; set; } 
        public DateTime ToDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalAmountAfterDiscount { get; set; }
        public List<DailySalesDTO> SalesDetails { get; set; }
    }
}
