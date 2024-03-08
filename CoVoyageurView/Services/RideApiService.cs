using CoVoyageurCore.Models;

namespace CoVoyageurView.Services
{
    public class RideApiService : GenericApiQueryService<Ride>
    {
        public string Controller = "ride";

        public RideApiService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
