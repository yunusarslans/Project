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
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, Db>, ICarDal
    {


        public List<CarDetailDto> GetCarDetailDto()
        {
            using (Db context = new Db())
            {
                var result = from c in context.Cars
                             join co in context.Colors   //productlarla categorilerin id leri eşit ise birleştir
                             on c.ColorId equals co.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             orderby c.BrandId
                             select new CarDetailDto
                             {
                                 Description = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 CarModel = c.CarModel
                             };
                var x = result.ToList();

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailDtoByColorId(int colorId)
        {
            using (Db context = new Db())
            {
                var result = from c in context.Cars
                             join co in context.Colors   //productlarla categorilerin id leri eşit ise birleştir
                             on c.ColorId equals co.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             where c.ColorId == colorId
                             select new CarDetailDto
                             {
                                 Description = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 CarModel = c.CarModel
                             };
                var x = result.ToList();

                return result.ToList();
            }
        }
    }
}
