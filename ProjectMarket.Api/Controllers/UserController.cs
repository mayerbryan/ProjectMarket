using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectMarket.Api.Data;
using ProjectMarket.Application.Models;
using SecureIdentity.Password;

namespace ProjectMarket.Api.Controllers
{
    //[Authorize]
    [ApiController]
    public class UserController : ControllerBase 
    {

        //[HttpPost("/v1/new/user")]
        //public IActionResult Post(
        //    [FromBody] UserModel User,
        //    [FromServices] ProjectMarketDbContext context)
        //{
        //    if (User.IsValid)
        //    {
        //        context.User.Add(User);
        //        context.SaveChanges();
        //        return Created("/{User.Id}", User);
        //    }
        //    return BadRequest(User.Notifications);
        //}

        //[HttpGet("/v1/users")]
        //public IActionResult Get([FromServices] ProjectMarketDbContext context)
        //    => Ok(context.User.ToList());

        
        [HttpGet("/v1/user/{id:int}")]
        public IActionResult GetUserData(
            [FromRoute] int id,
            [FromServices] ProjectMarketDbContext context)
        {
            var model = context.User.FirstOrDefault(x => x.SystemId == id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        
        [HttpPut("/v1/user/{id:int}")]
        public IActionResult UpdateUserData(
            [FromRoute] int id,
            [FromBody] UserModel User,
            [FromServices] ProjectMarketDbContext context)
        {

            var model = context.User.FirstOrDefault(x => x.SystemId == id);
            if (model == null)
                return NotFound();

            model.UserName = User.UserName;
            model.UserAddress = User.UserAddress;
            model.UserPhone = User.UserPhone;
            model.UserId = User.UserId;
            model.UserEmail = User.UserEmail;
            model.UserPassword = PasswordHasher.Hash(User.UserPassword);
            if (User.IsValid)
            {
                context.User.Update(model);
                context.SaveChanges();
                return Ok(model);
            }

            return BadRequest(User.Notifications);           

            
        }

        
        [HttpDelete("/v1/user/{id:int}")]
        public IActionResult DeleteUser(
            [FromRoute] int id,
            [FromServices] ProjectMarketDbContext context)
        {

            var model = context.User.FirstOrDefault(x => x.SystemId == id);
            if (model == null)
                return NotFound();

            context.User.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }
    }
}
