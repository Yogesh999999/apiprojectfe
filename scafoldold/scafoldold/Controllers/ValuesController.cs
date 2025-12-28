using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using scafoldold.Models;

namespace scafoldold.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public ValuesController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var order = await _context.Ord.FindAsync(id);

            if (order == null)
                return NotFound();

            var orderDto = _mapper.Map<OrderDTO>(order);
            return Ok(orderDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDTO orderDto)
        {
            if (orderDto == null)
                return BadRequest("Order data is required.");

            var order = _mapper.Map<Order>(orderDto);
            await _context.Ord.AddAsync(order);
            await _context.SaveChangesAsync();

            var createdOrderDto = _mapper.Map<OrderDTO>(order);

            return CreatedAtAction(nameof(GetUser), new { id = createdOrderDto.Id }, createdOrderDto);
        }


        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderDTO orderDto)
        //{
        //    if (orderDto == null)
        //        return BadRequest("Order data is required.");

        //    var existingOrder = await _context.Ord.FindAsync(id);
        //    if (existingOrder == null)
        //        return NotFound();

        //    _mapper.Map(orderDto, existingOrder);

        //    _context.Ord.Update(existingOrder);
        //    await _context.SaveChangesAsync();

        //    var updatedOrderDto = _mapper.Map<OrderDTO>(existingOrder);

        //    return Ok(updatedOrderDto);
        //}

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchOrder(int id, OrderDTO dto)
        {
            var order = await _context.Ord.FindAsync(id);
            if (order == null)
                return NotFound();

            _mapper.Map(dto, order);   

            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<OrderDTO>(order));
        }



    }


}




