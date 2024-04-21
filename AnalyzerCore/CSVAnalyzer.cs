using System.Globalization;
using System.Net.Security;
using System.Diagnostics;


namespace AnalyzerCore
{
    public static class CSVAnalyzer
    {
        public static AnalysisResult Analyze(List<string> lines)
        {
            var result = new AnalysisResult();
            Debug.WriteLine("Hello");

      
            var productQuantities = new Dictionary<string, int>();
            var productTotalCosts = new Dictionary<string, double>();
            var productDates = new List<DateTime>();

            var errors = new List<string>();

            foreach (var line in lines)
            {
                var values = line.Split(',');
                Console.WriteLine("hello");

                
                if (values.Length != 4)
                {
                    errors.Add($"Incorrect data format: {line}");
                    continue;
                }

                
                var productCode = values[0];
                var quantity = 0;
                var costPerItem = 0.0;
                var dateStr = values[3];

                if (!int.TryParse(values[1], out quantity) ||
                    !double.TryParse(values[2].Replace("R", "").Replace("$", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out costPerItem) ||
                    !DateTime.TryParseExact(dateStr, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                {
                    errors.Add($"Invalid data type: {line}");
                    continue;
                }

              
                if (!productQuantities.ContainsKey(productCode))
                {
                    productQuantities[productCode] = quantity;
                    productTotalCosts[productCode] = quantity * costPerItem;
                }
                else
                {
                    productQuantities[productCode] += quantity;
                    productTotalCosts[productCode] += quantity * costPerItem;
                }

                productDates.Add(date);
            }

            if (productQuantities.Any())
            {
                Console.WriteLine($"productQuantities count: {productQuantities.Count}");
                Console.WriteLine($"productDates count: {productDates.Count}");
                Console.WriteLine($"productTotalCosts count: {productTotalCosts.Count}");
                result.EarliestDate = productDates.Any() ? productDates.Min().ToString("dd/MM/yyyy HH:mm:ss") : "N/A";
                result.LatestDate = productDates.Any() ? productDates.Max().ToString("dd/MM/yyyy HH:mm:ss") : "N/A";

                result.TotalCost = productTotalCosts.Values.Sum();
                result.HighestTotalCostPerProduct = productTotalCosts.Any() ? productTotalCosts.OrderByDescending(kv => kv.Value).FirstOrDefault().Key : "N/A";
                result.AverageQuantity = productQuantities.Values.Any() ? productQuantities.Values.Average() : 0;
            }
            else
            {
                result.EarliestDate = "N/A";
                result.LatestDate = "N/A";
                result.TotalCost = 0;
                result.HighestTotalCostPerProduct = "N/A";
                result.AverageQuantity = 0;
            }



            result.TotalCost = productTotalCosts.Values.Sum();
            result.HighestTotalCostPerProduct = productTotalCosts.OrderByDescending(kv => kv.Value).FirstOrDefault().Key;
            result.AverageQuantity = productQuantities.Values.Average();

            return result;
        }

    }
    public class AnalysisResult
    {
        public string EarliestDate { get; set; }
        public string LatestDate { get; set; }
        public double TotalCost { get; set; }
        public string HighestTotalCostPerProduct { get; set; }
        public double AverageQuantity { get; set; }
    }
}