using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;

        public CarManager(ICarDal carDal)
        {
      
            _CarDal = carDal;
        }

        public void Add(Car car)
        {
            //şart blokları...
            _CarDal.Add(car);
            Console.WriteLine("eklendi");
        }

        public void Delete(Car car)
        {
            //şart blokları...
            _CarDal.Delete(car);
            Console.WriteLine("Silindi");
        }

        public List<Car> GetAll()
        {
            //şart blokları...
            return _CarDal.GetAll();
        }

        public Car GetById(Car car)
        {
            //şart blokları...
            return _CarDal.GetById(car);
        }

        public void Update(Car car)
        {
            //şart blokları...

            _CarDal.Update(car);

            Console.WriteLine("Güncellendi");
        }
    }
}
