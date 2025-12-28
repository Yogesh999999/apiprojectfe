using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi2.Entity;

namespace Webapi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticeController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Practice>>> Getalldata()
        {
            List<Practice> holder = new List<Practice>();

            Practice newpractice = new Practice()
            {
                Id = 1,
                Name = "Yogesh",
                Firstname = "o",
                Lastname = "p",
                Place = "Madipakkam"
            };
            holder.Add(newpractice);

            return Ok(holder);
        }
    }
}
