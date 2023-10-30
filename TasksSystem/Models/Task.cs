using TasksSystem.Enums;

namespace TasksSystem.Models {
    public class Task {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Enums.TaskStatus Status { get; set; }
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
       
    }
}
