namespace MobileStoreManager.Entities.DTO
{
    public class DailySalesDTO
    {
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public int QuantitySold { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalAmountAfterDiscount { get; set; }   
    }
}
