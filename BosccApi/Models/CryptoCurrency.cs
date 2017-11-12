namespace BosccApi.Models
{
    public class CryptoCurrency
    {
        public string id { get; set; }
        public string base_currency { get; set; }
        public string quote_currency { get; set; }
        public string base_min_size { get; set; }
        public string base_max_size { get; set; }
        public string quote_increment { get; set; }
        public string display_name { get; set; }
        public bool margin_enabled { get; set; }
    }
}
