using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITLAssessWindowsForm
{
    public partial class CSVAnalyzerForm : Form
    {
        public CSVAnalyzerForm()
        {
            InitializeComponent();
        }
        private async void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string csvData = File.ReadAllText(openFileDialog.FileName);

                        var apiClient = new ApiClient("http://localhost:7014");
                        var analysisResultJson = await apiClient.AnalyzeCSV(csvData);

                        var analysisResult = JsonConvert.DeserializeObject<AnalysisResult>(analysisResultJson);

                        DisplayAnalysisResult(analysisResult);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DisplayAnalysisResult(AnalysisResult analysisResult)
        {
            lblEarliestDate.Text = "Earliest Date: " + analysisResult.EarliestDate;
            lblLatestDate.Text = "Latest Date: " + analysisResult.LatestDate;
            lblTotalCost.Text = "Total Cost: " + analysisResult.TotalCost.ToString();
            lblHighestTotalCost.Text = "Highest Total Cost Per Product: " + analysisResult.HighestTotalCostPerProduct;
            lblAverageQuantity.Text = "Average Quantity: " + analysisResult.AverageQuantity.ToString();
        }
    }

    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(string baseAddress)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }

        public async Task<string> AnalyzeCSV(string csvData)
        {
            var content = new StringContent(csvData);
            var response = await _httpClient.PostAsync("api/analyzer/analyze-csv", content);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }

    public class AnalysisResult
    {
        public string EarliestDate { get; set; }
        public string LatestDate { get; set; }
        public decimal TotalCost { get; set; }
        public string HighestTotalCostPerProduct { get; set; }
        public double AverageQuantity { get; set; }
    }
}