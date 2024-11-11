using APISemana11A.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISemana11A.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsCustomController : ControllerBase
    {

        private readonly InvoiceContext _context;

        public ProductsCustomController(InvoiceContext context)
        {
            _context = context;
        }


        [HttpGet]
        public  List<Product> GetAll()
        {
            return _context.Products.ToList();
        }


        [HttpGet]
        //public List<Product> GetByName([FromQuery] string name)
        public List<Product> GetByName(string name)
        {
            return _context.Products.Where(x=>x.Name.Contains(name)).ToList();
        }

        [HttpGet]
        public Product GetById(int Id)
        {
            return _context.Products.Where(x => x.ProductID == Id).FirstOrDefault();
            //var products = _context.Products.Where(x => x.ProductID == Id).ToList();
            //if (products.Count > 0)
            //    return products[0];
            //else
            //    return new Product();            
        }

        [HttpPost]
        //public void Insert([FromBody] Product product)
        public void Insert( Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
      
    }
}
