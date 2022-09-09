using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Model;

namespace Tracker.Data.ViewModel
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime GoalDate { get; set; }
        public int TagId { get; set; }
    }
}
