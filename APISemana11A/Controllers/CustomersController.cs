using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APISemana11A.Models;

namespace APISemana11A.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public CustomersController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Customer> GetAll()
        {
            return _context.Customers.Where(x => x.Active==true).ToList();
        }

        [HttpGet]
        public Customer GetByID(int Id)
        {
            return _context.Customers.Where(x => x.CustomerID == Id && x.Active==true).FirstOrDefault();
        }

        [HttpPost]
        public void Insert(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        [HttpPost]
        public void Delete(int Id)
        {
            var customer = _context.Customers.Find(Id);
            if (customer == null || customer.Active==false)
            {
                return;
            }

            customer.Active = false;
            _context.SaveChanges();
        }
    }
}
