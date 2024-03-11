using Blazored.LocalStorage;
using CoVoyageurCore.Models;
using System.Net.Http.Json;

namespace CoVoyageurView.Services
{
    public class UserState
    {
        public User User { get; set; }
        public Profile Profile { get; set; }

        //public UserState(ILocalStorageService localStorage, HttpClient httpClient)
        //{
        //    _localStorage = localStorage;
        //    _httpClient = httpClient;
        //}

        public async Task GetUserState(ILocalStorageService localStorage, HttpClient httpClient)
        {
            var token = await localStorage.GetItemAsync<string>("token");

            var loginResponse = await httpClient.PostAsJsonAsync<string>("http://localhost:5199/api/Authentication", token);
            //User = await user.Content.ReadFromJsonAsync<User>();
            //Profile = User.Profile;

            var user = await loginResponse.Content.ReadFromJsonAsync<User>();

            if (user == null)
            {
                User = new();
                Profile = new();
            }
            else
            {
                User = user;
                Profile = user.Profile;
            }

        }
    }
}
