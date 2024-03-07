using CoVoyageurCore.Models;

namespace CoVoyageurView.Services
{
    public class UserApiService : GenericApiQueryService<User>
    {
        public string Controller => "User";
        
        public UserApiService(HttpClient httpClient) : base(httpClient)
        { 
        }
    }
}
