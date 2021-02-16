using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Buisness.Abstract
{
    public  interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        IDataResult<Car> GetById(int id);

        IDataResult<List<CarDetailDto>> GetAllCarDetails();

        IDataResult<CarDetailDto> GetByIdCarDetails(int id);

        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);


    }
}
