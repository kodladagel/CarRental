using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            //Console.WriteLine("tüm arabalar - tanımlamalar");
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}

            //Console.WriteLine("*****");
            //Console.WriteLine("id ye göre tek bir araba - fiyat");
            //Console.WriteLine(carManager.GetByCarId(1).DailyPrice);

            //CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car()
            //{
            //    Name = "Linea",
            //    DailyPrice = 100000,
            //    BrandId = 5,
            //    Description = "1.6",
            //    ColorId = 2,
            //    ModelYear = 2011
            //}
            //);

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine("tümünü ara - araba ismi: " + car.Name);
            //}

            //foreach (var car in carManager.GetCarsByBrandId(5))
            //{
            //    Console.WriteLine("markaya göre arama - araba ismi: " + car.Name);
            //}

            //foreach (var car in carManager.GetCarsByColorId(2))
            //{
            //    Console.WriteLine("renge göre arama - araba ismi: " + car.Name);
            //}

            //Console.WriteLine("araba id sine göre arama - araba ismi " + carManager.GetByCarId(1).Name);


            CarAddTest();
            BrandAddTest();
            ColorAddTest();
            BrandDeleteTest();
            ColorUpdateTest();
            CarDetailDtoTest();
            BrandGetAllTest();
            ColorGetByColorIdTest();
            

        }

        private static void ColorUpdateTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(new Color { Id = 1, Name = "Sarı" });
        }

        private static void BrandDeleteTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Delete(new Brand { Id = 4 });
        }

        private static void ColorGetByColorIdTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine(colorManager.GetByColorId(1).Name);
        }

        private static void BrandGetAllTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine($"BrandName: {brand.Name}");
            }
        }

        private static void CarDetailDtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine($"CarName: {car.CarName}, BrandName: {car.BrandName}, ColorName: {car.ColorName}, DailyPrice: {car.DailyPrice}");
            }
        }

        private static void ColorAddTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { Name = "Beyaz" });
            colorManager.Add(new Color { Name = "Siyah" });
            colorManager.Add(new Color { Name = "Kırmızı" });
            colorManager.Add(new Color { Name = "Mavi" });
        }

        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Name = "Fiat" });
            brandManager.Add(new Brand { Name = "Mercedes" });
            brandManager.Add(new Brand { Name = "BMW" });
            brandManager.Add(new Brand { Name = "Audi" });
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 1, ColorId = 1, Name = "X6 !!", ModelYear = 2009, DailyPrice = 400000, Description = "Süper araba" });
            carManager.Add(new Car { BrandId = 2, ColorId = 2, Name = "X6 !!", ModelYear = 2009, DailyPrice = 400000, Description = "Çok  iyi" });
            carManager.Add(new Car { BrandId = 3, ColorId = 2, Name = "X6 !!", ModelYear = 2009, DailyPrice = 400000, Description = "Bu başka" });
        }


    }
}
