using Buisness.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramewrok;
using Entities.Concrete;
using System;

namespace TestUI
{
    class Program
    {
        static void Main(string[] args)
        {
             BrandTest();

             ColorTest();

             CarTest();

            UserTest();

            CustomerTest();

            RentalTest();

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            var CarAdded = carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice = 150, ModelYear =new DateTime(2018,01,01), Description = "random description 3" });
          

            Console.WriteLine("Message= " +CarAdded.Message + " Success= " + CarAdded.Success);

            //bütün arabaları getirme
            var AllCar = carManager.GetAll();
            Console.WriteLine("Message =" + AllCar.Message + " Success= " + AllCar.Success);
            foreach (var car in AllCar.Data)
            {
                Console.WriteLine(car.Description);
            }


            //bütün arabaların detaylarını join kullanarak getirme
            var AllCarDetails = carManager.GetAllCarDetails();
            Console.WriteLine("Message =" + AllCarDetails.Message + " Success= " + AllCarDetails.Success);
            foreach (var car in AllCarDetails.Data)
            {
                Console.WriteLine(car.BrandName + "    " + car.ColorName + "   " + car.Description + "   " + car.DailyPrice);
            }

           // var carDeleted = carManager.Delete(new Car {CarId=4});
           // Console.WriteLine("Message= " + carDeleted.Message + " Success= " + carDeleted.Success);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
           var colorAdded= colorManager.Add(new Color { ColorName = "Red" });
            Console.WriteLine(colorAdded.Message);

         
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
           var brandAdded= brandManager.Add(new Brand { BrandName = "Volvo" });

            Console.WriteLine(brandAdded.Message);
        }
        private static void UserTest()
        {

            UserManager userManager = new UserManager(new EFUserDal());
            var userAdded = userManager.Add(new User { FirstName = "samet", LastName = "erdoğan", Email = "randombir1@gmail.com", Password = "randomrandom" });
            Console.WriteLine(userAdded.Message);

        }
        private static void CustomerTest() {

            CustomerManager customerManager = new CustomerManager(new EFCustomerDal());
            var customerAdded = customerManager.Add(new Customer {CompanyName="tekstil",UserId=1 });
            Console.WriteLine(customerAdded.Message);
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EFRentalDal());

            var rentalAdded = rentalManager.Add(new Rental { CarId = 4, CustomerID = 1, RentDate =DateTime.Now, ReturnDate = null}); ;
            Console.WriteLine(rentalAdded.Message);
            var rentalDetailGet = rentalManager.GetAllCarDetails();
            foreach (var rentalDetail in rentalDetailGet.Data)
            {
                Console.WriteLine(rentalDetail.CustomerFirstName);
                Console.WriteLine(rentalDetail.CustomerLastName);
                Console.WriteLine(rentalDetail.CarDescription);
                Console.WriteLine(rentalDetail.BrandName);
                Console.WriteLine(rentalDetail.ColorName);
                Console.WriteLine(rentalDetail.CarDailyPrice);
                Console.WriteLine(rentalDetail.RentDate);
                Console.WriteLine(rentalDetail.ReturnDate);

            }
        }

    }
}
