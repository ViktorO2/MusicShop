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
    public class RatingManagementService
    {
        public List<RatingDTO> Get()
        {
            List<RatingDTO> ratingsDTO = new List<RatingDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.RatingRepository.Get())
                {
                    ratingsDTO.Add(new RatingDTO
                    {
                        Id = item.Id,
                        Name = item.Name
                    });
                }
            }

            return ratingsDTO;
        }

        public bool Save(RatingDTO ratingDTO)
        {
            Rating rating = new Rating
            {
                Id = ratingDTO.Id,
                Name = ratingDTO.Name
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (ratingDTO.Id == 0)
                        unitOfWork.RatingRepository.Insert(rating);
                    else
                        unitOfWork.RatingRepository.Update(rating);
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
                    Rating rating = unitOfWork.RatingRepository.GetByID(id);
                    unitOfWork.RatingRepository.Delete(rating);
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
