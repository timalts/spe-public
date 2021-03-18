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
    public class ProductController : ControllerBase
    {

        private readonly Context _context;

        public ProductController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts_ById(int id)
        {
            return _context.Products.ToList().Find(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Products>> Add_Orders(Products products)
        {
            await _context.Products.AddAsync(products);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = products.Id }, products);
        }
    }
}
