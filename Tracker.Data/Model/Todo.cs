using System.ComponentModel.DataAnnotations;

namespace Tracker.Data.Model
{
    public class Todo
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
    }
}
