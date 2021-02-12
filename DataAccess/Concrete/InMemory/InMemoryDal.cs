using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryDal : ICarDal
    {

        List<Car> _cars;

       

        public InMemoryDal()
        {
            _cars = new List<Car>{
                 new Car {  CarId = 1,BrandId=2, ColorId = 1, DailyPrice = 100, ModelYear = new DateTime(2018), Description = "Chevrolet Lacetti 1.4 " },
                 new Car {  CarId = 2,BrandId=1, ColorId = 1, DailyPrice = 200, ModelYear = new DateTime(2018), Description = "Chevrolet Lacetti 1.5 " },
                 new Car {  CarId = 3,BrandId=3, ColorId = 1, DailyPrice = 300, ModelYear = new DateTime(2018), Description = "Chevrolet Lacetti 1.6 " }

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

            UpdateByCar.Description = car.Description;


        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetAllCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
