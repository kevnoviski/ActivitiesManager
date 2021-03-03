using System;

namespace ActivitiesManager.Dtos
{
    public class TodoItemReadDto//contains all the original fields, its just here for study purpose
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DT_Creation { get; set; }
        public DateTime DT_DeadLine { get; set; }
        public DateTime? DT_Done { get; set; }
        public int Priority { get; set; }
    }
}