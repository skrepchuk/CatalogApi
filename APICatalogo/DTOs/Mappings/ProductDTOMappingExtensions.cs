using APICatalogo.Domain;

namespace APICatalogo.DTOs.Mappings
{
    public static class ProductDTOMappingExtensions
    {
        public static ProductDTO? ToProductDTO(this Product productDomain)
        {
            if (productDomain == null) return null;
            return new ProductDTO
            {
                Id = productDomain.Id,
                Name = productDomain.Name,
                Description = productDomain.Description,
                Price = productDomain.Price,
                Stock = productDomain.Stock,
                ImageUrl = productDomain.ImageUrl,
                IssueDate = productDomain.IssueDate,
                CategoryId = productDomain.CategoryId,
            };
        }

        public static Product? ToProductDomain(this ProductDTO productDTO)
        {
            if (productDTO  == null) return null;
            return new Product
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                Stock = productDTO.Stock,
                ImageUrl = productDTO.ImageUrl,
                IssueDate = productDTO.IssueDate,
                CategoryId = productDTO.CategoryId,
            };
        }

        public static IEnumerable<ProductDTO> ToProductDTOList(this IEnumerable<Product> productDomainList)
        {
            if(productDomainList is null || !productDomainList.Any()) return new List<ProductDTO>();
            return productDomainList.Select(c => 
                new ProductDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Price = c.Price,
                    Stock = c.Stock,
                    ImageUrl = c.ImageUrl,
                    IssueDate = c.IssueDate,
                    CategoryId = c.CategoryId,
                }
            ).ToList();
        }
    }
}
