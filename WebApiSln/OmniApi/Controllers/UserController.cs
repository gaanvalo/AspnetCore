using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmniApiDAL.User;
using OmniApiDTO.DTOs;

namespace OmniApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public IActionResult GetAllUser()
        {
            //_userRepo = new UserRepository("");
            var Users = _userRepo.GetAllAsync();
            return Ok(Users);
        }
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            //_userRepo = new UserRepository("");
            var Users = _userRepo.GetAsync(id);
            return Ok(Users);
        }

        [HttpPost]
        public IActionResult Create(Usuarios usuario)
        {
            //_employeeRepo.InsertAsync(employee);
            //return CreatedAtRoute("Employee/Create", true);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Usuarios usuario)
        {
            //_employeeRepo.UpdateAsync(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //_employeeRepo.DeleteAsync(id);
            return NoContent();
        }
    }


}