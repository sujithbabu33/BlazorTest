namespace SalesDataViewer.Models
{
    public class SalesRecord
    {
        public string Segment { get; set; }
        public string Country { get; set; }
        public string Product { get; set; }
        public string DiscountBand { get; set; }
        public string UnitsSold { get; set; }
        public decimal ManufacturingPrice { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime Date { get; set; }

        public string ManufacturingPriceWithSymbol => $"£{ManufacturingPrice:N2}";
        public string SalePriceWithSymbol => $"£{SalePrice:N2}";
    }
}
