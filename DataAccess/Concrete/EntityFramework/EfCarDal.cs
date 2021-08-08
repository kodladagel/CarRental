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
                                 Available= !context.Rentals.Any(r=>r.CarId==c.Id&&(r.ReturnDate==null||r.RentDate>DateTime.Now)),
                                 CarImage = (from i in context.CarImages
                                             where (c.Id == i.CarId)
                                             select i.ImagePath).FirstOrDefault()
                             };

                 return result.ToList();
            }
        }


        public CarDetailDto GetCarDetailsByCar(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {


                var result = from c in context.Cars

                             join b in context.Brands
                             on c.BrandId equals b.brandId
                             join col in context.Colors
                             on c.ColorId equals col.colorId
                             //join img in carSqlServerContext.CarImages
                             // on c.Id equals img.CarId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandName = b.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ColorName = col.Name,
                                 BrandId = b.brandId,
                                 ColorId = c.ColorId,
                                 ModelYear = c.ModelYear,
                                 Available = !context.Rentals.Any(r => r.CarId == c.Id && (r.ReturnDate == null || r.RentDate > DateTime.Now)),
                                 CarImage = (from i in context.CarImages
                                             where (c.Id == i.CarId)
                                             select i.ImagePath).FirstOrDefault()

                             };
                return filter == null ?
                    result.SingleOrDefault() :
                    result.SingleOrDefault(filter);


            }
        }


    }
}
