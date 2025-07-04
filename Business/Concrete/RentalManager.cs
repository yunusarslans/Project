﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentaldal)
        {
                _rentalDal = rentaldal;
        }
        public IResult Add(Rental rental)
        {
           var result = _rentalDal.Get(r => r.CarId == rental.CarId);           //kiralama şartı
           var time = result ==null ? -1 : DateTime.Compare((DateTime)result.ReturnDate, rental.ReturnDate);


            if (rental.ReturnDate == null || time >= 0)
            {
                return new ErrorResult(Messages.CarNotRenteled);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(b => b.Id == rentalId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
