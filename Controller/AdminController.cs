using System.Linq;
using System.Threading.Tasks;
using Al_Delal.Api.Contract;
using Al_Delal.Api.Data;
using Al_Delal.Api.Models;
using Al_Delal.Api.Resource.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Al_Delal.Api.Controller
{
   [ApiController]
   [Route(ApiRoutes.ApiAdmin.Admin)]
   public class AdminController : ControllerBase
   {
      private readonly DataContext _context;
      private readonly UserManager<User> _userManager;

      public AdminController(
          DataContext context,
          UserManager<User> userManager)
      {
         _userManager = userManager;
         _context = context;


      }

      [Authorize(Policy = "Admin")]
      [HttpGet(ApiRoutes.ApiAdmin.UsersWithRoles)]
      public async Task<IActionResult> GetUsersWithRoles()
      {
         var userList = await (from user in _context.Users
                               orderby user.UserName
                               select new
                               {
                                  Id = user.Id,
                                  UserName = user.UserName,
                                  Roles = (from userRole in user.UserRoles
                                           join role in _context.Roles
                                           on userRole.RoleId
                                           equals role.Id
                                           select role.Name).ToList()
                               }).ToListAsync();
         return Ok(userList);
      }

      [Authorize(Policy = "Admin")]
      [HttpPost("editRoles/{userName}")]
      public async Task<IActionResult> EditRoles(string userName, RoleEditDto roleEditDto)
      {
         var user = await _userManager.FindByNameAsync(userName);

         var userRoles = await _userManager.GetRolesAsync(user);

         var selectedRoles = roleEditDto.RoleNames;

         selectedRoles = selectedRoles ?? new string[] { };
         var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

         if (!result.Succeeded)
            return BadRequest("Failed to add to roles");

         result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));

         if (!result.Succeeded)
            return BadRequest("Failed to remove the roles");

         return Ok(await _userManager.GetRolesAsync(user));
      }

   }
}