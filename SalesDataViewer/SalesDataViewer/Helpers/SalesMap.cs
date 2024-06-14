using CsvHelper.Configuration;
using SalesDataViewer.Models;

namespace SalesDataViewer.Helpers
{
    public class SalesMap : ClassMap<SalesRecord>
    {
        public SalesMap()
        {
            Map(m => m.Segment);
            Map(m => m.Country);
            Map(m => m.Product).Name(" Product ");
            Map(m => m.DiscountBand).Name(" Discount Band ");
            Map(m => m.UnitsSold).Name("Units Sold");
            Map(m => m.ManufacturingPrice).TypeConverter<CurrencyConverter>().Name("Manufacturing Price");
            Map(m => m.SalePrice).TypeConverter<CurrencyConverter>().Name("Sale Price");
            Map(m => m.Date);
        }
    }
}
