using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectMarket.Api.Data;
using ProjectMarket.Api.Services;
using ProjectMarket.Application.Models;
using SecureIdentity.Password;

namespace ProjectMarket.Api.Controllers
{
    
    public class AccountController : ControllerBase
    {
        [HttpPost("v1/register")]
        public IActionResult Register(
            [FromBody]UserModel User,
            [FromServices] ProjectMarketDbContext context)
        {
                       
            
            if (User.IsValid)
            {
                context.User.Add(User);

                context.SaveChanges();

                var model = context.User.FirstOrDefault(x => x.SystemId == User.SystemId);
                model.UserPassword = PasswordHasher.Hash(model.UserPassword);
                
                context.User.Update(model);
                 
                context.SaveChanges();
                return Ok(User);
            }

            return BadRequest(User.Notifications);


        }


        
        [HttpPost("v1/login")]
        public IActionResult Login(
            [FromBody] LoginModel Login,
            [FromServices] ProjectMarketDbContext context,
            [FromServices] TokenService tokenService)
        {
            var userLogin = context.User.FirstOrDefault(x => x.UserEmail == Login.UserEmail);
            if (userLogin == null)
                return NotFound();

            if(!PasswordHasher.Verify(userLogin.UserPassword, Login.UserPassword))
                return BadRequest();

            var token = tokenService.GenerateToken(null);
            return Ok(token);
        }
    }
}
