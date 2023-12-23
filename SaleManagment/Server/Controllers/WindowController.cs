using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleManagment.Shared;
using SaleManagment.Server.Data;

namespace SaleManagment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WindowController(AppDbContext context)
        {
            _context = context;
        }

 

        [HttpGet]
        public async Task<ActionResult<List<Window>>> GetWindows()
        {
            var windows = await _context.Windows.ToListAsync();
            return Ok(windows);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Window>> GetWindow(int id)
        {
            var window = await _context.Windows
                .FirstOrDefaultAsync(h => h.Id == id);
            if (window == null)
            {
                return NotFound("No Window!!");
            }
            return Ok(window);
        }


        [HttpPost]
        public async Task<ActionResult<List<Window>>> CreateWindow(Window win)
        {
           
            _context.Windows.Add(win);
            await _context.SaveChangesAsync();

            return Ok(await GetDbWindows());
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Window>>> UpdateWindow(Window win, int id)
        {
            var dbWin = await _context.Windows
                               .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbWin == null)
                return NotFound("Sorry, but no Windows!!");

            dbWin.Name = win.Name;
            dbWin.QuantityOfWindows = win.QuantityOfWindows;
            dbWin.TotalSubElements = win.TotalSubElements;


            await _context.SaveChangesAsync();

            return Ok(await GetDbWindows());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Window>>> DeleteWindow(int id)
        {
            var dbWin = await _context.Windows
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbWin == null)
                return NotFound("Sorry, but no Windows!!");

            _context.Windows.Remove(dbWin);
            await _context.SaveChangesAsync();

            return Ok(await GetDbWindows());
        }

        private async Task<List<Window>> GetDbWindows()
        {
            return await _context.Windows.ToListAsync();
        }


    }
}
