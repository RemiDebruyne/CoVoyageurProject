using CoVoyageurCore.Models;
using System.Net.Http;

namespace CoVoyageurView.Services
{
    public class UserApiService : GenericApiQueryService<User>
    {
        public UserApiService(HttpClient httpClient) : base(httpClient)
        {
            Controller = "Users";
        }
    }
}
