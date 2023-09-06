using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPCaisse.Models
{
    [Table("products")]
    public class Product
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [Required]
        public string Name { get; set; }
        [Column("description")]
        [Required]
        public string Description { get; set; }
        [Column("price")]
        [Required]
        public double Price { get; set; }
        [Column("quantity")]
        [Required]
        public int Quantity { get; set; }
        [Column("category")]
        [Required]
        public Category Category { get; set; }

    }
}
