using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("tüm arabalar - tanımlamalar");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("*****");
            Console.WriteLine("id ye göre tek bir araba - fiyat");
            Console.WriteLine(carManager.GetByCarId(1).DailyPrice);

        }
    }
}
