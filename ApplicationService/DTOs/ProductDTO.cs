using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class ProductDTO:BaseDTO
    {
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int? CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
