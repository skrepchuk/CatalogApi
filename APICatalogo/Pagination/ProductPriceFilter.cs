using APICatalogo.Domain;

namespace APICatalogo.Pagination
{
    public class ProductPriceFilter : ProductsPagination
    {
        public decimal? Price { get; set; }
        public string? Criteria { get; set; }
    }
}
