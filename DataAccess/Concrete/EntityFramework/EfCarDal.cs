using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in filter is null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                                 on c.BrandId equals b.brandId
                             join co in context.Colors
                                 on c.ColorId equals co.colorId
                             
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandName = b.Name,
                                 CarName = c.Name,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 ColorName = co.Name,
                                 DailyPrice = c.DailyPrice,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 CarImage = (from i in context.CarImages
                                             where (c.Id == i.CarId)
                                             select i.ImagePath).FirstOrDefault()
                             };

                 return result.ToList();
            }
        }


        


    }
}
