using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleManagment.Server.Data;
using SaleManagment.Server.Repository.IRepository;
using SaleManagment.Shared;
using System.Threading.Tasks;

namespace SaleManagment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;
        public OrderController(IUnitOfWork unitOfWork, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            IEnumerable<Order> getOrdersList = _unitOfWork.Order.GetAll();
            return Ok(getOrdersList);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> getorder(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            var FirstOrDefaultOrders = _unitOfWork.Order.GetFirstOrDefault(c => c.Id == id);
            if (FirstOrDefaultOrders == null)
            {
                return NotFound();
            }
            return Ok(FirstOrDefaultOrders);

   
        }


        [HttpPost]
        public async Task<ActionResult<List<Order>>> CreateOrder(Order obj)
        {
            if (obj.Name == obj.State.ToString())
            {
                ModelState.AddModelError("name", "Should Enter Different Value");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Order.Add(obj);
                _unitOfWork.Save();
                return RedirectToAction("GetOrders");
            }

            return Ok(obj);



        }


        [HttpPut("{id}")]

        public async Task<ActionResult<List<Order>>> UpdateOrder(Order obj, int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            if (obj.Name == obj.State.ToString())
            {
                ModelState.AddModelError("name", "Should Enter Different Value");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Order.Update(obj);
                _unitOfWork.Save();
       
            }
            return Ok(await GetDbOrders());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Order>>> DeleteOrder(int id)
        {
            var objDelete = _unitOfWork.Order.GetFirstOrDefault(c => c.Id == id);

            if (objDelete == null)
            {
                return NotFound();
            }

            _unitOfWork.Order.Remove(objDelete);
            _unitOfWork.Save();

            return Ok(await GetDbOrders());
        }


        private async Task<List<Order>> GetDbOrders()
        {
            return await _context.Orders.ToListAsync();
        }

    }
}
