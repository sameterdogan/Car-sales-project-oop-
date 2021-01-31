using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryDal : ICarDal
    {

        List<Car> _cars;

       

        public InMemoryDal()
        {
            _cars = new List<Car>{
                 new Car {  CarId = 1,BrandId=2, ColorId = 1, DailyPrice = 100, ModelYear = "2018", Descripton = "Chevrolet Lacetti 1.4 " },
                 new Car {  CarId = 2,BrandId=1, ColorId = 1, DailyPrice = 200, ModelYear = "2019", Descripton = "Chevrolet Lacetti 1.5 " },
                 new Car {  CarId = 3,BrandId=3, ColorId = 1, DailyPrice = 300, ModelYear = "2020", Descripton = "Chevrolet Lacetti 1.6 " }

                };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Add(Car car)
        {

            _cars.Add(car);
        }


        public void Delete(Car car)
        {

            Car DeleteByCar = _cars.FirstOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(DeleteByCar);

        }


        public Car GetById(Car car)
        {
            return _cars.FirstOrDefault(c => c.CarId == car.CarId);
        }

        public void Update(Car car)
        {
            Car UpdateByCar = _cars.FirstOrDefault(c => c.CarId == car.CarId);

            UpdateByCar.BrandId = car.BrandId;

            UpdateByCar.ColorId = car.ColorId;

            UpdateByCar.DailyPrice = car.DailyPrice;

            UpdateByCar.ModelYear = car.ModelYear;

            UpdateByCar.Descripton = car.Descripton;


        }
    }
}
