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
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        [FirstLetterUppercase]
        [Column("Nome")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(300)]
        [Column("Descricao")]
        public string? Description { get; set; }
        [Required]
        [Column("Preco", TypeName="decimal(10,2)")]
        [Range(1,10000, ErrorMessage = "O preço deve estar enter {1} e {2}")]
        public decimal Price { get; set; }
        [Column("Estoque")]
        public float Stock { get; set; }
        [Required]
        [MaxLength(300)]
        [StringLength(300, MinimumLength = 20, ErrorMessage = "O URL deve conter caracteres com tamanho entre {2} e {1}")]
        [Column("ImageUrl")]
        public string? ImageUrl { get; set; }
        [Column("DataCadastro")]
        public DateTime IssueDate { get; set; }
        [Column("CategoriaId")]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
    }
}
