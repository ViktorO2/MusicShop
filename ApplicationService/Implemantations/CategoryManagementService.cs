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
    public class CategoryManagementService
    {
        public List<CategoryDTO> Get()
        {
            List<CategoryDTO> categoryDTO = new List<CategoryDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.CategoryRepository.Get())
                {
                    //categoryDTO.Add(new CategoryDTO
                    //{
                    //    Id = item.Id,
                    //    CategoryName = item.CategoryName
                    //});
                }
            }

            return categoryDTO;
        }

        public CategoryDTO GetById(int id)
        {
            CategoryDTO categoryDTO = new CategoryDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Category category = unitOfWork.CategoryRepository.GetByID(id);

                categoryDTO = new CategoryDTO
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName
                };
            }

            return categoryDTO;
        }

        public bool Save(Category categoryDTO)
        {
            Category category = new Category
            {
                Id = categoryDTO.Id,
                CategoryName= categoryDTO.CategoryName
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (categoryDTO.Id == 0)
                        unitOfWork.CategoryRepository.Insert(category);
                    else
                        unitOfWork.CategoryRepository.Update(category);
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
            if (id == 0) return false;

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Category category = unitOfWork.CategoryRepository.GetByID(id);
                    unitOfWork.CategoryRepository.Delete(category);
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

