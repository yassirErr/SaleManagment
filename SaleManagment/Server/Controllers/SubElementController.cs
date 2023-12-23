using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleManagment.Shared;
using SaleManagment.Server.Data;

namespace SaleManagment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubElementController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubElementController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubElement>>> GetSubElement()
        {
            var orders = await _context.SubElements.ToListAsync();
            return Ok(orders);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SubElement>> GetSubElement(int id)
        {
            var order = await _context.SubElements.FirstOrDefaultAsync(h => h.Id == id);
            if (order == null)
            {
                return NotFound("No SubElement!!");
            }
            return Ok(order);
        }


        [HttpPost]
        public async Task<ActionResult<List<SubElement>>> GetSubElement(SubElement ord)
        {        
            _context.SubElements.Add(ord);
            await _context.SaveChangesAsync();
            return Ok(await GetDbSubElements());
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<SubElement>>> UpdateSubElement(SubElement ord, int id)
        {
            var dbOrd = await _context.SubElements
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbOrd == null)
                return NotFound("Sorry, but no Orders!!");

            dbOrd.Element = ord.Element;
            dbOrd.Type = ord.Type;
            dbOrd.Width = ord.Width;
            dbOrd.Height = ord.Height;

            await _context.SaveChangesAsync();

            return Ok(await GetDbSubElements());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SubElement>>> DeleteSubElement(int id)
        {
            var dbOrd = await _context.SubElements
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbOrd == null)
                return NotFound("Sorry, but no SubElements!!");

            _context.SubElements.Remove(dbOrd);
            await _context.SaveChangesAsync();

            return Ok(await GetDbSubElements());
        }


        private async Task<List<SubElement>> GetDbSubElements()
        {
            return await _context.SubElements.ToListAsync();
        }


    }
}
