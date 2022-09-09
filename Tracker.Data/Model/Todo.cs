using System.ComponentModel.DataAnnotations;

namespace Tracker.Data.Model
{
    public class Todo
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime GoalDate { get; set; }
        public int? TagId { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Colaborator> Colaborators { get; set; }
    }
}
