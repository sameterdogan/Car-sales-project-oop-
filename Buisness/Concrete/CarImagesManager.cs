using Buisness.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Buisness.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;

        public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        public IResult Add(Image image,CarImage carImages)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(carImages.CarId));


            if (result != null)
            {
                return result;
            }
                _carImagesDal.Add(carImages);
            return new SuccessResult("Araba resmi başarıyla eklendi.");
          
        }



        public IResult Delete(CarImage carImages)
        {
            _carImagesDal.Delete(carImages);
            return new SuccessResult("Araba resmi başarıyla silindi.");
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(),"Bütün resimler listelendi.");
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(), "Arabanın resimleri listelendi.");
        }

        public IResult Update(CarImage carImages)
        {
            _carImagesDal.Update(carImages);
            return new SuccessResult("Araba başarıyla güncellendi.");
        }


        private IResult CheckCarImageLimit(int carImageId)
        {
            var carCount = _carImagesDal.GetAll(c => c.CarId == carImageId).Count;
            if (carCount >= 5)
            {
                return new ErrorResult("Bu kadar resim yeter dostum");
            }
            return new SuccessResult();

        }


        private static void CarImageUpload(Image image, CarImage carImages)
        {
            var path = "\\CarImages\\";
            var currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
            string randomName = null;
            string type = null;

            if (image.Files != null && image.Files.Length > 0)
            {
                randomName = Guid.NewGuid().ToString();
                type = Path.GetExtension(image.Files.FileName);

                if (!Directory.Exists(currentDirectory + path))
                {
                    Directory.CreateDirectory(currentDirectory + path);
                    Console.WriteLine(currentDirectory + path);
                }
                using (FileStream fs = File.Create(currentDirectory + path + randomName + type))
                {
                    Console.WriteLine(fs);
                    image.Files?.CopyTo(fs);
                    carImages.ImagePath = (path + randomName + type).Replace("\\", "/");

                }

            }
        }

    }


}
