namespace MobileStoreManager.Entities.DTO
{
    public class ProfitLossReportDTO
    {
        public PeriodDataDTO CurrentPeriod { get; set; }
        public PeriodDataDTO PreviousPeriod { get; set; }
        public ProfitLossComparisonDTO Comparison { get; set; }
    }
}
