using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.Models;
using StocksApp.ServiceContracts;
using StocksApp.Services;

namespace StocksApp.Controllers
{
    public class StocksController : Controller
    {
        private readonly IFinhubService _finhubService;
        private readonly StockNameOptions _stocksNameOptions;

        public StocksController(IFinhubService finhubService, IOptions<StockNameOptions> stockNameOptions)
        {
            _finhubService = finhubService;
            _stocksNameOptions = stockNameOptions.Value;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            if (_stocksNameOptions.DefaultStockName == null)
            {
                _stocksNameOptions.DefaultStockName = "AAPL";
            }
            Dictionary<string, object>? DictionaryResponse = 
                await _finhubService.GetStockPriceQuote(_stocksNameOptions.DefaultStockName);

            StockDetails stockDetails = new StockDetails()
            {
                StockSymbol = _stocksNameOptions.DefaultStockName,
                CurrentPrice = Convert.ToDouble(DictionaryResponse["c"].ToString()),
                Change = Convert.ToDouble(DictionaryResponse["d"].ToString()),
                PercentChange = Convert.ToDecimal(DictionaryResponse["dp"].ToString()),
                HighPriceOfTheDay = Convert.ToDouble(DictionaryResponse["h"].ToString()),
                LowPriceOfTheDay = Convert.ToDouble(DictionaryResponse["l"].ToString()),
                OpenPriceOfTheDay = Convert.ToDouble(DictionaryResponse["o"].ToString()),
                PreviousClosePrice = Convert.ToDouble(DictionaryResponse["pc"].ToString()),
                Total = Convert.ToInt64(DictionaryResponse["t"].ToString()),
            };

            return View(stockDetails);
        }
    }
}
