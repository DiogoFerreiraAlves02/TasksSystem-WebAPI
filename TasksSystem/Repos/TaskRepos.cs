using Microsoft.EntityFrameworkCore;
using TasksSystem.Data;
using TasksSystem.Models;
using TasksSystem.Repos.Interfaces;

namespace TasksSystem.Repos {
    public class TaskRepos : ITaskRepos {
        private readonly TasksSystemDbContext _dbContext;
        public TaskRepos(TasksSystemDbContext tasksSystemDbContext) {
            _dbContext = tasksSystemDbContext;
        }
        public async Task<List<Models.Task>> GetAllTasks() {
            return await _dbContext.Tasks.Include(x => x.User).ToListAsync();
        }

        public async Task<Models.Task> GetById(int id) {
            return await _dbContext.Tasks.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Models.Task> Add(Models.Task task) {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<Models.Task> Update(Models.Task task, int id) {
            Models.Task taskById = await GetById(id);
            if(taskById == null) {
                throw new Exception($"Task with Id {id} not found in database!");
            }
            taskById.Name = task.Name;
            taskById.Description = task.Description;
            taskById.Status = task.Status;
            taskById.UserId = task.UserId;

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();
            return taskById;
        }

        public async Task<bool> Delete(int id) {
            Models.Task taskById = await GetById(id);
            if (taskById == null) {
                throw new Exception($"Task with Id {id} not found in database!");
            }
            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
