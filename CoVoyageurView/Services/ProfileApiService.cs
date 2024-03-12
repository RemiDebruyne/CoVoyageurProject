using CoVoyageurCore.Models;

namespace CoVoyageurView.Services
{
    public class ProfileApiService : GenericApiQueryService<Profile>
    {

        public ProfileApiService(HttpClient httpClient) : base(httpClient)
        {
            Controller = "profiles";
        }

    }
}

