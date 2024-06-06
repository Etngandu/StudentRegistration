using AutoMapper;
using ENB.Students.Registration.Entities;
using ENB.Students.Registration.WebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Protocols.WSIdentity;
using ENB.Students.Registration.WebApi.Models.AppUser;

namespace ENB.Students.Registration.WebApi.Factory
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipal;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOptions<IdentityOptions> _optionsAccessor;

        public AuthService(UserManager<ApplicationUser> userManager,
                          IMapper mapper,
                          IConfiguration configuration,
                          SignInManager<ApplicationUser> signInManager,
                          IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipal,
                          IHttpContextAccessor httpContextAccessor,
                          IOptions<IdentityOptions> optionsAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
            _signInManager = signInManager;
            _userClaimsPrincipal = userClaimsPrincipal;
            _httpContextAccessor = httpContextAccessor;
            _optionsAccessor = optionsAccessor;
        }


        public async Task<RegistrationResponse> Register(UserRegistrationModel userModel)
        {
            var user = _mapper.Map<ApplicationUser>(userModel);

            var result = await _userManager.CreateAsync(user, userModel.Password!);

            var errors= result.Errors.Select(x=>x.Description).ToList();

            if (!result.Succeeded) return new RegistrationResponse {IsSuccessfulRegistration=false, Errors=errors };

            await _userManager.AddToRoleAsync(user, "Visitor");

            return  new RegistrationResponse { IsSuccessfulRegistration = true };   

        }
        public async Task<AuthenticatedResponse> Login(UserLoginModel userModel)
        {         

            var result = await _signInManager.PasswordSignInAsync(userModel.Email!, userModel.Password!, userModel.RememberMe, false);
           

            if (!result.Succeeded)
             return new AuthenticatedResponse { ErrorMessage = "Username and password are invalid.", IsAuthSuccessful=false};

            var tonkenString = GenerateTokenString(userModel);

            return new AuthenticatedResponse { IsAuthSuccessful = true,Token=tonkenString };
        }

        public  string GenerateTokenString(UserLoginModel userModel)
        {

            // var claimfact = new CustomClaimsFactory(_userManager, _optionsAccessor);


            var identity = _httpContextAccessor.HttpContext!.User.Identities.FirstOrDefault()!.Claims.ToList();

            IEnumerable<ClaimsIdentity> clmId = new List<ClaimsIdentity>();

            //foreach (var claim in identity)
            //{


            //};


            IEnumerable<Claim> claimsX = new List<Claim>
                {
                   new Claim(ClaimTypes.Email,userModel.Email!),
                   new Claim(ClaimTypes.Role,"Visitor")

                };

           

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Key").Value!));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(

                claims:claimsX,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _configuration.GetSection("JWT:Issuer").Value,
                audience: _configuration.GetSection("JWT:Audience").Value,
                signingCredentials: signingCred);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return tokenString;

        }
    }
}
