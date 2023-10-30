using TasksSystem.Models;

namespace TasksSystem.Repos.Interfaces {
    public interface ITaskRepos {
        Task<List<Models.Task>> GetAllTasks();
        Task<Models.Task> GetById(int id);
        Task<Models.Task> Add(Models.Task task);
        Task<Models.Task> Update(Models.Task task, int id);
        Task<bool> Delete(int id);
    }
}
