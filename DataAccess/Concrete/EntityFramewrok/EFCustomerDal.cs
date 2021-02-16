using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramewrok
{
    public class EFCustomerDal : EFEntityRepositoryBase<Customer, CarSalesContext>, ICustomerDal
    {


        public List<CustomerDetailDto> GetAllCustomerDetails()
        {
            using (CarSalesContext context = new CarSalesContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId = c.CustomerId,
                                 UserFirstName = u.FirstName,
                                 UserLastName = u.LastName,
                                 CompanyName = c.CompanyName

                             };

                return result.ToList();

            }
        }
        public CustomerDetailDto GetByIdCustomerDetails(int id)
        {
            using (CarSalesContext context=new CarSalesContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.UserId
                             where (c.UserId==id)
                             select new CustomerDetailDto
                             {
                                 CustomerId = c.CustomerId,
                                 UserFirstName = u.FirstName,
                                 UserLastName = u.LastName,
                                 CompanyName = c.CompanyName
                             };
                return result.Single();
            }
        
        }

    }
}
