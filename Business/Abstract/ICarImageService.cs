using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAllCarImage();
        IDataResult<CarImage> GetCarImageById(int Id);
        IDataResult<List<CarImage>> GetCarImageByCarId(int carId);
        IResult AddCarImage(IFormFile file, CarImage carImage);
        IResult UpdateCarImage(IFormFile file, CarImage carImage);
        IResult DeleteCarImage(CarImage carImage);
    }
}
