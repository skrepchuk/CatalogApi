using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Domain
{
    [Table("categorias")]
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        [Column("Nome")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(300)]
        [Column("ImageUrl")]
        public string? ImageUrl { get; set; }
        [JsonIgnore]
        public ICollection<Product>? Products { get; set; }
    }
}
