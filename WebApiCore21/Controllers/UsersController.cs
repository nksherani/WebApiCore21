using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServiceLayers.DTOs;
using ServiceLayers.Helpers;
using ServiceLayers.Model;
using ServiceLayers.Services;

namespace WebApiCore21.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    //[Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public UsersController(IUserService userService,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]LoginDTO userParam)
        //public IActionResult Authenticate()
        {
            //LoginDTO userParam = new LoginDTO() { Username = "naveed", Password = "naveed" };
            //var user = _userService.Authenticate(userParam.Username, userParam.Password);

            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user.Token);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
        [AllowAnonymous]
        [HttpGet("CreateTestUser")]
        public IActionResult CreateTestUser()
        {
            User user = new User();
            user.FirstName = "naveed1";
            user.LastName = "naveed1";
            user.Username = "naveed1";
            var userEntity = _userService.Create(user,"naveed1");
            var userDto = _mapper.Map<UserDTO>(userEntity);
            return Ok(user);
        }
    }
}