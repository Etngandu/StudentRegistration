using AutoMapper;
using ENB.Students.Registration.Entities;
using ENB.Students.Registration.WebApi.Factory;
using ENB.Students.Registration.WebApi.Models;
using ENB.Students.Registration.WebApi.Models.AppUser;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ENB.Students.Registration.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IMapper mapper, 
                              IAuthService authService,
                              IConfiguration configuration,
                              ILogger<AuthController> logger)
        {
            _mapper = mapper;
            _authService = authService;
            _configuration = configuration;
            _logger = logger;
        }
        
        

        [HttpPost]       
        [Route("Register")]
        public async Task<IActionResult> Register(UserRegistrationModel userModel)
        {
            var registration_result= await _authService.Register(userModel);

            if (!registration_result.IsSuccessfulRegistration)
                return BadRequest(registration_result);

           
           return Ok(registration_result);
        }

        

        [HttpPost]       
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginModel userModel)
        {            

            var authenticated_result= await _authService.Login(userModel);

            if (!authenticated_result.IsAuthSuccessful)
                return BadRequest(authenticated_result);           
              

                return Ok(authenticated_result);            
            
        }



      


    }
}
