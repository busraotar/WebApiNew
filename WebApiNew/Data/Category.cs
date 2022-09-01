using System;
using System.Collections.Generic;

namespace WebApiNew.Data
{
    public class Category
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }  
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public string ImagePath { get; set; }
        public List<Product> Products { get; set; }
    }
}
