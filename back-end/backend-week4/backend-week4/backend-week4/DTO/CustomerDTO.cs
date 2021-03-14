using backend_week4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_week4.DTO
{
    public class CustomerDTO
    {
        public int Customer_id { get; set; }
        public string Name { get; set; }
        public List<Orders> Orders { get; set; }

    }
}
