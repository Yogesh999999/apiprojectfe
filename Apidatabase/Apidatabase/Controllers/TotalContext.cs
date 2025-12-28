using Apidatabase.app;
using Apidatabase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apidatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalContext : ControllerBase
    {

        private readonly AppDbContext con;

        public TotalContext(AppDbContext context)
        {
            con = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable <newusers>>> getdata()
        {
            return await con.Newusers.ToListAsync();
        }

    }
}
