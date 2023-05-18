using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class CategoryDTO:BaseDTO
    {
        public string CategoryName { get; set; }

        public bool Validate()
        {
            return !String.IsNullOrEmpty(CategoryName);
        }
    }
}
