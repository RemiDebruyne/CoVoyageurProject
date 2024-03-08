using CoVoyageurCore.Models;

namespace CoVoyageurView.Services
{
    public class CarApiService : GenericApiQueryService<Car>
    {
        public string Controller => "Car";

        public CarApiService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
