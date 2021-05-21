using System.Collections.Generic;
using System.Threading.Tasks;
using DatingAppWeb.Data;
using DatingAppWeb.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAppWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext context;

        public  UsersController (DataContext context)
        {
            this.context = context;
        }


        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>>  GetUsers()
        {
            var users = await this.context.Users.ToListAsync();
            return users;
        }
        
        
        // GET: api/Users/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await this.context.Users.FindAsync(id);
            return user;
        }
    }
}