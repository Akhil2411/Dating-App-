using DatingApp.Data;
using DatingApp.DTOs;
using DatingApp.Entities;
using DatingApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
   [Authorize]
    public class UsersController : BaseApiController
    {
      
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        //The output will be a list of AppUser
        //So List<AppUser> can be also used as a return type
        //But List offers too many options like sort,search etc..which we dont want at the moment..So we use I enumerable instead
        //bcz we are simply returning a list
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {

            var users = await _userRepository.GetMembersAsync();

            return Ok(users);
        }


        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUserById(string username)
        {

            return await _userRepository.GetMemberAsync(username);
        }
    }
}
