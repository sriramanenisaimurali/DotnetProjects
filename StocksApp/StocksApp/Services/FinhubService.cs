using StocksApp.ServiceContracts;
using System.Collections;
using System.Text.Json;
namespace StocksApp.Services
{
    public class FinhubService : IFinhubService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public FinhubService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string StockName)
        {
            using(HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={StockName}&token={_configuration["FinhubApiToken"]}"),
                    Method = HttpMethod.Get
                };

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                Stream stream = httpResponseMessage.Content.ReadAsStream();
                StreamReader streamReader = new StreamReader(stream);
                string responseMessage = streamReader.ReadToEnd();

                Dictionary<string, object>? dictionaryResponse = 
                    JsonSerializer.Deserialize<Dictionary<string, object>>(responseMessage);

                if(dictionaryResponse == null)
                {
                    throw new InvalidOperationException("No response from Finhub service");
                }

                if (dictionaryResponse.ContainsKey("error"))
                {
                    throw new InvalidOperationException(Convert.ToString(dictionaryResponse["error"]));
                }

                return dictionaryResponse;
            }
        }
    }
}
