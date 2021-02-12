using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Abstract
{
   public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();

        IDataResult<Rental> GetById(int id);

        IDataResult<List<RentalDetailDto>> GetAllCarDetails();

        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}
