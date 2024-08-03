using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public string? Description { get; set; }
        public string BrandName { get; set; }

        public int ModelYear { get; set; }

        public string ColorName { get; set; }

        public string CarModel { get; set; }

        public double DailyPrice { get; set; }
    }
}


