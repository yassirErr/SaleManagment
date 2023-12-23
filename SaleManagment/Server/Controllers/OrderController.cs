using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleManagment.Shared;
using SaleManagment.Server.Data;

namespace SaleManagment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(h => h.Id == id);
            if (order == null)
            {
                return NotFound("No order!!");
            }
            return Ok(order);
        }


        [HttpPost]
        public async Task<ActionResult<List<Order>>> CreateOrder(Order ord)
        {        
            _context.Orders.Add(ord);
            await _context.SaveChangesAsync();
            return Ok(await GetDbOrders());
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Order>>> UpdateOrder(Order ord, int id)
        {
            var dbOrd = await _context.Orders
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbOrd == null)
                return NotFound("Sorry, but no Orders!!");

            dbOrd.Name = ord.Name;
            dbOrd.State = ord.State;

            await _context.SaveChangesAsync();

            return Ok(await GetDbOrders());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Order>>> DeleteOrder(int id)
        {
            var dbOrd = await _context.Orders
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbOrd == null)
                return NotFound("Sorry, but no Orders!!");

            _context.Orders.Remove(dbOrd);
            await _context.SaveChangesAsync();

            return Ok(await GetDbOrders());
        }


        private async Task<List<Order>> GetDbOrders()
        {
            return await _context.Orders.ToListAsync();
        }


    }
}
