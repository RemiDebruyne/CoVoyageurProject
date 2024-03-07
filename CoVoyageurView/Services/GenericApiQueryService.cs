
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.Net.Http.Json;

namespace CoVoyageurView.Services
{
    public class GenericApiQueryService<T> : IApiQueryService<T> where T : class
    {
        private readonly HttpClient _httpClient;

        protected const string _apiRoute = "http://localhost:5199/api/";
        protected string Controller { get; set; }

        public GenericApiQueryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public virtual async Task<bool> Update(T entity, int id)
        {
            var result = await _httpClient.PostAsJsonAsync(_apiRoute + Controller + $"{id}", entity);

            return result.IsSuccessStatusCode;
        }
        public virtual async Task<bool> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync(_apiRoute + Controller + $"{id}");

            return result.IsSuccessStatusCode;
        }

        public virtual async Task<T> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<T>(_apiRoute + Controller + $"{id}");

            return result;

        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<T>>(_apiRoute + Controller);

            return result;
        }

        public virtual async Task<bool> Post(T entity)
        {
            var result = await _httpClient.PostAsJsonAsync(_apiRoute + Controller, entity);

            return result.IsSuccessStatusCode;
        }
    }
}
