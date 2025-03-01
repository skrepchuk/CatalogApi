using APICatalogo.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Domain
{
    [Table("produtos")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        [FirstLetterUppercase]
        public string? Nome { get; set; }
        [Required]
        [MaxLength(300)]
        public string? Descricao { get; set; }
        [Required]
        [Column(TypeName="decimal(10,2)")]
        [Range(1,10000, ErrorMessage = "O preço deve estar enter {1} e {2}")]
        public decimal Preco { get; set; }
        public float Estoque { get; set; }
        [Required]
        [MaxLength(300)]
        [StringLength(300, MinimumLength = 20, ErrorMessage = "O URL deve conter caracteres com tamanho entre {2} e {1}")]
        public string? ImageUrl { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CategoriaId { get; set; }
        [JsonIgnore]
        public Categoria? Categoria { get; set; }
    }
}
