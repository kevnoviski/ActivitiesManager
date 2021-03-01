using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ActivitiesManager.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public DateTime DT_Creation { get; set; }

        [Required]
        public DateTime DT_DeadLine { get; set; }


        public DateTime? DT_Done { get; set; }

        [Required]
        public int Priority { get; set; }

    }
}
