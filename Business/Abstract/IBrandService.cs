﻿using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {

        
        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IResult Update(Brand brand);
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int brandId);
    }
}
