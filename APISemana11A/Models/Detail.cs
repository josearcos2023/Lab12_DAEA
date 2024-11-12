﻿namespace APISemana11A.Models
{
    public class Detail
    {
        public int DetailID { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double Subtotal { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int InvoiceID { get; set;}
        public Invoice Invoice { get; set; }
    }
}
