using System;
using System.Windows.Forms;


namespace ITLAssessmentWindowsForm2
{
    public partial class CSVAnalyzerForm : Form
    {
        public CSVAnalyzerForm()
        {
            InitializeComponent();
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog.Title = "Select a CSV File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text;

            if (!string.IsNullOrEmpty(filePath))
            {
                // Call method to analyze CSV data
                var result = CSVAnalyzer.Analyze(filePath);

                // Display result
                MessageBox.Show($"Earliest Date: {result.EarliestDate}\n" +
                                $"Latest Date: {result.LatestDate}\n" +
                                $"Total Cost: {result.TotalCost}\n" +
                                $"Highest Total Cost Per Product: {result.HighestTotalCostPerProduct}\n" +
                                $"Average Quantity: {result.AverageQuantity}");
            }
            else
            {
                MessageBox.Show("Please select a CSV file.");
            }
        }
    }
}
