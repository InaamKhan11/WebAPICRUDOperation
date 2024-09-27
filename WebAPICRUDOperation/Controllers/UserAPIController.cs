using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICRUDOperation.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace WebAPICRUDOperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly UserApiContext dbContext;
        public UserAPIController(UserApiContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserApi>>> GetUserApis()
        {
            var data = await dbContext.UserApis.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserApi>> GetUserApiById(int id)
        {
            var userapi = await dbContext.UserApis.FindAsync(id);
            if(userapi == null)
            {
                return NotFound();
            }
            return Ok(userapi);
        }

        [HttpPost]
        public async Task<ActionResult<UserApi>> CreateUserApi(UserApi cui)
        {
            await dbContext.UserApis.AddAsync(cui);
            await dbContext.SaveChangesAsync();
            return Ok(cui);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserApi>> UpdateUserApi(int id, UserApi uui)
        {
            if (id != uui.Id)
            {
                return BadRequest();
            }
            dbContext.Entry(uui).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return Ok(uui);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserApi>> DeleteUserApi(int id)
        {
            var userapi = await dbContext.UserApis.FindAsync(id);
            if(userapi == null)
            {
                return NotFound();
            }
            dbContext.UserApis.Remove(userapi);
            await dbContext.SaveChangesAsync();
            return Ok(userapi);
        }
    }
}

