using CoVoyageurCore.DTOs;
using CoVoyageurCore.Models;
using System.Net.Http.Json;

namespace CoVoyageurView.Services
{
    public class AuthenticationApiService : GenericApiQueryService<User>
    {
        public AuthenticationApiService(HttpClient httpClient) : base(httpClient)
        {
            Controller = "Authentication";
        }

        public async Task<bool> Register(User user)
        {
            var result = await _httpClient.PostAsJsonAsync(_apiRoute + Controller + "/register", user);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> Login(LoginRequestDTO loginRequest)
        {
            var result = await _httpClient.PostAsJsonAsync(_apiRoute + Controller + "/login", loginRequest); 
            return result.IsSuccessStatusCode;
        }
    }
}
