namespace MobileStoreManager.Entities.DTO
{
    public class PeriodDataDTO
    {
        public decimal TotalRevenue { get; set; }        
        public decimal TotalCost { get; set; }              
        public decimal TotalDiscounts { get; set; }        
        public decimal TotalAmountAfterDiscount { get; set; } 
        public decimal ProfitOrLoss { get; set; }
    }
}
