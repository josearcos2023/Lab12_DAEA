using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace APISemana11A.Models
{
    public class InvoiceContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SRDOPL1\\SQLEXPRESS; Database=APISemana13ADB; Integrated Security=True;Trust Server Certificate=True ");
        }
    }
}
