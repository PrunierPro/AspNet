using System.ComponentModel.DataAnnotations.Schema;

namespace TPCaisse.Models
{
    [Table("categories")]
    public class Category
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
