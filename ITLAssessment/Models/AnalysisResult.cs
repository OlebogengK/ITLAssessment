namespace ITLAssessmentWebapp.Models
{
    public class AnalysisResult
    {
        public string EarliestDate { get; set; }
        public string LatestDate { get; set; }
        public double TotalCost { get; set; }
        public string HighestTotalCostPerProduct { get; set; }
        public double AverageQuantity { get; set; }
    }
}
