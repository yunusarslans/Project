using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId = 1, BrandId = 1, ModelYear= 2004, DailyPrice= 5000, Description="Araba1"},
                new Car{CarId = 2, BrandId = 2, ModelYear= 2008, DailyPrice= 9000, Description="Araba2"},
                new Car{CarId = 3, BrandId = 3, ModelYear= 1997, DailyPrice= 8000, Description="Araba3"},
                new Car{CarId = 4, BrandId = 4, ModelYear= 2001, DailyPrice= 7000, Description="Araba4"},
                new Car{CarId = 5, BrandId = 5, ModelYear= 2014, DailyPrice= 6000, Description="Araba5"},

            };
        }
      
    
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
           return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByCarId(int CarId)
        {
            return _cars.Where(p => p.CarId == CarId).ToList();

        }

        public List<CarDetailDto> GetCarDetailDto()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailDtoByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
