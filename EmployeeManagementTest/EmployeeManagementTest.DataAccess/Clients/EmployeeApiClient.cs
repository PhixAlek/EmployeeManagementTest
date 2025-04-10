using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using EmployeeManagementTest.DataAccess.Dtos;
using EmployeeManagementTest.DataAccess.Interfaces;

namespace EmployeeManagementTest.DataAccess.Clients
{
    public class EmployeeApiClient : IEmployeeApiClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://dummy.restapiexample.com/api/v1";

        public EmployeeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
        {
            var requestUrl = $"{BaseUrl}/employees";
            var response = await _httpClient.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                // Optional: handle 429 (Too Many Requests) or log specific error
                return new List<EmployeeDto>();
            }

            var content = await response.Content.ReadAsStringAsync();

            using var json = JsonDocument.Parse(content);
            var dataNode = json.RootElement.GetProperty("data");

            return JsonSerializer.Deserialize<List<EmployeeDto>>(dataNode.GetRawText()) ?? new();
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(int id)
        {
            var requestUrl = $"{BaseUrl}/employee/{id}";
            var response = await _httpClient.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                // Optional: handle 429, 404, etc. or log specific error
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();

            using var json = JsonDocument.Parse(content);
            var dataNode = json.RootElement.GetProperty("data");

            return JsonSerializer.Deserialize<EmployeeDto>(dataNode.GetRawText());
        }
    }
}
