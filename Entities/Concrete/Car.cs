﻿using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }

        public int ModelYear { get; set; }
        public double DailyPrice { get; set; }

        public string? Description { get; set; }

   



        public string? CarModel { get; set; }


        public int ColorId { get; set; }
    }
}
