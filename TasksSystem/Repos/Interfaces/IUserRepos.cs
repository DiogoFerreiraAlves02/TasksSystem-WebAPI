using TasksSystem.Models;

namespace TasksSystem.Repos.Interfaces {
    public interface IUserRepos {
        Task<List<User>> GetAllUsers();
        Task<User> GetById(int id);
        Task<User> Add(User user);
        Task<User> Update(User user, int id);
        Task<bool> Delete(int id);
    }
}
