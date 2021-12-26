using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        public DataContext Config { get; set; }
        public UsersController(DataContext config)
        {
            Config = config;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return  await Config.Users.ToListAsync();
        }

        [HttpGet("{id}")]        
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await Config.Users.FindAsync(id);
        }
    }
}