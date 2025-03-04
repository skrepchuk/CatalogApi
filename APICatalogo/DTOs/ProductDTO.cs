namespace APICatalogo.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public float Stock { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime IssueDate { get; set; }

        public int CategoryId { get; set; }

    }
}
