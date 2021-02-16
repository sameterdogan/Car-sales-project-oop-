using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace DataAccess.Concrete.EntityFramewrok
{
    public class EFCarDal : EFEntityRepositoryBase<Car, CarSalesContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetails()
        {
            using (CarSalesContext context =new CarSalesContext())
            {

                var result = from c in context.Cars
                             join co in context.Colors on c.ColorId equals co.ColorId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear

                             };
                return result.ToList();

            }
        }

        public CarDetailDto GetByIdCarDetails(int id)
        {
            using (CarSalesContext context = new CarSalesContext())
            {

                var result= from c in context.Cars
                            join co in context.Colors on c.ColorId equals co.ColorId
                            join b in context.Brands on c.BrandId equals b.BrandId
                            select new CarDetailDto
                            {
                                CarId = c.CarId,
                                BrandName = b.BrandName,
                                ColorName = co.ColorName,
                                DailyPrice = c.DailyPrice,
                                Description = c.Description,
                                ModelYear = c.ModelYear

                            };
                return result.FirstOrDefault(c=>c.CarId==id);

            }
        }
    }
}
