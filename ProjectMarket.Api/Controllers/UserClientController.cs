using Microsoft.AspNetCore.Mvc;
using ProjectMarket.Api.Data;
using ProjectMarket.Application.Models;

namespace ProjectMarket.Api.Controllers
{
    [ApiController]
    public class UserClientController : ControllerBase 
    {
        [HttpPost("/v1/new/user")]
        public IActionResult Post(            
            [FromBody] UserClientModel User,            
            [FromServices] ProjectMarketDbContext context)
        {
            context.UserClient.Add(User);
            context.SaveChanges();
            return Created("/{User.Id}", User);
        }

        [HttpGet("/v1/users")]
        public IActionResult Get([FromServices] ProjectMarketDbContext context)
            => Ok(context.UserClient.ToList());

        [HttpPut("/v1/user/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id,
            [FromBody] UserClientModel User,
            [FromServices] ProjectMarketDbContext context)
        {

            var model = context.UserClient.FirstOrDefault(x => x.SystemId == id);
            if (model == null)
                return NotFound();

            model.UserName = User.UserName;
            model.UserAddress = User.UserAddress;
            model.UserPhone = User.UserPhone;
            model.UserId = User.UserId;
            model.UserEmail = User.UserEmail;
            model.UserPassword = User.UserPassword;

            context.UserClient.Update(model);
            context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("/v1/user/{id:int}")]
        public IActionResult Delete(
            [FromRoute] int id,
            [FromServices] ProjectMarketDbContext context)
        {

            var model = context.UserClient.FirstOrDefault(x => x.SystemId == id);
            if (model == null)
                return NotFound();

            context.UserClient.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }
    }
}
