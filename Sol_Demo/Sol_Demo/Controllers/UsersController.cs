using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sol_Demo.Models;
using Sol_Demo.Repository;

namespace Sol_Demo.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository = null;
        
        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost("adduser")]
        public async Task<IActionResult> AddUserAsync([FromBody] UserModel userModel)
        {
            if (userModel == null) return base.BadRequest(new { Error="User Model should not be null" });
            else
            {
                return base.Ok((Object)await userRepository?.AddUserAsync(userModel));
            }
        }

        [HttpPost("getuser")]
        public async Task<IActionResult> GetUserAsync()
        {
                return base.Ok((Object)await userRepository?.GetUserDataAsync());
          
        }

        [HttpPost("updateuser")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserModel userModel)
        {
            if (userModel == null) return base.BadRequest(new { Error = "User Model should not be null" });
            else
            {
                return base.Ok((Object)await userRepository?.UpdateUserAsync(userModel));
            }
        }

        [HttpPost("deleteuser")]
        public async Task<IActionResult> DeleteUserAsync([FromBody] UserModel userModel)
        {
            if (userModel == null) return base.BadRequest(new { Error = "User Model should not be null" });
            else
            {
                return base.Ok((Object)await userRepository?.DeleteUserAsync(userModel));
            }
        }

    }
}