using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using urlpractice.Models;


namespace urlpractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Getemployee([FromQuery] Employee emp)
        {
            return Ok(emp);
        }

    }
}


      

