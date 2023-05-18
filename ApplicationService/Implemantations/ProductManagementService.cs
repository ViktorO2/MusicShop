using ApplicationService.DTOs;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implemantations
{
    public class ProductManagementService
    {
        public List<ProductDTO> Get()
        {
            List<ProductDTO> productDTO = new List<ProductDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.ProductRepository.Get())
                {
                    productDTO.Add(new ProductDTO
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Description = item.Description,
                        Image = item.Image,
                        Price = item.Price
                    });;
                }



                return productDTO;
            }
        }

        public ProductDTO GetById(int id)
        {
            ProductDTO productDTO = new ProductDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Product product = unitOfWork.ProductRepository.GetByID(id);
                productDTO = new ProductDTO
                {
                    Title = product.Title,
                    Description = product.Description,
                    Image = product.Image,
                    Price = product.Price,
                    CategoryId = product.CategoryId
                };
            }

            return productDTO;
        }

        public bool Save(ProductDTO productDTO)
        {
            Product product = new Product
            {
                Id = productDTO.Id,
                Title = productDTO.Title,
                Description = productDTO.Description,
                Image = productDTO.Image,
                Price = productDTO.Price,
                CategoryId = productDTO.Category.Id
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (productDTO.Id == 0)
                        unitOfWork.ProductRepository.Insert(product);
                    else
                        unitOfWork.ProductRepository.Update(product);

                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Product product = unitOfWork.ProductRepository.GetByID(id);
                    unitOfWork.ProductRepository.Delete(product);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}

