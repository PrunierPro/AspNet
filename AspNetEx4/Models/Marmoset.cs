using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetEx4.Models
{
    [Table("marmosets")]
    public class Marmoset
    {
        [Display(Name = "ID")]
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Column("name")]
        public string? Name { get; set; }
        [Display(Name = "Age")]
        [Column("age")]
        [Required]
        public int Age { get; set; }
    }
}
