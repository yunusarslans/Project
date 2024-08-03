using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.BusinessRules;
using Core.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {

        ICarImagesDal _carImagesDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImagesDal carImagesDal, IFileHelper fileHelper)
        {
            _carImagesDal = carImagesDal;
            _fileHelper = fileHelper;

        }


        public IResult AddCarImage(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageCount(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagePath);         
            carImage.Date = DateTime.Now;
            _carImagesDal.Add(carImage);                                                

            return new SuccessResult();
        }

        public IResult DeleteCarImage(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagePath + carImage.ImagePath);
            _carImagesDal.Delete(carImage);

            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<CarImage>> GetAllCarImage()
        {
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetCarImageByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(i => i.CarId == carId));
        }


        
        public IDataResult<CarImage> GetCarImageById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImagesDal.Get(i => i.Id == Id));
        }


        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult UpdateCarImage(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagePath + carImage.ImagePath, PathConstants.ImagePath);
            _carImagesDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckCarImageCount(int carId)
        {
            var result = _carImagesDal.GetAll(i => i.CarId == carId).Count;
            if (result <= 5)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CheckCarImageCount);
        }
    }
}
