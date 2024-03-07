using CoVoyageurCore.Models;

namespace CoVoyageurView.Services
{
    public class UserApiService : GenericApiQueryService<User>
    {
        public UserApiService(HttpClient httpClient) : base(httpClient)
        {
            Controller = "User";
        }
    }
}
