using APICatalogo.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Domain
{
    [Table("produtos")]
    public class Product
    {
        [Key]
        [Column("ProductId")]
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        [FirstLetterUppercase]
        [Column("Name")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(300)]
        [Column("Description")]
        public string? Description { get; set; }
        [Required]
        [Column("Price", TypeName="decimal(10,2)")]
        [Range(1,10000, ErrorMessage = "O preço deve estar enter {1} e {2}")]
        public decimal Price { get; set; }
        public float Stock { get; set; }
        [Required]
        [MaxLength(300)]
        [StringLength(300, MinimumLength = 20, ErrorMessage = "O URL deve conter caracteres com tamanho entre {2} e {1}")]
        [Column("ImageUrl")]
        public string? ImageUrl { get; set; }
        [Column("IssueDate")]
        public DateTime IssueDate { get; set; }
        [Column("CategoryId")]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
    }
}
