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

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car()
            {
                Name = "Linea",
                DailyPrice = 100000,
                BrandId = 5,
                Description = "1.6",
                ColorId = 2,
                ModelYear = 2011
            }
            );

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("tümünü ara - araba ismi: " + car.Name);
            }

            foreach (var car in carManager.GetCarsByBrandId(5))
            {
                Console.WriteLine("markaya göre arama - araba ismi: " + car.Name);
            }

            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine("renge göre arama - araba ismi: " + car.Name);
            }

            Console.WriteLine("araba id sine göre arama - araba ismi " + carManager.GetByCarId(1).Name);

        }
    }
}
