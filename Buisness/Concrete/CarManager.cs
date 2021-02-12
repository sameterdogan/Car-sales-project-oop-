using Buisness.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {

            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorResult("System is under maintenance.");
            }
            //şart blokları...
            _carDal.Add(car);
            return new SuccessResult("Car added."); 
        }

        public IResult Delete(Car car)
        {
            //şart blokları...
            _carDal.Delete(car);
            return new SuccessResult("Car deleted.");
        }

        public IDataResult<List<Car>> GetAll()
        {
            //şart blokları...
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),"All cars listed."); 
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(),"All cars deatils listed");
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id),"get car ");
        }

        public IResult Update(Car car)
        {
            //şart blokları...

            _carDal.Update(car);

            return new SuccessResult("Car updated.");
        }
    }
}
