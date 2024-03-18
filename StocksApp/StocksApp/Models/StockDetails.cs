namespace StocksApp.Models
{
    public class StockDetails
    {
        public string? StockSymbol { get; set; }
        public Double? CurrentPrice { get; set; }
        public Double? Change { get; set; }
        public Decimal? PercentChange { get; set; }
        public Double? HighPriceOfTheDay { get; set; }
        public Double? LowPriceOfTheDay { get; set; }
        public Double? OpenPriceOfTheDay { get; set; }
        public Double? PreviousClosePrice { get; set; }
        public long? Total { get; set; }

    }

}
