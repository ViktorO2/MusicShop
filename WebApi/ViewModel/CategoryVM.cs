using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.ViewModel
{
    public class CategoryVM
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}