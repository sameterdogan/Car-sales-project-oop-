﻿using Entities.Concrete;
using System.Collections.Generic;

namespace Buisness.Abstract
{
    public  interface ICarService
    {
        List<Car> GetAll();

        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        Car GetById(Car car);

    }
}
