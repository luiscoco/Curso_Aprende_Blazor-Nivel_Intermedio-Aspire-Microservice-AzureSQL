using BlazorWebAssemblyUI.Models;
using System.Net.Http.Json;

namespace BlazorWebAssemblyUI.Services
{
    public class ExampleModelService
    {
        private readonly HttpClient _httpClient;

        public ExampleModelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get all ExampleModels
        public async Task<List<ExampleModel>> GetAllExampleModels()
        {
            return await _httpClient.GetFromJsonAsync<List<ExampleModel>>("api/ExampleModels");
        }

        // Get ExampleModel by ID
        public async Task<ExampleModel> GetExampleModelById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ExampleModel>($"api/ExampleModels/{id}");
        }

        // Add new ExampleModel
        public async Task<HttpResponseMessage> AddExampleModel(ExampleModel model)
        {
            return await _httpClient.PostAsJsonAsync("api/ExampleModels", model);
        }

        // Update ExampleModel
        // Update ExampleModel
        public async Task<HttpResponseMessage> UpdateExampleModel(int id, ExampleModel model)
        {
            return await _httpClient.PutAsJsonAsync($"api/ExampleModels/{id}", model);
        }

        // Delete ExampleModel
        public async Task<HttpResponseMessage> DeleteExampleModel(int id)
        {
            return await _httpClient.DeleteAsync($"api/ExampleModels/{id}");
        }
    }
}
