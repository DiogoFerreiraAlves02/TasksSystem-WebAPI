using System.ComponentModel;

namespace TasksSystem.Enums {
    public enum TaskStatus {
        [Description("To Do")]
        ToDo = 1,
        [Description("Doing")]
        Doing = 2,
        [Description("Done")]
        Done = 3
    }
}
