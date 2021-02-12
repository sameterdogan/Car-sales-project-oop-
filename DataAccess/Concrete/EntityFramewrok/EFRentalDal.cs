using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramewrok
{
    public class EFRentalDal : EFEntityRepositoryBase<Rental, CarSalesContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetails()
        {
            using (CarSalesContext context=new CarSalesContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.CarId
                             join customer in context.Customers on rental.CustomerID equals customer.CustomerId
                             join user in context.Users on customer.UserId equals user.UserId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             select new RentalDetailDto
                             {
                                 RentalId = rental.RentalId,
                                 BrandName = brand.BrandName,
                                 CarDescription = car.Description,
                                 CarDailyPrice = car.DailyPrice,
                                 ColorName=color.ColorName,
                                 CustomerFirstName = user.FirstName,
                                 CustomerLastName = user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };

                return result.ToList();

            }
          
        }
    }
}
