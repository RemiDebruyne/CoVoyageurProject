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

        public async Task<HttpResponseMessage> Register(User user)
        {
            var result = await _httpClient.PostAsJsonAsync(_apiRoute + Controller + "/register", user);
            

            return result;
        }

        public async Task<LoginResponseDTO?> Login(LoginRequestDTO loginRequest)
        {
            var result = await _httpClient.PostAsJsonAsync(_apiRoute + Controller + "/login", loginRequest);
            var loginResponse = await result.Content.ReadFromJsonAsync<LoginResponseDTO>();
            return loginResponse;
        }
    }
}
