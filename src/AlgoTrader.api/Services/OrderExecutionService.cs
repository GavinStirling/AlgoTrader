using AlgoTrader.api.Models;
using Newtonsoft.Json;
using System.Text;

namespace AlgoTrader.api.Services
{
    public class OrderExecutionService : IOrderExecutionService
    {
        private readonly HttpClient _httpClient;

        public OrderExecutionService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<bool> PlaceOrderAsync(TradeOrder tradeOrder)
        {
            string url = "https://api.example.com/placeOrderHere";
            var content = JsonConvert.SerializeObject(tradeOrder);
            var response = await _httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }
    }
}
