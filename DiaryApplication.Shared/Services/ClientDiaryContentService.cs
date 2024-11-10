using DiaryApplication.Shared.Entity;
using DiaryApplication.Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApplication.Shared.Services
{
    public class ClientDiaryContentService : IDiaryContentService
    {
        private readonly HttpClient _httpClient;

        public ClientDiaryContentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DiaryContent> AddContent(DiaryContent diaryContent)
        {
            var result = await _httpClient.PostAsJsonAsync<DiaryContent>("/api/diarycontent", diaryContent);
            return await result.Content.ReadFromJsonAsync<DiaryContent>();
        }

        public async Task<bool> DeleteDiaryContent(int id)
        {
            // This is not implemented as everything is done through server end.
            var result = await _httpClient.DeleteAsync($"/api/diarycontent/{id}");
            return await result.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<DiaryContent> EditDiaryContent(int id, DiaryContent diaryContent)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync($"/api/diarycontent/{id}", diaryContent);

                result.EnsureSuccessStatusCode();

                var content = await result.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(content))
                {
                    throw new InvalidOperationException("Server returned empty response");
                }

                return await result.Content.ReadFromJsonAsync<DiaryContent>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error editing diary content. Message: {ex.Message}");
            }
        }

        public Task<List<DiaryContent>> GetAllDiaryContent()
        {
            // Implemented in ServerDiaryContentService
            throw new NotImplementedException();
        }

        public async Task<DiaryContent> GetDiaryContentById(int id)
        {
            return await _httpClient.GetFromJsonAsync<DiaryContent>($"/api/diarycontent/{id}");
        }
    }
}
