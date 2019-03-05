using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiWebDAL.Users;
using ApiWebDTO;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository  userRepo)
        {

            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            //_userRepo = new UserRepository("");
            var Users =  _userRepo.GetAllAsync() ;
            return Ok(Users);
        }

        [HttpGet("{id}")]
        public IActionResult GetGetUser(int id)
        {
            //_userRepo = new UserRepository("");
            var Users = _userRepo.GetAsync(id);
            return Ok(Users);
        }

        [HttpPost]
        public IActionResult Create(User usuario)
        {
            //_employeeRepo.InsertAsync(employee);
            //return CreatedAtRoute("Employee/Create", true);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, User usuario)
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