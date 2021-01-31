using Buisness.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace TestUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new InMemoryDal());

            carManager.Add(new Car { CarId = 4, BrandId = 2, ColorId = 2, DailyPrice = 150, ModelYear = "2021", Descripton = "Passat 2.6 " });
            carManager.Delete(new Car { CarId = 2 });
            carManager.Update(new Car { CarId = 1, BrandId = 2, ColorId = 2, DailyPrice = 50, ModelYear = "2000", Descripton = "Volvo 1.1 " });

            Console.WriteLine(carManager.GetById(new Car { CarId = 4 }).Descripton);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Description "+car.Descripton+ "Daily Price " + car.DailyPrice);
            
            }
          
        }
    }
}
