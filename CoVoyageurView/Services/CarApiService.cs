using CoVoyageurCore.Models;

namespace CoVoyageurView.Services
{
    public class CarApiService : GenericApiQueryService<Car>
    {
        public CarApiService(HttpClient httpClient) : base(httpClient)
        {
            Controller = "Cars";
        }
    }
}
