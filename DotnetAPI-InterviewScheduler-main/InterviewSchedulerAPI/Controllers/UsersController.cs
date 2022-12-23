using InterviewSchedulerAPI.DataLayer;
using InterviewSchedulerAPI.InterviewSchedulerModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace InterviewSchedulerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

  
    public class UsersController : ControllerBase
    {
      

        private readonly UsersDataLayer db = new UsersDataLayer();

        [HttpGet("GetAllUsers")]

        public List<User> GetAllUsers()
        {
            return db.GetAllUsers();
        }

        [EnableCors("*", "*", "*")]
        [HttpPost("AddUser")]

        public int AddUser(User a)
        {

            return db.AddUser(a);
        }

        [EnableCors("*", "*", "*")]

        [HttpPost("LoginUser")]

        public User LoginUser(User a)
        {
            
            return db.LoginUser(a);
        }

        [HttpPut("UpdateUser")]

        public int UpdateUser(int id, User c)
        {
            return db.UpdateUser(id, c);
        }


        [HttpDelete("DeleteUser")]

        public int DeleteUser(int id)
        {
            return db.DeleteUser(id);
        }

        [HttpGet("GetUserById")]

        public User GetUserById(int id)
        {
            return db.GetUserById(id);
        }

        //[HttpGet("Username/{Username}")]
        //public IActionResult GetUsername(string Username)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = db.GetUserByUserName(Username);


        //    if (user == null)
        //    {
        //        return NotFound();
        //    }


        //    return Ok(user);
        //}




    }
}
