using System.Collections.Generic;
using System;
using WebApiNew.Data;

namespace WebApiNew.Dto
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string ImagePath { get; set; }
    }
}
