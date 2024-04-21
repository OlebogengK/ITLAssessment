using AnalyzerCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ITLAssessmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyzerController : ControllerBase
    {
        [HttpPost("analyze-csv")]
        public IActionResult AnalyzeCSV([FromBody] string csvData)
        {
            var lines = csvData.Split(Environment.NewLine);
            List<string> linesList = lines.ToList();
            var analysisResult = CSVAnalyzer.Analyze(linesList);

            var json = JsonConvert.SerializeObject(analysisResult);

            return Ok(json);
        }
    }
}
