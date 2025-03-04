using APICatalogo.Domain;

namespace APICatalogo.DTOs.Mappings
{
    public static class CategoryDTOMappingExtensions
    {
        public static CategoryDTO? ToCategoryDTO(this Category categoryDomain)
        {
            if (categoryDomain == null) return null;
            return new CategoryDTO
            {
                Id = categoryDomain.Id,
                Name = categoryDomain.Name,
                ImageUrl = categoryDomain.ImageUrl
            };
        }

        public static Category? ToCategoryDomain(this CategoryDTO categoryDTO)
        {
            if (categoryDTO == null) return null;
            return new Category
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                ImageUrl = categoryDTO.ImageUrl
            };
        }

        public static IEnumerable<CategoryDTO> ToCategoryDTOList(this IEnumerable<Category> categoryDomainList)
        {
            if(categoryDomainList is null || !categoryDomainList.Any()) return new List<CategoryDTO>();
            return categoryDomainList.Select(c => 
                new CategoryDTO 
                { 
                    Id= c.Id,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl
                }
            ).ToList();
        }
    }
}
