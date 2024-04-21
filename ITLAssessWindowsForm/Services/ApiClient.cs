using System;
using System.Net.Http;
using System.Threading.Tasks;

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

