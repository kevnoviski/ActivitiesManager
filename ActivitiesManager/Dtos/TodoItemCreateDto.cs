using System;
using System.ComponentModel.DataAnnotations;

namespace ActivitiesManager.Dtos
{
    public class TodoItemCreateDto
    {
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