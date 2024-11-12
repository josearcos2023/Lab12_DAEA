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
    public class ProductsController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public ProductsController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Product> GetAll()
        {
            return _context.Products.Where(x => x.Active == true).ToList();
        }

        [HttpGet]
        public Product GetByID(int Id)
        {
            return _context.Products.Where(x => x.ProductID == Id && x.Active == true).FirstOrDefault();
        }

        [HttpPost]
        public void Insert(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        [HttpPost]
        public void Edit(Product newProduct)
        {
            var product = _context.Products.Find(newProduct.ProductID);
            if (product==null || product.Active == false)
            {
                return;
            }
            product.Name = newProduct.Name;
            product.Price = newProduct.Price;
            //product.Active = true;

            _context.SaveChanges();
        }

        [HttpPost]
        public void Delete(int Id)
        {
            var product = _context.Products.Find(Id);
            if (product == null || product.Active==false)   
            {
                return; 
            }

            product.Active = false;
            _context.SaveChanges();
        }

    }
}
