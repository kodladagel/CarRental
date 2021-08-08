using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheRemoveAspect("ICarService.Get")]
        //[SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            Thread.Sleep(6000);
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull());

            if (result != null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(result.Message);
            }

            return new SuccessDataResult<List<CarDetailDto>>(CheckIfCarImageNull().Data);
        }


        
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int brandId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNullByBrandId(brandId));

            if (result != null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(result.Message);
            }

            return new SuccessDataResult<List<CarDetailDto>>(CheckIfCarImageNullByBrandId(brandId).Data);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int colorId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNullByColorId(colorId));

            if (result != null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(result.Message);
            }

            return new SuccessDataResult<List<CarDetailDto>>(CheckIfCarImageNullByColorId(colorId).Data);

        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndByBrand(int colorId, int brandId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNullByColorAndBrandId(colorId, brandId));

            if (result != null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(result.Message);
            }

            return new SuccessDataResult<List<CarDetailDto>>(CheckIfCarImageNullByColorAndBrandId(colorId, brandId).Data);

        }

        public IDataResult<CarDetailDto> GetCarDetailsByCar(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailsByCar(c => c.CarId == carId));
        }


        private IDataResult<List<CarDetailDto>> CheckIfCarImageNull()
        {

            var result = _carDal.GetCarDetails();
            foreach (var item in result)
            {
                if (item.CarImage == null)
                {
                    item.CarImage = @"\images\defaultImage.png";
                }

            }
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        private IDataResult<List<CarDetailDto>> CheckIfCarImageNullByBrandId(int brandId)
        {

            var result = _carDal.GetCarDetails(c=>c.BrandId==brandId);
            foreach (var item in result)
            {
                if (item.CarImage == null)
                {
                    item.CarImage = @"\images\defaultImage.png";
                }

            }
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        private IDataResult<List<CarDetailDto>> CheckIfCarImageNullByColorId(int colorId)
        {

            var result = _carDal.GetCarDetails(c => c.ColorId == colorId);
            foreach (var item in result)
            {
                if (item.CarImage == null)
                {
                    item.CarImage = @"\images\defaultImage.png";
                }

            }
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        private IDataResult<List<CarDetailDto>> CheckIfCarImageNullByColorAndBrandId(int colorId, int brandId)
        {

            var result = _carDal.GetCarDetails(c => c.ColorId == colorId & c.BrandId == brandId);
            foreach (var item in result)
            {
                if (item.CarImage == null)
                {
                    item.CarImage = @"\images\defaultImage.png";
                }

            }
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }


    }
}
