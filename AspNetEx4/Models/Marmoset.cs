using System.ComponentModel.DataAnnotations;

namespace AspNetEx4.Models
{
    public class Marmoset
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string? Name { get; set; }
        [Display(Name = "Age")]
        public int Age { get; set; }
    }
}
