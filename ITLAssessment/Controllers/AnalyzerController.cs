using AnalyzerCore;
using ITLAssessmentWebapp.Models;
using Microsoft.AspNetCore.Mvc;


namespace ITLAssessmentWebapp.Controllers
{
    public class AnalyzerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AnalyzeCSVFile(FileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var lines = new List<string>();
                using (var reader = new StreamReader(model.CSVFile.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                    {
                        lines.Add(reader.ReadLine());
                    }
                }

                var result = CSVAnalyzer.Analyze(lines);

                var resultModel = new ITLAssessmentWebapp.Models.AnalysisResult
                {
                    EarliestDate = result.EarliestDate,
                    LatestDate = result.LatestDate,
                    TotalCost = result.TotalCost,
                    HighestTotalCostPerProduct = result.HighestTotalCostPerProduct,
                    AverageQuantity = result.AverageQuantity
                };

                return View("~/Views/CSVAnalyzer/AnalysisResult.cshtml", resultModel);
            }

            return View("Index", model);
        }
    }
}
