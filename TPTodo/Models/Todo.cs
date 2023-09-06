using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPTodo.Models
{

    [Table("tasks")]
    public class Todo
    {
        [Column("id")]
        public int Id { get; set; }
        [Display(Name ="Title")]
        [Column("title")]
        [Required(ErrorMessage = "A title is required")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 30 characters")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        [Column("description")]
        [Required(ErrorMessage = "A description is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Description must be between 5 and 50 characters")]
        public string Description { get; set; }
        [Column("done")]
        public bool Done { get; set; } = false;
    }
}
