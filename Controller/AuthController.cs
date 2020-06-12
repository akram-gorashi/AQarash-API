using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Al_Delal.Api.Contract;
using Al_Delal.Api.Models;
using Al_Delal.Api.Resource.User;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Al_Delal.Api.Controller
{

   [ApiController]
   public class AuthController : ControllerBase
   {
      private readonly IConfiguration _config;
      private readonly IMapper _mapper;
      private readonly UserManager<User> _userManager;
      private readonly SignInManager<User> _signInManager;

      public AuthController(IConfiguration config,
          IMapper mapper,
          UserManager<User> userManager,
          SignInManager<User> signInManager)
      {
         _userManager = userManager;
         _signInManager = signInManager;
         _mapper = mapper;
         _config = config;
      }

      [HttpPost(ApiRoutes.Account.Register)]
      public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
      {
         userForRegisterDto.Created = DateTime.Now;
         var userToCreate = _mapper.Map<User>(userForRegisterDto);

         var result = await _userManager.CreateAsync(userToCreate, userForRegisterDto.Password);

         var userToReturn = userToCreate;

         if (result.Succeeded)
         {
            return Ok(userToReturn);
            /* CreatedAtRoute("GetUser",
                new { controller = "Users", id = userToCreate.Id }, userToReturn); */
         }

         return BadRequest(result.Errors);
      }

      [HttpPost(ApiRoutes.Account.Login)]
      public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
      {
         var user = await _userManager.FindByNameAsync(userForLoginDto.Username);
         var result = await _signInManager
             .CheckPasswordSignInAsync(user, userForLoginDto.Password, false);

         if (result.Succeeded)
         {
            var appUser = await _userManager.Users
                .FirstOrDefaultAsync(u => u.NormalizedUserName == userForLoginDto.Username.ToUpper());

            var userToReturn = _mapper.Map<UserForListDto>(appUser);

            return Ok(new
            {
               token = GenerateJwtToken(appUser).Result,
               user = userToReturn
            });
         }

         return Unauthorized();
      }

      private async Task<string> GenerateJwtToken(User user)
      {
         var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

         var roles = await _userManager.GetRolesAsync(user);

         foreach (var role in roles)
         {
            claims.Add(new Claim(ClaimTypes.Role, role));
         }

         var key = new SymmetricSecurityKey(Encoding.UTF8
             .GetBytes(_config.GetSection("AppSettings:Token").Value));

         var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

         var tokenDescriptor = new SecurityTokenDescriptor
         {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = creds
         };

         var tokenHandler = new JwtSecurityTokenHandler();

         var token = tokenHandler.CreateToken(tokenDescriptor);

         return tokenHandler.WriteToken(token);
      }
   }
}