using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksSystem.Models;
using TasksSystem.Repos.Interfaces;

namespace TasksSystem.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly IUserRepos _userRepos;

        public UserController(IUserRepos userRepos) {
            _userRepos=userRepos;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers(){
            List<User> users = await _userRepos.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id) {
            User user = await _userRepos.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Add([FromBody] User userModel) {
            User user = await _userRepos.Add(userModel);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update([FromBody] User userModel, int id) {
            userModel.Id = id;
            User user = await _userRepos.Update(userModel, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id) {
            bool deleted = await _userRepos.Delete(id);
            return Ok(deleted);
        }

    }
}
