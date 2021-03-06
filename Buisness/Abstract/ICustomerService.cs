﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Abstract
{
   public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();

        IDataResult<Customer> GetById(int id);

        IDataResult<List<CustomerDetailDto>> GetAllCustomerDetails();

        IDataResult<CustomerDetailDto> GetByIdCustomerDetails(int id);

        IResult Add(Customer customer);
        IResult Delete(Customer customer);

        IResult Update(Customer customer);
    }
}
