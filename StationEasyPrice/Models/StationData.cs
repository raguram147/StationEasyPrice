namespace StationEasyPrice.Models
{
    public class StationData
    {
        public string? STATION_ID { get; set; }
        public string? SITE_NAME { get; set; }
        public string? ZDALY_GAS_BRAND { get; set; }
        public string? ADDRESS { get; set; }
        public string? CITY { get; set; }
        public string? STATE { get; set; }
        public string? ZIP { get; set; }
        public string? COUNTY_NAME { get; set; }
        public string? PRICING_ZONE { get; set; }

        public decimal CLUSTER_MEDIAN_PRICE { get; set; }

        public decimal CLIENT_MARKET_PRICE { get; set; }

        public double LATITUDE { get; set; }
        public double LONGITUDE { get; set; }
    }
}
