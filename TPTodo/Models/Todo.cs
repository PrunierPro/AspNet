using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPTodo.Models
{
    public enum TodoStatus
    {
        IN_PROGRESS,
        DONE,
    }

    [Table("tasks")]
    public class Todo
    {
        [Column("id")]
        public int Id { get; set; }
        [Display(Name ="Title")]
        [Column("title")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        [Column("description")]
        public string Description { get; set; }
        [Column("status")]
        public TodoStatus Status { get; set; }
    }
}
