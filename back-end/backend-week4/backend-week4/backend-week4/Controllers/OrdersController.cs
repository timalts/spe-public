using backend_week4.Data;
using backend_week4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_week4.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class OrdersController : ControllerBase
    {
        private readonly Context _context;
        public OrdersController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrders_ById(int id)
        {
            return _context.Orders.ToList().Find(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Orders>> Add_Orders(Orders order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrders", new { id = order.Id }, order);
        }
    }
}
