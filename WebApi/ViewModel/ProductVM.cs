using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.ViewModel
{
    public class ProductVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        public string Image { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }


        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public CategoryVM CategoryVM { get; set; }


        public ProductVM() { }
        public ProductVM(ProductDTO productDTO)
        {
            Id = productDTO.Id;
            Title = productDTO.Title;
            Description = productDTO.Description;
            Image = productDTO.Image;
            Price = productDTO.Price;
            CategoryId = productDTO.Id;
            CategoryVM = new CategoryVM
            {
                Id = productDTO.Id,
                CategoryName = productDTO.Category.CategoryName
            };
        }
    }
}