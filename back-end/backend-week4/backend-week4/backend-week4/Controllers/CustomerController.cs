using backend_week4.Data;
using backend_week4.DTO;
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
    public class CustomersController : ControllerBase
    {
        private readonly Context _context;

        public CustomersController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customer.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomers_ById(int id)
        {
            var orders = _context.Orders.ToList().Where(x => x.Customer_id == id);
            var customer_by_id = _context.Customer.ToList().Find(x => x.Id == id);
            if (customer_by_id == null || orders == null)
                return NotFound();
            var customerDTO = new CustomerDTO
            {
                Customer_id = id,
                Name = customer_by_id.Name,
                Orders = orders.ToList()
            };
            return customerDTO;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> Add_Customer(Customer customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = new Customer()
            {
                Id = customerDTO.Id,
                Name = customerDTO.Name

            };
            await _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customerDTO);
        }


    }
}
