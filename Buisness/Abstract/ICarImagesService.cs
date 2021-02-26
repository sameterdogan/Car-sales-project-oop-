using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Abstract
{
  public  interface ICarImagesService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetAllByCarId(int id);

        IResult Add(Image ımage,CarImage carImages);
        IResult Delete(CarImage carImages);
        IResult Update(CarImage carImages);
    }
}
