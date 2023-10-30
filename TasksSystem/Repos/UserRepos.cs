using Microsoft.EntityFrameworkCore;
using TasksSystem.Data;
using TasksSystem.Models;
using TasksSystem.Repos.Interfaces;

namespace TasksSystem.Repos {
    public class UserRepos : IUserRepos {
        private readonly TasksSystemDbContext _dbContext;
        public UserRepos(TasksSystemDbContext tasksSystemDbContext) {
            _dbContext = tasksSystemDbContext;
        }
        public async Task<List<User>> GetAllUsers() {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetById(int id) {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> Add(User user) {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user, int id) {
            User userById = await GetById(id);
            if(userById == null) {
                throw new Exception($"User with Id {id} not found in database!");
            }
            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();
            return userById;
        }

        public async Task<bool> Delete(int id) {
            User userById = await GetById(id);
            if (userById == null) {
                throw new Exception($"User with Id {id} not found in database!");
            }
            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
